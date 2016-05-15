using System;
using SQLite.Net.Async;
using Xamarin.Forms;

namespace RealmVsSqliteCompare
{
	public class App : Application
	{
		SqlOrderRepository _sqlOrderRepository;

		public App(SQLiteAsyncConnection sqlCon)
		{
			_sqlOrderRepository = new SqlOrderRepository(sqlCon);
			MainPage = new MainPage(_sqlOrderRepository);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

