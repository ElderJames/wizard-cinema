using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs.Activity;

namespace Wizard.Cinema.QueryServices
{
    public interface IActivityQueryService
    {
        ActivityInfo Query(long activityId);

        PagedData<ActivityInfo> Query(PagedSearch search);
    }
}
