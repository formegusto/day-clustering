namespace DayClustering
{
	partial class Component
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.Sat = new System.Windows.Forms.Button();
			this.Fri = new System.Windows.Forms.Button();
			this.Thu = new System.Windows.Forms.Button();
			this.Wed = new System.Windows.Forms.Button();
			this.Tue = new System.Windows.Forms.Button();
			this.Mon = new System.Windows.Forms.Button();
			this.Sun = new System.Windows.Forms.Button();
			this.EnergyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.EnergyChart)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.EnergyChart, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 761);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.textBox1.Location = new System.Drawing.Point(3, 694);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(1178, 43);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 7;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel2.Controls.Add(this.Sat, 6, 0);
			this.tableLayoutPanel2.Controls.Add(this.Fri, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.Thu, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.Wed, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.Tue, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.Mon, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.Sun, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(1184, 43);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// Sat
			// 
			this.Sat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Sat.Location = new System.Drawing.Point(1017, 3);
			this.Sat.Name = "Sat";
			this.Sat.Size = new System.Drawing.Size(164, 37);
			this.Sat.TabIndex = 6;
			this.Sat.Text = "토요일";
			this.Sat.UseVisualStyleBackColor = true;
			this.Sat.Click += new System.EventHandler(this.Button_Action);
			// 
			// Fri
			// 
			this.Fri.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Fri.Location = new System.Drawing.Point(848, 3);
			this.Fri.Name = "Fri";
			this.Fri.Size = new System.Drawing.Size(163, 37);
			this.Fri.TabIndex = 5;
			this.Fri.Text = "금요일";
			this.Fri.UseVisualStyleBackColor = true;
			this.Fri.Click += new System.EventHandler(this.Button_Action);
			// 
			// Thu
			// 
			this.Thu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Thu.Location = new System.Drawing.Point(679, 3);
			this.Thu.Name = "Thu";
			this.Thu.Size = new System.Drawing.Size(163, 37);
			this.Thu.TabIndex = 4;
			this.Thu.Text = "목요일";
			this.Thu.UseVisualStyleBackColor = true;
			this.Thu.Click += new System.EventHandler(this.Button_Action);
			// 
			// Wed
			// 
			this.Wed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Wed.Location = new System.Drawing.Point(510, 3);
			this.Wed.Name = "Wed";
			this.Wed.Size = new System.Drawing.Size(163, 37);
			this.Wed.TabIndex = 3;
			this.Wed.Text = "수요일";
			this.Wed.UseVisualStyleBackColor = true;
			this.Wed.Click += new System.EventHandler(this.Button_Action);
			// 
			// Tue
			// 
			this.Tue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Tue.Location = new System.Drawing.Point(341, 3);
			this.Tue.Name = "Tue";
			this.Tue.Size = new System.Drawing.Size(163, 37);
			this.Tue.TabIndex = 2;
			this.Tue.Text = "화요일";
			this.Tue.UseVisualStyleBackColor = true;
			this.Tue.Click += new System.EventHandler(this.Button_Action);
			// 
			// Mon
			// 
			this.Mon.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Mon.Location = new System.Drawing.Point(172, 3);
			this.Mon.Name = "Mon";
			this.Mon.Size = new System.Drawing.Size(163, 37);
			this.Mon.TabIndex = 1;
			this.Mon.Text = "월요일";
			this.Mon.UseVisualStyleBackColor = true;
			this.Mon.Click += new System.EventHandler(this.Button_Action);
			// 
			// Sun
			// 
			this.Sun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Sun.Location = new System.Drawing.Point(3, 3);
			this.Sun.Name = "Sun";
			this.Sun.Size = new System.Drawing.Size(163, 37);
			this.Sun.TabIndex = 0;
			this.Sun.Text = "일요일";
			this.Sun.UseVisualStyleBackColor = true;
			this.Sun.Click += new System.EventHandler(this.Button_Action);
			// 
			// EnergyChart
			// 
			chartArea1.Name = "ChartArea1";
			this.EnergyChart.ChartAreas.Add(chartArea1);
			this.EnergyChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.EnergyChart.Legends.Add(legend1);
			this.EnergyChart.Location = new System.Drawing.Point(3, 43);
			this.EnergyChart.Name = "EnergyChart";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.EnergyChart.Series.Add(series1);
			this.EnergyChart.Size = new System.Drawing.Size(1178, 645);
			this.EnergyChart.TabIndex = 2;
			this.EnergyChart.Text = "일요일 차트 데이터";
			// 
			// Component
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 761);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Component";
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.EnergyChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button Sat;
		private System.Windows.Forms.Button Fri;
		private System.Windows.Forms.Button Thu;
		private System.Windows.Forms.Button Wed;
		private System.Windows.Forms.Button Tue;
		private System.Windows.Forms.Button Mon;
		private System.Windows.Forms.Button Sun;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataVisualization.Charting.Chart EnergyChart;
	}
}

