using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DayClustering.entity;

namespace DayClustering.atom
{
	public partial class EnergyGraph : UserControl
	{
		public DayData[] dayData;

		static Pen clusterPen = new Pen(Color.FromArgb(64,0,0,255), 1);
		static Pen dataPen = new Pen(Color.FromArgb(16, 0, 255, 0), 2);

		Bitmap bitmap;

		public EnergyGraph()
		{
			Margin = new Padding(10);
			Cursor = Cursors.Hand;
			Dock = DockStyle.Fill;
			BackColor = Color.White;
		}

		public void DrawBitmap()
		{
			this.bitmap = new Bitmap(Width, Height);
			Graphics g = Graphics.FromImage(bitmap);

			Console.WriteLine(Width);
			Console.WriteLine(Height);

			float heightRatio = Height / (float)5000;
			Point[][] point_data = new Point[dayData.Length][];
			for (int i = 0; i < point_data.Length; i++)
				point_data[i] = new Point[dayData[0].data.timeSlot.Length];
			Parallel.For(0, point_data.Length, (i) =>
			{
				for (int e = 0; e < point_data[i].Length; e++)
					point_data[i][e] = new Point(e * Width / (dayData[i].data.timeSlot.Length - 1), Height - 1 - (int)(dayData[i].data.timeSlot[e] * Height / 5000));
			});

			for (int h = 1; h < 4; h++)
				for (int w = 0; w < Width - 40; w += 100)
				{
					g.DrawLine(Pens.LightGray, w, h * Height / 4, w + 4, h * Height / 4);
				}

			for (int i = 0; i < dayData.Length; i++)
				g.DrawLines(dataPen, point_data[i]);

			Point[][] point_cluster = new Point[dayData.Length][];
			for (int i = 0; i < point_cluster.Length; i++)
				point_cluster[i] = new Point[dayData[0].cluster.timeSlot.Length];
			Parallel.For(0, point_cluster.Length, (i) =>
			{
				for (int e = 0; e < point_data[i].Length; e++)
					point_cluster[i][e] = new Point(e * Width / (dayData[i].cluster.timeSlot.Length - 1), Height - 1 - (int)(dayData[i].cluster.timeSlot[e] * Height / 5000));
			});
			for (int i = 0; i < dayData.Length; i++)
				g.DrawLines(clusterPen, point_cluster[i]);

			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs p)
		{
			base.OnPaint(p);
			if (bitmap != null)
				p.Graphics.DrawImage(bitmap, 0, 0);
		}
	}


}
