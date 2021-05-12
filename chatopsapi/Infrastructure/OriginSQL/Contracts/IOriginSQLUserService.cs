using Microsoft.AspNetCore.Http;

namespace chatopsapi.Infrastructure.OriginSQL.Contracts
{
  public interface IOriginSQLUserService
  {
    string GetOriginSQLUserHeaderFieldName();

    string GetOriginSQLUserForContext();

    void AddOriginSQLUserToContext(HttpContext context);
  }
}
