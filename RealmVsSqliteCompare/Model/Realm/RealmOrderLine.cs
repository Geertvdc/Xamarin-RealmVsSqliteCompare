using System;
using Realms;

namespace RealmVsSqliteCompare
{
	public class RealmOrderLine : RealmObject
	{
		
		public int Id { get; set; }

		public RealmOrder Order { get; set; }

		public string Product { get; set; }
		public int Amount { get; set; }
		public double UnitPrice { get; set; }

	}
}

