using System.Net;

namespace AmdarisProject.Common.Exeptions
{
    public class ServiceUnaviableException : ApiException
    {
        public ServiceUnaviableException(string message) : base(HttpStatusCode.ServiceUnavailable, message)
        {
        }
    }
}
