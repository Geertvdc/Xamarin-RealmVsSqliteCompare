using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealmVsSqliteCompare
{
	public class RealmService : IDbService
	{
		public RealmService()
		{
		}

		public Task<T> GetObject<T>(string key)
		{
			throw new NotImplementedException();
		}

		public Task<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys)
		{
			throw new NotImplementedException();
		}

		public Task InsertObject<T>(string key, T value)
		{
			throw new NotImplementedException();
		}

		public Task RemoveObject(string key)
		{
			throw new NotImplementedException();
		}
	}
}

