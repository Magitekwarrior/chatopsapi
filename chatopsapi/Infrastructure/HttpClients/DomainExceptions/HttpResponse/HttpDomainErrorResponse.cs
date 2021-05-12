namespace chatopsapi.Infrastructure.DomainExceptions.HttpResponse
{
  public class HttpDomainErrorResponse
  {
    public Error Error { get; set; }
  }

  public class Error
  {
    public string ErrorMessage { get; set; }
  }
}
