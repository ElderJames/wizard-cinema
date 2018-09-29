using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request.Wizards;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Request.Wizards;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WizardController : BaseController
    {
        private readonly IWizardService _wizardService;
        private readonly CityService _cityService;
        private readonly IDivisionService _divisionService;

        public WizardController(IWizardService wizardService, CityService cityService, IDivisionService divisionService)
        {
            this._wizardService = wizardService;
            this._cityService = cityService;
            this._divisionService = divisionService;
        }

        [HttpPost]
        public IActionResult EditWizard(WizardModel model)
        {
            if (!model.WizardId.HasValue || model.WizardId <= 0)
            {
                ApiResult<bool> result = _wizardService.CreateWizard(new CreateWizardReqs()
                {
                    Account = model.Account,
                    Passward = model.Password,
                    DivisionId = model.DivisionId,
                    CreatorId = CurrentUser.UserId
                });
                return Json(result);
            }
            else
            {
                var result = _wizardService.UpdateWizard(new UpdateWizardReqs()
                {
                    Account = model.Account,
                    WizardId = model.WizardId.Value,
                    DivisionId = model.DivisionId,
                    Passward = model.Password
                });
                return Json(result);
            }
        }

        [HttpGet("{id:long}")]
        public IActionResult FindWizard(long wizardId)
        {
            ApiResult<WizardResp> result = _wizardService.GetWizard(wizardId);
            if (result.Status != ResultStatus.SUCCESS)
                return Fail(result.Message);

            return Ok(new
            {
                result.Result.Account,
                result.Result.WizardId,
                result.Result.Email,
                result.Result.CreateTime,
                result.Result.DivisionId
            });
        }

        [HttpGet]
        public IActionResult Search([FromQuery]PagedSearch search)
        {
            ApiResult<PagedData<WizardResp>> wizards = _wizardService.Search(new SearchWizardReqs()
            {
                PageSize = search.PageSize,
                PageNow = search.PageNow,
                IsAdmin = true
            });

            ApiResult<IEnumerable<DivisionResp>> divisions = _divisionService.GetByIds(wizards.Result.Records.Select(x => x.DivisionId).Distinct().ToArray());
            IEnumerable<CityResponse.City> cities = _cityService.Find(x => ((long)x.id).IsIn(divisions.Result.Select(o => o.CityId).Distinct()));

            return Ok(new
            {
                wizards.Result.PageNow,
                wizards.Result.PageSize,
                wizards.Result.TotalCount,
                Records = wizards.Result.Records.Select(x =>
                {
                    DivisionResp division = divisions.Result.FirstOrDefault(o => o.DivisionId == x.DivisionId);
                    CityResponse.City city = cities.FirstOrDefault(c => c.id == division.CityId);
                    return new
                    {
                        x.WizardId,
                        x.DivisionId,
                        City = city.nm,
                        x.Account,
                        x.Email,
                        x.CreateTime,
                    };
                })
            });
        }
    }
}
