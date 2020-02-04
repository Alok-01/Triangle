using System;
using System.Collections;
using System.Collections.Generic;


namespace Triangle.Common.CommonModel
{
	public class ResponseModel<T>
	{
		public string Token { get; set; }
		public bool ReturnStatus { get; set; }
		public List<String> ReturnMessage { get; set; }
		public Hashtable Errors;
		public int TotalPages;
		public int TotalRows;
		public int PageSize;
		public Boolean IsAuthenicated;
		public T Entity;

		public ResponseModel()
		{
			ReturnMessage = new List<String>();
			ReturnStatus = true;
			Errors = new Hashtable();
			TotalPages = 0;
			TotalPages = 0;
			PageSize = 0;
			IsAuthenicated = false;
		}
	}
}
