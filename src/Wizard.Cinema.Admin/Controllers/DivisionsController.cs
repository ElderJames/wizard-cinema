using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Spider.Response;
using Wizard.Infrastructures;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : BaseController
    {
        private readonly IDivisionService _divisionService;

        private readonly CityService _cityService;

        public DivisionsController(CityService cityService, IDivisionService divisionService)
        {
            this._cityService = cityService;
            this._divisionService = divisionService;
        }

        public IActionResult Create(CreateDivisionModel model)
        {
            CityResponse.City city = _cityService.GetById((int)model.CityId);

            if (city == null)
                return Fail("请选择正确的城市");

            ApiResult<bool> result = _divisionService.CreateDivision(new CreateDivisionReqs()
            {
                CityId = model.CityId,
                Name = model.Name,
                CreatorId = CurrentUser.UserId,
            });

            if (result.Status != ResultStatus.SUCCESS)
                return Fail(result.Message);

            return Ok();
        }

        public IActionResult GetById(long id)
        {
            if (id <= 0)
                return Fail("请提交正确的数据");

            ApiResult<DivisionResp> result = _divisionService.GetById(id);

            if (result.Status != ResultStatus.SUCCESS)
                return Fail(result.Message);

            return Ok(result.Result);
        }
    }
}
