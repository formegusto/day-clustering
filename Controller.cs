using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayClustering.common;

namespace DayClustering
{
	public interface IController
	{
		void Dispatch(string action, Dictionary<string, dynamic> payload = null);
	}

	public class DayClusteringController: IController
	{
		IView view;
		IModel model;

		public void ViewChanged(IView v, ViewEventArgs e)
		{
			Console.WriteLine("[ViewChanged] " + e.action);
			switch(e.action)
			{
				case VIEW_ACTIONS.CHANGE_KEYWORD:
					this.model.ChangeKeyword(e.searchKeyword);
					break;
				default:
					return;
			}
		}

		public DayClusteringController(IView v, IModel m)
		{
			this.view = v;
			this.model = m;
			view.SetController(this);
			model.Attach((IModelObserver)this.view);
			view.changed += new ViewHandler<IView>(this.ViewChanged);
		}

		public void Dispatch(string action, Dictionary<string, dynamic> payload = null)
		{
			Console.WriteLine("[ModelDispatch] " + action);
			switch(action)
			{
				case MODEL_ACTIONS.LOAD_EXCEL:
					this.model.LoadExcel();
					break;
				default:
					return;
			}
		}
	}
}
