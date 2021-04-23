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
using Microsoft.Office.Interop.Excel;

namespace DayClustering
{
	public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);

	public class ModelEventArgs: EventArgs
	{
		public string action;
		public string cluster;
		public string search;

		public ModelEventArgs(string a)
		{
			this.action = a;
		}

		public ModelEventArgs(string a, string c, string s)
		{
			this.action = a;
			this.cluster = c;
			this.search = s;
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

		public DayClusteringModel() {
			this.searchKeyword = "";
		}

		public void Attach(IModelObserver imo)
		{
			this.changed += new ModelHandler<DayClusteringModel>(imo.ModelNotify);
		}

		public async void LoadExcel()
		{
			DateTime startDate = new DateTime(2018,12,1);
			DateTime endDate = new DateTime(2018, 12, 31);

			for (DateTime sd = startDate; sd <= startDate; sd = sd.AddDays(1))
			{
				string path = System.Windows.Forms.Application.StartupPath + @"\data\clustering_" + sd.ToString("yyyyMMdd") + ".csv";
				StreamReader sr = new StreamReader(path, Encoding.GetEncoding("euc-kr"));
				string cluster = "";
				Console.WriteLine(String.Format("--------{0}--------", DateUtils.DayToKR(sd)));
				while (!sr.EndOfStream)
				{
					string line = await sr.ReadLineAsync();
					string uid = line.Split(',')[0];

					if (uid.Contains("cluster"))
						cluster = uid;
					Console.WriteLine(uid);
					if (uid == this.searchKeyword)
					{
						this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTIONS.LOAD_EXCEL_SUCCESS, cluster, uid));
						return;
					}
				}

				sr.Close();
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTIONS.LOAD_EXCEL_NOT_FOUND));
			}
		}

		public void ChangeKeyword(string keyword)
		{
			Console.WriteLine("[Model: ChangeKeyword] " + keyword);
			this.searchKeyword = keyword;
		}
	}
}
