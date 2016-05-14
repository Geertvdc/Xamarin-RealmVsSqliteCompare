using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SQLite.Net;
using SQLite.Net.Attributes;

using SQLite.Net.Async;
using UIKit;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;

namespace RealmVsSqliteCompare.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			string dbPath = FileAccessHelper.GetLocalFilePath("orders.db3");

			//var connectionString = new SQLiteConnectionString(dbPath, false);
			//var platform = new SQLitePlatformIOS();
			//var connectionWithLock = new SQLiteConnectionWithLock(platform, connectionString);
			//var connection = new SQLiteAsyncConnection(() => connectionWithLock);

			var platform = new SQLitePlatformIOS();
			var param = new SQLiteConnectionString(dbPath, false);
			var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, param));

			LoadApplication(new App(connection));

			return base.FinishedLaunching(app, options);
		}

	}

}

