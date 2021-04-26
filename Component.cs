using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DayClustering.common;

namespace DayClustering
{
	public partial class Component : Form, IView, IModelObserver
	{
		public event ViewHandler<IView> changed;
		IController controller;
		public Component()
		{
			InitializeComponent();
		}

		public void SetController(IController controller)
		{
			this.controller = controller;
		}

		public void ModelNotify(IModel model, ModelEventArgs e)
		{
			switch (e.action)
			{
				case MODEL_ACTIONS.LOAD_EXCEL_SUCCESS:
					// MessageBox.Show(String.Format("{0} 클러스터에 {1} 존재합니다!",e.cluster, e.search));
					Console.WriteLine();
					break;
				case MODEL_ACTIONS.LOAD_EXCEL_NOT_FOUND:
					MessageBox.Show("검색 결과가 존재하지 않습니다!");
					break;
				default:
					return;
			}
		}

		private void TextBox1_TextChanged(object sender, EventArgs e) => this.changed(this, new ViewEventArgs(VIEW_ACTIONS.CHANGE_KEYWORD, textBox1.Text));

		private void TextBox1_KeyDown(object sender, KeyEventArgs e) {
			int v = e.KeyValue;

			if(v == 13)
				this.controller.Dispatch(MODEL_ACTIONS.LOAD_EXCEL);
		}

		private void Button_Action(object sender, EventArgs e) => this.changed(this, new ViewEventArgs(VIEW_ACTIONS.REQUEST_DAYDATA, "",((Button)sender).Text));
	}
}
