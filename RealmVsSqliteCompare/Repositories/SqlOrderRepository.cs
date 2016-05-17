using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;

namespace RealmVsSqliteCompare
{
	public class SqlOrderRepository
	{
		private readonly SQLiteAsyncConnection sql;

		public SqlOrderRepository(SQLiteAsyncConnection sqlCon)
		{
			sql = sqlCon;

			sql.DropTableAsync<SqlOrder>().Wait();
			sql.CreateTableAsync<SqlOrder>().Wait();

			sql.DropTableAsync<SqlOrderLine>().Wait();
			sql.CreateTableAsync<SqlOrderLine>().Wait();
		}

		public async Task InsertOrder(SqlOrder order)
		{
			await sql.InsertWithChildrenAsync(order);

		}

		public async Task InsertOrders(IEnumerable<SqlOrder> orders)
		{
			//really slow easy way
			//await sql.RunInTransactionAsync((SQLiteConnection conn) =>
			//{
			//	conn.InsertAllWithChildren(orders);
			//});


			//faster way
			await sql.RunInTransactionAsync((SQLiteConnection conn) =>
			{
				conn.InsertAll(orders);

				// map order id's to orderlines for FK
				var lines = orders.SelectMany(o =>
				{
					foreach (SqlOrderLine l in o.OrderLines)
					{
						l.OrderId = o.Id;
						l.Order = o;
					}
					return o.OrderLines;
				});

				conn.InsertAll(lines);
			});
		}

		public async Task<SqlOrder> GetOrderById(int id)
		{
			return await sql.GetWithChildrenAsync<SqlOrder>(id);
		}


		public async Task<SqlOrder> GetOrderByOrderNumber(string orderNumber)
		{
			return await sql.Table<SqlOrder>().Where(o => o.OrderNumber == orderNumber).FirstOrDefaultAsync();
		}

		public async Task<List<T>> Query<T>(Expression<Func<T,bool>> query) where T : class
		{
			return await sql.GetAllWithChildrenAsync<T>(query);

		}

		public async Task UpdateRecord<T>(List<T> records) where T : class
		{
			var updated = await sql.UpdateAllAsync(records);
		}
	}
}

