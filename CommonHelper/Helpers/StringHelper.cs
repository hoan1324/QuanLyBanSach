using CommonHelper.Constant;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonHelper.Helpers
{
	public static class StringHelper
	{
		public static string GetOperator(string operatorInput)
		{
			var method = FilterOperator.ListOperator.FirstOrDefault(x => x.Operator == operatorInput);
			if (method != null)
			{
				return method.Method;
			}
			return null;
		}
		public static string RemoveVietnameseDiacritics(string text)
		{
			if (string.IsNullOrEmpty(text)) return "";
			string normalizedText = text.Normalize(NormalizationForm.FormD);
			StringBuilder sb = new StringBuilder();

			foreach (char c in normalizedText)
			{
				UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
				if (uc != UnicodeCategory.NonSpacingMark)
				{
					sb.Append(c);
				}
			}

			return sb.ToString().Normalize(NormalizationForm.FormC);
		}

		public static string ReplaceSpacesWithHyphens(string text)
		{
			if (string.IsNullOrEmpty(text)) return "";
			// Thay thế các khoảng trắng liên tiếp bằng dấu gạch ngang
			text = Regex.Replace(text, @"\s+", "-");
			text = Regex.Replace(text, @"-+", "-");
			return text;
		}
		public static string RemoveSpecialCharacters(string text)
		{
			if (string.IsNullOrEmpty(text)) return "";
			// Chỉ giữ lại các ký tự chữ và số và dấu gạch ngang
			text = Regex.Replace(text, @"[^a-zA-Z0-9\-]", "");
			text = Regex.Replace(text, @"-+", "-");
			return text;
		}
		public static string BuildNewsUnsignName(string text)
		{
			if (string.IsNullOrEmpty(text)) return "";
			text = RemoveVietnameseDiacritics(text);
			text = ReplaceSpacesWithHyphens(text);
			text = RemoveSpecialCharacters(text);
			return $"{text.ToLower()}";
		}
		public static string RandomString(int length)
		{
			var _random = new Random();
			const string chars = "qwertyuiopasdfghjklzxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!*_-";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[_random.Next(s.Length)]).ToArray());
		}
	}
}
