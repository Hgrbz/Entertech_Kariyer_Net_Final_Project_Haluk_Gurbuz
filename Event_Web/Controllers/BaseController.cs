using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event_Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
