using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper
{
	public interface IFileHelper
	{
		string Save(IFormFile file, string folder);
		string Update(IFormFile file, string folder, string oldFile);
		void Delete(string filePath);
	}
}
