using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class ResponseModel
	{
		public bool IsSuccess { get; set; }
		public string? Messsage { get; set; }
		public object? Data { get; set; }
		public int? Code { get; set; }

		public static ResponseModel Success(object? data = null, string message = "Thành công !")
		{
			return new ResponseModel
			{
				Data = data,
				Code = 1,
				IsSuccess = true,
				Messsage = message
			};
		}

		public static ResponseModel Error(object? data = null, string message = "Thất bại !")
		{
			return new ResponseModel
			{
				Data = data,
				Code = 0,
				IsSuccess = false,
				Messsage = message
			};
		}

		public static ResponseModel Error(int code, object? data = null, string message = "Thất bại !")
		{
			return new ResponseModel
			{
				Data = data,
				Code = code,
				IsSuccess = false,
				Messsage = message
			};
		}
		public static ResponseModel Error(string message = "Thất bại !")
		{
			return new ResponseModel
			{
				Data = null,
				Code = 0,
				IsSuccess = false,
				Messsage = message
			};
		}
	}

}
