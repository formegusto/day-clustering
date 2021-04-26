using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayClustering.utils
{
	public class DateUtils
	{
		public static string DayToKR(DateTime src)
		{
			string day = "";

			switch (src.DayOfWeek)
			{
				case DayOfWeek.Monday:
					day = "월";
					break;
				case DayOfWeek.Tuesday:
					day = "화";
					break;
				case DayOfWeek.Wednesday:
					day = "수";
					break;
				case DayOfWeek.Thursday:
					day = "목";
					break;
				case DayOfWeek.Friday:
					day = "금";
					break;
				case DayOfWeek.Saturday:
					day = "토";
					break;
				case DayOfWeek.Sunday:
					day = "일";
					break;
			}

			return day;
		}

		public static int DayToIndex(DateTime src)
		{
			int idx = 0;

			switch (src.DayOfWeek)
			{
				case DayOfWeek.Monday:
					idx = 1;
					break;
				case DayOfWeek.Tuesday:
					idx = 2;
					break;
				case DayOfWeek.Wednesday:
					idx = 3;
					break;
				case DayOfWeek.Thursday:
					idx = 4;
					break;
				case DayOfWeek.Friday:
					idx = 5;
					break;
				case DayOfWeek.Saturday:
					idx = 6;
					break;
				case DayOfWeek.Sunday:
					idx = 0;
					break;
			}

			return idx;
		}

		public static int KRDayToIndex(string src)
		{
			int idx = 0;

			switch (src)
			{
				case "월요일":
					idx = 1;
					break;
				case "화요일":
					idx = 2;
					break;
				case "수요일":
					idx = 3;
					break;
				case "목요일":
					idx = 4;
					break;
				case "금요일":
					idx = 5;
					break;
				case "토요일":
					idx = 6;
					break;
				case "일요일":
					idx = 0;
					break;
			}

			return idx;
		}
	}
}
