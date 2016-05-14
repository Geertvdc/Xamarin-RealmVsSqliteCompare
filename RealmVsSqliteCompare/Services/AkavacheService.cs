//using System;
//using System.Threading.Tasks;
//using System.Reactive.Linq;
//using System.Collections.Generic;

//namespace RealmVsSqliteCompare
//{
//	public class AkavacheService : IDbService
//	{
//		public AkavacheService()
//		{
//			BlobCache.ApplicationName = "RealmVsSqliteCompare";
//		}

//		public async Task<T> GetObject<T>(string key)
//		{
//			try
//			{
//				return await BlobCache.LocalMachine.GetObject<T>(key);
//			}
//			catch (KeyNotFoundException)
//			{
//				return default(T);
//			}
//		}

//		public async Task InsertObject<T>(string key, T value)
//		{
//			await BlobCache.LocalMachine.InsertObject(key, value);
//		}

//		public async Task InsertObjects<T>(IDictionary<string,T> values)
//		{
//			await BlobCache.LocalMachine.InsertObjects(values);
//		}

//		public async Task RemoveObject(string key)
//		{
//			await BlobCache.LocalMachine.Invalidate(key);
//		}

//		public async Task<IDictionary<string,T>> GetObjects<T>(IEnumerable<string> keys)
//		{
//			return await BlobCache.LocalMachine.GetObjects<T>(keys,false);
			
//		}

//	}
//}

