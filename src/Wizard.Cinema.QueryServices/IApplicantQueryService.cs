using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs.Activity;

namespace Wizard.Cinema.QueryServices
{
    public interface IApplicantQueryService
    {
        ApplicantInfo Query(long applicantId);

        PagedData<ApplicantInfo> QueryPaged(SearchApplicantCondition search);

        IEnumerable<ApplicantInfo> Query(SearchApplicantCondition search);

        IEnumerable<ApplicantInfo> QueryByActivityId(long activityId);
    }
}
