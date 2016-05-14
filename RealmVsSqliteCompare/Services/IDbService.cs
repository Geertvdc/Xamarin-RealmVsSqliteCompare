using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealmVsSqliteCompare
{
	public interface IDbService
	{
		Task<T> GetObject<T>(string key);
		Task InsertObject<T>(string key, T value);
		Task RemoveObject(string key);
		Task<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys);
	}
}

