using System;
using System.Collections.Generic;
using Realms;

namespace RealmVsSqliteCompare
{
	public class RealmOrder : RealmObject
	{

		public int Id { get; set; }
		public string OrderNumber { get; set; }

		public string Title { get; set; }
		public double Price { get; set; }

		public RealmList<RealmOrderLine> OrderLines {get;}

	}
}

