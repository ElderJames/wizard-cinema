using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Infrastructures;

namespace Wizard.Cinema.Application.Services
{
    public interface IDivisionService
    {
        ApiResult<bool> CreateDivision(CreateDivisionReqs request);

        ApiResult<DivisionResp> GetById(long id);

        ApiResult<DivisionResp> GetByCityId(long cityId);
    }
}
