using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
	public class CryptionHander
	{
		private static readonly string _keyString = "b14ca5898a4e4133bbce2ea2315a1916";
		public static string EncryptString(string text)
		{
			byte[] iv = new byte[16];
			byte[] array;
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(_keyString);
				aes.IV = iv;
				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
						{
							streamWriter.Write(text);
						}

						array = memoryStream.ToArray();
					}
				}
			}

			return Convert.ToBase64String(array);
		}

		public static string DecryptString(string cipherText)
		{
			byte[] iv = new byte[16];
			byte[] buffer = Convert.FromBase64String(cipherText);
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(_keyString);
				aes.IV = iv;
				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
						{
							return streamReader.ReadToEnd();
						}
					}
				}
			}
		}
		public static string GetMd5Hash(string input)
		{
			using (MD5 md5Hash = MD5.Create())
			{
				// Convert the input string to a byte array and compute the hash.
				byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
				StringBuilder sBuilder = new StringBuilder();
				for (int i = 0; i < data.Length; i++)
				{
					sBuilder.Append(data[i].ToString("x2"));
				}
				return sBuilder.ToString();
			}
		}
		public static string ComputeSHA256Hash(string input)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				// Chuyển đổi chuỗi đầu vào thành mảng byte
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);
				// Tính toán băm
				byte[] hashBytes = sha256.ComputeHash(inputBytes);

				// Chuyển đổi mảng byte thành chuỗi hex
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("x2")); // Biến đổi thành định dạng hex
				}
				return sb.ToString();
			}
		}
	}
}
