using System.Threading.Tasks;

namespace chatopsapi.Service.Contracts
{
	public interface ITestService
	{
		Task<string> GetRedisCacheTestKeyValue(string key);
		Task<bool> SaveRedisCacheTestKeyValue(string key, string Value);
		Task<bool> DeleteRedisCacheTestKey(string key);

	}
}
