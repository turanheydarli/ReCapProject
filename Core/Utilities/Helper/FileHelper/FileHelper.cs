using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
	public class FileHelper : IFileHelper
	{
		public void Delete(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

		public string Save(IFormFile file, string folder)
		{
			string fileName = Guid.NewGuid().ToString() + "." + file.ContentType.Split("/")[1];
			string fullPath = Path.Combine(folder, fileName);

			using(FileStream fileStream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(fileStream);
				fileStream.Flush();
				return fileName;
			}
		}

		public string Update(IFormFile file, string folder, string oldFile)
		{
			Delete(Path.Combine(folder, oldFile));
			return Save(file, folder);
		}
	}
}
