using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs.Activity;

namespace Wizard.Cinema.QueryServices
{
    public interface IApplicantQueryService
    {
        ApplicantInfo Query(long applicantId);

        PagedData<ApplicantInfo> QueryPaged(PagedSearch search);
    }
}
