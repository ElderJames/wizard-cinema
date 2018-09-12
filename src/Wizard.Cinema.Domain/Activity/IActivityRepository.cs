using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Activity
{
    public interface IActivityRepository
    {
        int Insert(Activity activity);

        int Update(Activity activity);

        Activity Query(long activityId);
    }
}
