using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Helpers
{
	public class FileHelper
	{
		public static async Task<bool> DeleteFilesAsync(List<string> listFullPath)
		{
			const int BatchSize = 100;
			const int MaxDegreeOfParallelism = 5; // Giới hạn số lượng task song song trong mỗi batch
			StringBuilder log = new StringBuilder();

			// Kiểm tra toàn bộ danh sách file trước khi xóa
			foreach (var filePath in listFullPath)
			{
				if (File.Exists(filePath) && !CanDeleteFile(filePath))
				{
					log.AppendLine($"[ERROR] Không thể xóa file: {filePath}");
					Console.WriteLine(log.ToString());
					return false; // Nếu bất kỳ file nào không thể xóa, hủy bỏ toàn bộ
				}
			}

			// Xóa file theo batch
			for (int i = 0; i < listFullPath.Count; i += BatchSize)
			{
				var batch = listFullPath.Skip(i).Take(BatchSize).ToList();
				var tasks = batch.Select(filePath => DeleteWithRetryAsync(filePath)).ToList();

				var results = await Task.WhenAll(tasks); // Xử lý đồng thời các file trong batch

				// Kiểm tra kết quả của từng task
				if (results.Any(result => !result))
				{
					log.AppendLine($"[ERROR] Một số file không thể xóa trong batch từ {i} đến {i + BatchSize}");
					Console.WriteLine(log.ToString());
					return false;
				}
			}

			Console.WriteLine("[SUCCESS] Tất cả file đã được xóa thành công.");
			return true;
		}

		private static async Task<bool> DeleteWithRetryAsync(string fullPath)
		{
			const int MaxRetry = 3;

			for (int attempt = 1; attempt <= MaxRetry; attempt++)
			{
				try
				{
					File.Delete(fullPath);
					return true;
				}
				catch (IOException ex)
				{
					if (attempt < MaxRetry)
					{
						await Task.Delay(100); // Chờ 100ms trước khi thử lại
					}
					else
					{
						Console.WriteLine($"[ERROR] Không thể xóa file {fullPath} sau {MaxRetry} lần thử: {ex.Message}");
					}
				}
			}

			return false;
		}

		private static bool CanDeleteFile(string filePath)
		{
			try
			{

				using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
				{

					return true;
				}
			}
			catch (IOException)
			{
				return false;
			}
			catch (UnauthorizedAccessException)
			{
				return false;  // Không có quyền truy cập
			}
		}
	}
}
