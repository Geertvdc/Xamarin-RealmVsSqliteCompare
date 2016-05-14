using System;
namespace RealmVsSqliteCompare.iOS
{
	public class FileAccessHelper
	{
		public static string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

			if (!System.IO.Directory.Exists(libFolder))
			{
				System.IO.Directory.CreateDirectory(libFolder);
			}

			return System.IO.Path.Combine(libFolder, filename);
		}
	}
}

