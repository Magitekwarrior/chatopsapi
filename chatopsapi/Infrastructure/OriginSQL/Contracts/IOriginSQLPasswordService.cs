using Microsoft.AspNetCore.Http;

namespace chatopsapi.Infrastructure.OriginSQL.Contracts
{
  public interface IOriginSQLPasswordService
  {
    string GetOriginSQLPasswordHeaderFieldName();

    string GetOriginSQLPasswordForContext();

    void AddOriginSQLPasswordToContext(HttpContext context);
  }
}
