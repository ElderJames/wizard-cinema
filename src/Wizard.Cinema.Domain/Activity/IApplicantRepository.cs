using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Activity
{
    public interface IApplicantRepository
    {
        int Insert(Applicant applicant);

        int ChangeStatus(Applicant applicant);

        Applicant Query(long applicantId);

        IEnumerable<Applicant> QueryByActivityId(long activityId);
    }
}
