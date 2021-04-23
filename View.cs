using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayClustering
{
	public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

	public class ViewEventArgs: EventArgs
	{
		public string action;
		public string searchKeyword;

		public ViewEventArgs()
		{

		}

		public ViewEventArgs(string a, string sk)
		{
			this.action = a;
			this.searchKeyword = sk;
		}
	}

	public interface IView
	{
		event ViewHandler<IView> changed;
		void SetController(IController controller);
	}
}
