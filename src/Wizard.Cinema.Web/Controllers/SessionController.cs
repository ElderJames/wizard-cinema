using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Web.Models;

namespace Wizard.Cinema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public IActionResult Select(SelectSeatModel model)
        {
            return Ok();
        }
    }
}
