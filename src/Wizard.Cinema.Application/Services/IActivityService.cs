using Infrastructures;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface IActivityService
    {
        ApiResult<bool> Create(CreateActivityReqs request);

        ApiResult<bool> Change(UpdateActivityReqs request);

        ApiResult<ActivityResp> GetById(long activityId);

        ApiResult<PagedData<ActivityResp>> Search(PagedSearch search);
    }
}
