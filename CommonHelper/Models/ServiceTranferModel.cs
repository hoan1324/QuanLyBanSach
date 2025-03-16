using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class ServiceTranferModel<T>
	{
		public ServiceTranferModel(T data, int status, string message)
		{
			Data = data;
			Status = status;
			Message = message;
		}
		public int Status { get; private set; }
		public string? Message { get; private set; }
		public T? Data { get; private set; }

	}
}
