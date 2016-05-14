using System;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace RealmVsSqliteCompare
{
	public class SqlOrderLine
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[ForeignKey(typeof(SqlOrder))]
		public int OrderId { get; set; }

		[ManyToOne]
		public SqlOrder Order { get; set; }

		public string Product { get; set; }
		public int Amount { get; set; }
		public double UnitPrice { get; set; }

	}
}

