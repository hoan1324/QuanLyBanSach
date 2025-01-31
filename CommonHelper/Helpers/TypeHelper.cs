using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Helpers
{
	public class TypeHelper
	{
		public static void NormalMapping<T>(T source, T destination, params string[] ignoreFields)
		{
			PropertyInfo[] sourceProperties = typeof(T).GetProperties();
			foreach (var sourceProp in sourceProperties)
			{
				if (sourceProp.CanWrite)
				{
					if (ignoreFields.Length <= 0 || !ignoreFields.Contains(sourceProp.Name))
					{
						sourceProp.SetValue(destination, sourceProp.GetValue(source));
					}
				}
			}
		}
	}
}
