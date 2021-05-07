
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
		public DayData[] dayData;
		public PowerFrequency[] powerFrequencies;

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

		public ModelEventArgs(string a, string d)
		{
			this.action = a;
			this.day = d;
		}

		public ModelEventArgs(string a, DayData[] dd, PowerFrequency[] pf) {
			this.action = a;
			this.dayData = dd;
			this.powerFrequencies = pf;
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
		void RequestDayData(string dayFullName);
	}

	public class DayClusteringModel : IModel
	{
		public string searchKeyword;
		public string timeSlotChk;
		public event ModelHandler<DayClusteringModel> changed;
		public List<DayData>[] dayStore;
		public PowerFrequency[] powerFrequencies;

		public DayClusteringModel() {
			this.searchKeyword = "";
			this.timeSlotChk = "";
			this.dayStore = new List<DayData>[7];
		}

		public void Attach(IModelObserver imo)
		{
			this.changed += new ModelHandler<DayClusteringModel>(imo.ModelNotify);
		}

		public void LoadExcel()
		{
			DateTime startDate = new DateTime(2018,5,1);
			DateTime endDate = new DateTime(2019, 4, 29);
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
						// Console.WriteLine(dayStore[DateUtils.DayToIndex(currentDay)].Last().ToString("===========\n"));
						// Thread.Sleep(1000);
						this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTIONS.LOAD_EXCEL_SUCCESS, clusterTmp.uid, uid, DateUtils.DayToKR(currentDay)));
						return;
					}
				}

				sr.Close();
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTIONS.LOAD_EXCEL_NOT_FOUND, currentDay.ToString("yyyyMMdd")));
			});
		}

		public void ChangeKeyword(string keyword) => this.searchKeyword = keyword;

		public void RequestDayData(string dayFullName)
		{
			List<PowerFrequency> pfList = new List<PowerFrequency>();

			this.dayStore[DateUtils.KRDayToIndex(dayFullName)].ForEach((d) =>
			{
				
				Console.WriteLine(d.ToString());
				PowerFrequency findPf = pfList.Find((pf) => pf.wh == Math.Floor((Math.Round(d.data.timeSlot[0] / 10) * 10) / 50) * 50);

				if (findPf == null)
				{
					pfList.Add(new PowerFrequency(Math.Floor((Math.Round(d.data.timeSlot[0] / 10) * 10) / 50) * 50));
				} else
				{
					findPf.IncFrequency();
				}
			});

			pfList.Sort();
			pfList.ForEach((pf) =>
			{
				Console.WriteLine(pf.ToString());
			});

			this.powerFrequencies = pfList.ToArray();

			this.changed.Invoke(this, new ModelEventArgs(VIEW_ACTIONS.REQUEST_DAYDATA, this.dayStore[DateUtils.KRDayToIndex(dayFullName)].ToArray(), this.powerFrequencies));
		}
	}
}
