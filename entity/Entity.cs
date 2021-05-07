using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayClustering.entity
{
	public class DayData
	{
		public Data cluster;
		public Data data;

		public DayData(Data c, Data d)
		{
			this.cluster = c;
			this.data = d;
		}

		public string ToString(string joinData = "")
		{
			return String.Format("DataInfo\t[UID] {0}\t ClusterInfo\t[UID] {5}\n" +
				"\t\t[mainCluster] {1}\t\t\t[mainCluster] {6}\n" +
				"\t\t[subCluster] {2}\t\t\t[subCluster] {7}\n" +
				"\t\t[Wh] {3}\t\t\t[Wh] {8}\n" +
				"\t\t[timeSlot] {4}\n\t\t[timeSlot] {9}\n" + 
				"{10}",
					this.data.uid, this.data.mainCluster, this.data.subCluster, this.data.Wh, string.Join("/", this.data.timeSlot),
						this.cluster.uid, this.cluster.mainCluster, this.cluster.subCluster, this.cluster.Wh, string.Join("/", this.cluster.timeSlot),
						joinData
				);
		}
	}

	public class Data
	{
		public string uid;
		public int mainCluster;
		public int subCluster;
		public double Wh;
		public double[] timeSlot;

		public Data(List<string> line)
		{
			this.uid = line[0];
			this.mainCluster = int.Parse(line[1]);
			this.subCluster = int.Parse(line[2]);
			this.Wh = double.Parse(line[3]);
			this.timeSlot = line.GetRange(4, line.Count - 4).Select(l => double.Parse(l)).ToArray();
		}

		public string ToString()
		{
			return String.Format("[UID] {0}\n" +
				"[mainCluster] {1}\n" +
				"[subCluster] {2}\n" + 
				"[Wh] {3}\n" +
				"[timeSlot] {4}\n"
				, this.uid, this.mainCluster, this.subCluster, this.Wh, string.Join(" / ", this.timeSlot));
		}
	}

	public class PowerFrequency : IComparable
	{
		public double wh;
		public int frequency;

		public PowerFrequency(double wh)
		{
			this.wh = wh;
			this.frequency = 0;
		}

		public void IncFrequency()
		{
			this.frequency++;
		}

		public int CompareTo(object obj)
		{
			if(obj is PowerFrequency)
				return this.wh.CompareTo((obj as PowerFrequency).wh);
			throw new ArgumentException("Object is not a PowerFrequency");
		}
	}
}
