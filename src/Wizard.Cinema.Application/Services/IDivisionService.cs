using System.Collections.Generic;
using Wizard.Cinema.Application.DTOs.Request;
using Wizard.Cinema.Application.DTOs.Request.Division;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Infrastructures;

namespace Wizard.Cinema.Application.Services
{
    public interface IDivisionService
    {
        ApiResult<bool> CreateDivision(CreateDivisionReqs request);

        ApiResult<bool> ChangeDivision(ChangeDivisionReqs request);

        ApiResult<DivisionResp> GetById(long divisionId);

        ApiResult<DivisionResp> GetByCityId(long cityId);

        ApiResult<IEnumerable<DivisionResp>> GetByIds(long[] divisionIds);

        ApiResult<PagedData<DivisionResp>> Search(PagedSearch search);
    }
}
