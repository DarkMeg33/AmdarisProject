using System.Net;

namespace AmdarisProject.Common.Exeptions
{
    public class ConflictException : ApiException
    {
        public ConflictException(string message) : base(HttpStatusCode.Conflict, message)
        {
        }
    }
}
