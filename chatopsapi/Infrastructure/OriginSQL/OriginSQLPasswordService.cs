using chatopsapi.Infrastructure.OriginSQL.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatopsapi.Infrastructure.OriginSQL
{
  public class OriginSQLPasswordService : IOriginSQLPasswordService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _originSQLPasswordHeader = "X-Origin-SQLPassword";

    public OriginSQLPasswordService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }
    public void AddOriginSQLPasswordToContext(HttpContext context)
    {
      context.Response.Headers[_originSQLPasswordHeader] = context.Request.Headers.ContainsKey(_originSQLPasswordHeader)
          ? context.Request.Headers[_originSQLPasswordHeader].ToString()
          : null;
    }

    public string GetOriginSQLPasswordForContext()
    {
      var originSQLPassword = _httpContextAccessor.HttpContext.Response.Headers[_originSQLPasswordHeader].ToString();

      return originSQLPassword;
    }

    public string GetOriginSQLPasswordHeaderFieldName()
    {
      return _originSQLPasswordHeader;
    }
  }
}
