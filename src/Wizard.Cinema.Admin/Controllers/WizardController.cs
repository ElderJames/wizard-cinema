using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request.Wizards;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Request.Wizards;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Infrastructures;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WizardController : BaseController
    {
        private readonly IWizardService _wizardService;

        public WizardController(IWizardService wizardService)
        {
            this._wizardService = wizardService;
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
                    WizardId = model.WizardId.Value,
                    Account = model.Account,
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
        public IActionResult Search(PagedSearch search)
        {
            ApiResult<PagedData<WizardResp>> wizards = _wizardService.Search(new SearchWizardReqs()
            {
                PageSize = search.PageSize,
                PageNow = search.PageNow,
                IsAdmin = true
            });

            return Ok(new
            {
                wizards.Result.PageNow,
                wizards.Result.PageSize,
                wizards.Result.TotalCount,
                Records = wizards.Result.Records.Select(x => new
                {
                    x.WizardId,
                    x.DivisionId,
                    x.Account,
                    x.Email,
                    x.CreateTime,
                })
            });
        }
    }
}
