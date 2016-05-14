using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace RealmVsSqliteCompare
{
	public partial class MainPage : ContentPage
	{
		SqlOrderRepository _sqlOrderRepository;
		RealmOrderRepository _realmOrderRepository;

		public MainPage(SqlOrderRepository sqlOrderRepository, RealmOrderRepository realmOrderRepository)
		{
			InitializeComponent();

			_sqlOrderRepository = sqlOrderRepository;
			_realmOrderRepository = realmOrderRepository;
		}

		async void Insert1000OrdersButton_Clicked(object sender, System.EventArgs e)
		{
			List<SqlOrder> orders = new List<SqlOrder>();
			for (int i = 0; i < 1000; i++)
			{
				SqlOrder order = new SqlOrder() { OrderNumber = $"Order{i}", Price = i, Title = $"title {i}"};
				order.OrderLines = new List<SqlOrderLine>();
				for (int j = 0; j < 5; j++)
				{
					order.OrderLines.Add(new SqlOrderLine() { Amount = j, Product = $"Product {i}{j}", UnitPrice = j});
				}
				orders.Add(order);
			}

			var watch = System.Diagnostics.Stopwatch.StartNew();
			await _sqlOrderRepository.InsertOrders(orders);
			watch.Stop();

			TimeResultsEditor.Text += $"inserted 1000 records into Sqlite in {watch.ElapsedMilliseconds} milliseconds\n";
		}

		async void Query100OrdersButton_Clicked(object sender, System.EventArgs e)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();
			var orders = await _sqlOrderRepository.Query<SqlOrder>(o => o.Price >= 900);
			watch.Stop();

			TimeResultsEditor.Text += $"queried {orders.Count} records from Sqlite in {watch.ElapsedMilliseconds} milliseconds\n";
		}

		async void Query1000OrderLinesButton_Clicked(object sender, System.EventArgs e)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();
			var orderLines = await _sqlOrderRepository.Query<SqlOrderLine>(l => l.Amount == 2);
			watch.Stop();

			TimeResultsEditor.Text += $"queried {orderLines.Count} records from Sqlite in {watch.ElapsedMilliseconds} milliseconds\n";
		}

		async void Update100OrdersButton_Clicked(object sender, System.EventArgs e)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();
			var orders = await _sqlOrderRepository.Query<SqlOrder>(o => o.Price >= 900);
			foreach (var order in orders)
			{
				order.Price += 10000;
			}
			await _sqlOrderRepository.UpdateRecord<SqlOrder>(orders);
			watch.Stop();
			TimeResultsEditor.Text += $"Updated {orders.Count} records in Sqlite in {watch.ElapsedMilliseconds} milliseconds\n";
			watch.Reset();
			watch.Start();
			var updatedOrders = await _sqlOrderRepository.Query<SqlOrder>(o => o.Price >= 10000);
			watch.Stop();

			TimeResultsEditor.Text += $"Queried updated {updatedOrders.Count} records in Sqlite in {watch.ElapsedMilliseconds} milliseconds\n";
		}

	}
}

