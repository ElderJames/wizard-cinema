using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request;
using Wizard.Cinema.Application.DTOs.Request.Division;
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
    public class DivisionController : BaseController
    {
        private readonly IDivisionService _divisionService;

        private readonly CityService _cityService;

        public DivisionController(CityService cityService, IDivisionService divisionService)
        {
            this._cityService = cityService;
            this._divisionService = divisionService;
        }

        [HttpPost]
        public IActionResult Create(DivisionModel model)
        {
            CityResponse.City city = _cityService.GetById((int)model.CityId);

            if (city == null)
                return Fail("请选择正确的城市");

            if (!model.DivisionId.HasValue || model.DivisionId <= 0)
            {
                ApiResult<bool> result = _divisionService.CreateDivision(new CreateDivisionReqs()
                {
                    CityId = model.CityId,
                    Name = model.Name,
                    CreatorId = CurrentUser.UserId,
                    CreateTime = model.CreateTime
                });

                return Json(result);
            }
            else
            {
                ApiResult<bool> result = _divisionService.ChangeDivision(new ChangeDivisionReqs()
                {
                    DivisionId = model.DivisionId.Value,
                    CityId = model.CityId,
                    Name = model.Name,
                    CreatorId = CurrentUser.UserId,
                    CreateTime = model.CreateTime
                });

                return Json(result);
            }
        }

        public IActionResult GetById(long id)
        {
            if (id <= 0)
                return Fail("请提交正确的数据");

            ApiResult<DivisionResp> result = _divisionService.GetById(id);

            if (result.Status != ResultStatus.SUCCESS)
                return Fail(result.Message);

            return Ok(new
            {
                result.Result.DivisionId,
                result.Result.Name,
                result.Result.CityId,
                result.Result.CreateTime
            });
        }

        [HttpGet]
        public IActionResult Search([FromQuery]PagedSearch search)
        {
            ApiResult<PagedData<DivisionResp>> searchResult = _divisionService.Search(search);
            IEnumerable<CityResponse.City> cities = _cityService.Find(x => ((long)x.id).IsIn(searchResult.Result.Records.Select(o => o.CityId)));

            return Ok(new
            {
                searchResult.Result.PageNow,
                searchResult.Result.PageSize,
                searchResult.Result.TotalCount,
                Records = searchResult.Result.Records.Select(x =>
                {
                    CityResponse.City city = cities.FirstOrDefault(c => c.id == x.CityId);
                    return new
                    {
                        x.Name,
                        x.CityId,
                        x.DivisionId,
                        x.CreateTime,
                        x.TotalMember,
                        City = city
                    };
                })
            });
        }
    }
}
