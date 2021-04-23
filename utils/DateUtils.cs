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
	}
}
