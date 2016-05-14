using System;
namespace RealmVsSqliteCompare.Droid
{
	public class FileAccessHelper
	{
		public static string GetLocalFilePath(string filename)
		{
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			return System.IO.Path.Combine(path, filename);
		}
	}
}

