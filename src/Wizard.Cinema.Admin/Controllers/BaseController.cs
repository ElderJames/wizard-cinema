using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Helpers;

namespace Wizard.Cinema.Admin.Controllers
{
    public class BaseController : ControllerBase
    {
        public new OkObjectResult Ok()
        {
            return base.Ok(Anonymous.ApiResult(ResultStatus.SUCCESS, true));
        }

        public override OkObjectResult Ok(object value)
        {
            return base.Ok(Anonymous.ApiResult(ResultStatus.SUCCESS, value));
        }

        public IActionResult Fail(string msg)
        {
            return new JsonResult(Anonymous.ApiResult<object>(ResultStatus.FAIL, msg));
        }

        public IActionResult Json(object value)
        {
            return new JsonResult(value);
        }

        private CurrentUser _currentUser;

        protected CurrentUser CurrentUser => _currentUser ?? (_currentUser = new CurrentUser(User.Identity));
    }
}
