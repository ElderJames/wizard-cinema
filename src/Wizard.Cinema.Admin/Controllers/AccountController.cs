using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api")]
    [Authorize]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IWizardService _wizardService;

        public AccountController(IWizardService wizardService)
        {
            this._wizardService = wizardService;
        }

        [HttpGet("wizard/{userId:long}")]
        public IActionResult WizardInfo(long wizardId)
        {
            if (wizardId <= 0)
                return Fail("请选择正确的巫师");

            ApiResult<WizardResp> wizard = _wizardService.GetWizard(wizardId);
            if (wizard.Status != ResultStatus.SUCCESS || wizard.Result == null)
                return Fail("巫师不存在");

            ApiResult<ProfileResp> profile = _wizardService.GetPrpfile(wizardId);
            if (profile.Status != ResultStatus.SUCCESS || wizard.Result == null)
                return Fail("查询不到个人资料");

            return Ok(new
            {
                wizard.Result.WizardId,
                wizard.Result.Account,
                wizard.Result.DivisionId,
                wizard.Result.Email,
                Profile = new
                {
                    profile.Result.NickName,
                    profile.Result.Birthday,
                    profile.Result.Gender,
                    profile.Result.House,
                    profile.Result.Slogan,
                    profile.Result.PortraitUrl
                }
            });
        }
    }
}
