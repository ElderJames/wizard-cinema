using System;
using System.Collections.Generic;
using System.Text;
using Wizard.Cinema.QueryServices.DTOs;

namespace Wizard.Cinema.QueryServices
{
    public interface IDivisionQueryService
    {
        DivisionInfo QueryByCityId(long cityId);

        DivisionInfo QueryById(long divisionId);

        IEnumerable<DivisionInfo> QueryByIds(long[] divisionIds);
    }
}
