using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;
using System.Linq.Expressions;

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
			await sql.InsertAllWithChildrenAsync(orders);

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

