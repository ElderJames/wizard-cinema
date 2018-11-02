using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Models;

namespace Wizard.Cinema.Web.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly HallService _hallService;

        public CinemaController(HallService hallService)
        {
            this._hallService = hallService;
        }

        [HttpGet("halls/{hallId:int}")]
        public IActionResult Hall(int hallId)
        {
            if (hallId <= 0)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "请选择影厅"));

            Hall hall = _hallService.GetById(hallId);
            if (hall == null)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "影厅不存在"));

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, hall));
        }
    }
}
