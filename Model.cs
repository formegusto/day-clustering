using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using DayClustering.common;
using DayClustering.utils;
using DayClustering.entity;
using Microsoft.Office.Interop.Excel;

namespace DayClustering
{
	public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);

	public class ModelEventArgs: EventArgs
	{
		public string action;
		public string cluster;
		public string search;
		public string day;

		public ModelEventArgs(string a)
		{
			this.action = a;
		}

		public ModelEventArgs(string a, string c, string s, string d)
		{
			this.action = a;
			this.cluster = c;
			this.search = s;
			this.day = d;
		}
	}

	public interface IModelObserver
	{
		void ModelNotify(IModel model, ModelEventArgs e);
	}

	public interface IModel
	{
		void Attach(IModelObserver observer);
		void ChangeKeyword(string keyword);
		void LoadExcel();
	}

	public class DayClusteringModel : IModel
	{
		public string searchKeyword;
		public event ModelHandler<DayClusteringModel> changed;
		public List<DayData>[] dayStore;

		public DayClusteringModel() {
			this.searchKeyword = "";
			this.dayStore = new List<DayData>[7];
		}

		public void Attach(IModelObserver imo)
		{
			this.changed += new ModelHandler<DayClusteringModel>(imo.ModelNotify);
		}

		public async void LoadExcel()
		{
			DateTime startDate = new DateTime(2018,12,1);
			DateTime endDate = new DateTime(2018, 12, 31);
			List<DateTime> dateList = new List<DateTime>();

			for (int i = 0; i < 7; i++)
				this.dayStore[i] = new List<DayData>();

			for(DateTime day = startDate; day <= endDate; day = day.AddDays(1))
				dateList.Add(day);

			Parallel.ForEach(dateList.ToArray(), async currentDay => 
			{
				Data clusterTmp = null;
				string path = System.Windows.Forms.Application.StartupPath + @"\data\clustering_" + currentDay.ToString("yyyyMMdd") + ".csv";
				StreamReader sr = new StreamReader(path, Encoding.GetEncoding("euc-kr"));

				while (!sr.EndOfStream)
				{
					string line = await sr.ReadLineAsync();
					string uid = line.Split(',')[0];

					if (uid.Contains("cluster"))
						clusterTmp = new Data(line.Split(',').ToList());
						
					if (clusterTmp != null && uid == this.searchKeyword)
					{
						this.dayStore[DateUtils.DayToIndex(currentDay)].Add(new DayData(
							clusterTmp,
							new Data(line.Split(',').ToList())
							)
						);
						Console.WriteLine(dayStore[DateUtils.DayToIndex(currentDay)].Last().ToString("===========\n"));
						Thread.Sleep(1000);
						this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTIONS.LOAD_EXCEL_SUCCESS, clusterTmp.uid, uid, DateUtils.DayToKR(currentDay)));
						return;
					}
				}

				sr.Close();
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTIONS.LOAD_EXCEL_NOT_FOUND));
			});
		}

		public void ChangeKeyword(string keyword)
		{
			Console.WriteLine("[Model: ChangeKeyword] " + keyword);
			this.searchKeyword = keyword;
		}
	}
}
