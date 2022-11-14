using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
    }
}
