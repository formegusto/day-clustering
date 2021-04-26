using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayClustering.common
{
	public static class VIEW_ACTIONS
	{
		public const string CHANGE_KEYWORD = "change_keyword";
		public const string REQUEST_DAYDATA = "request_daydata";
	}

	public static class MODEL_ACTIONS
	{
		public const string LOAD_EXCEL = "load_excel/pending";
		public const string LOAD_EXCEL_SUCCESS = "load_excel/sucess";
		public const string LOAD_EXCEL_FAILURE = "load_excel/failure";
		public const string LOAD_EXCEL_NOT_FOUND = "load_excel/notfound";
	}
}
