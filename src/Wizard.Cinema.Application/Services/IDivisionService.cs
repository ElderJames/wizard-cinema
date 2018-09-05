using System.Collections.Generic;
using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Infrastructures;

namespace Wizard.Cinema.Application.Services
{
    public interface IDivisionService
    {
        ApiResult<bool> CreateDivision(CreateDivisionReqs request);

        ApiResult<DivisionResp> GetById(long divisionId);

        ApiResult<DivisionResp> GetByCityId(long cityId);

        ApiResult<IEnumerable<DivisionResp>> GetByIds(long[] divisionIds);
    }
}
