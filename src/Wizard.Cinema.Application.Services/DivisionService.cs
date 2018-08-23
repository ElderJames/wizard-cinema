using System;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Domain.Ministry;
using Wizard.Cinema.Domain.Wizard;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Infrastructures.Attributes;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs;
using Wizard.Cinema.Smartsql;

namespace Wizard.Cinema.Application.Services
{
    [Impl(ServiceLifetime.Singleton)]
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionQueryService _divisionQueryService;
        private readonly IWizardRepository _wizardRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IDivisionRepository _divisionRepository;

        public DivisionService(IDivisionQueryService divisionQueryService, IWizardRepository wizardRepository, ITransactionRepository transactionRepository, IDivisionRepository divisionRepository)
        {
            this._divisionQueryService = divisionQueryService;
            this._wizardRepository = wizardRepository;
            this._transactionRepository = transactionRepository;
            this._divisionRepository = divisionRepository;
        }

        public ApiResult<bool> CreateDivision(CreateDivisionReqs request)
        {
            if (_divisionQueryService.QueryByCityId(request.CityId) != null)
                return new ApiResult<bool>(ResultStatus.FAIL, "该城市分部已创建");

            Wizards wizard = _wizardRepository.Query(request.CreatorId);
            if (wizard == null)
                return new ApiResult<bool>(ResultStatus.FAIL, "你是谁");

            long divisionId = NewId.GenerateId();

            var division = new Divisions(divisionId, request.CityId, request.Name, request.CreatorId);
            wizard.ChangeDivision(divisionId);

            _transactionRepository.UseTransaction(IsolationLevel.ReadUncommitted, () =>
            {
                if (_wizardRepository.UpdateInfo(wizard) <= 0)
                    throw new Exception("保存时出错，请稍后再试（1）");

                if (_divisionRepository.Insert(division) <= 0)
                    throw new Exception("保存时出错，请稍后再试（2）");
            });

            return new ApiResult<bool>(ResultStatus.SUCCESS, true);
        }

        public ApiResult<DivisionResp> GetById(long id)
        {
            DivisionInfo division = _divisionQueryService.QueryById(id);
            if (division == null)
                return new ApiResult<DivisionResp>(ResultStatus.SUCCESS, default(DivisionResp));

            return new ApiResult<DivisionResp>(ResultStatus.SUCCESS, Mapper.Map<DivisionInfo, DivisionResp>(division));
        }

        public ApiResult<DivisionResp> GetByCityId(long cityId)
        {
            DivisionInfo division = _divisionQueryService.QueryByCityId(cityId);
            if (division == null)
                return new ApiResult<DivisionResp>(ResultStatus.SUCCESS, default(DivisionResp));

            return new ApiResult<DivisionResp>(ResultStatus.SUCCESS, Mapper.Map<DivisionInfo, DivisionResp>(division));
        }
    }
}
