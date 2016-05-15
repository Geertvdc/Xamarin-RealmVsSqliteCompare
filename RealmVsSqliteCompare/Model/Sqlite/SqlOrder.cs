using System;
using System.Collections.Generic;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace RealmVsSqliteCompare
{
	public class SqlOrder
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string OrderNumber { get; set; }

		public string Title { get; set; }
		public double Price { get; set; }

		[OneToMany(CascadeOperations=CascadeOperation.All)]
		public List<SqlOrderLine> OrderLines {get;set;}

	}
}

