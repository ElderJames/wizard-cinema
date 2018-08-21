using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Domain.Wizard;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Infrastructures.Attributes;
using Wizard.Cinema.Infrastructures.Encrypt.Extensions;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs;

namespace Wizard.Cinema.Application.Services
{
    [Impl(ServiceLifetime.Singleton)]
    public class WizardService : IWizardService
    {
        private readonly IWizardRepository _wizardRepository;
        private readonly IWizardQueryService _wizardQueryService;

        public WizardService(IWizardRepository wizardRepository,
            IWizardQueryService wizardQueryService)
        {
            this._wizardRepository = wizardRepository;
            this._wizardQueryService = wizardQueryService;
        }

        public ApiResult<bool> Register(RegisterWizardReqs request)
        {
            long wizardId = NewId.GenerateId();

            var wizard = new Wizards(wizardId, request.Email, request.Passward);

            if (_wizardRepository.Create(wizard) <= 0)
                return new ApiResult<bool>(ResultStatus.FAIL, "保存时发生异常，请稍后再试");

            return new ApiResult<bool>(ResultStatus.SUCCESS, true);
        }

        public ApiResult<WizardResp> GetWizard(string account, string passward)
        {
            WizardInfo wizard = _wizardQueryService.Query(account, passward.ToMd5());
            if (wizard == null)
                return new ApiResult<WizardResp>(ResultStatus.FAIL, "用户不能存在或密码不正确");

            return new ApiResult<WizardResp>(ResultStatus.SUCCESS, Mapper.Map<WizardInfo, WizardResp>(wizard));
        }

        public ApiResult<WizardResp> GetWizard(long wizardId)
        {
            WizardInfo wizard = _wizardQueryService.Query(wizardId);
            if (wizard == null)
                return new ApiResult<WizardResp>(ResultStatus.FAIL, "用户不能存在或密码不正确");

            return new ApiResult<WizardResp>(ResultStatus.SUCCESS, Mapper.Map<WizardInfo, WizardResp>(wizard));
        }

        public ApiResult<PagedData<WizardResp>> Search(PagedSearch search)
        {
            PagedData<WizardInfo> wizards = _wizardQueryService.QueryPaged(search);
            return new ApiResult<PagedData<WizardResp>>(ResultStatus.SUCCESS, new PagedData<WizardResp>()
            {
                PageSize = wizards.PageSize,
                PageNow = wizards.PageNow,
                TotalCount = wizards.TotalCount,
                Records = wizards.Records.Select(Mapper.Map<WizardInfo, WizardResp>)
            });
        }
    }
}
