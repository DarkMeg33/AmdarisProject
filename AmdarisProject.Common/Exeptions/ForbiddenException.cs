using System.Net;

namespace AmdarisProject.Common.Exeptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message) : base(HttpStatusCode.Forbidden, message)
        {
        }
    }
}
