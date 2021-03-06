﻿using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs;

namespace Wizard.Cinema.QueryServices
{
    public interface IDivisionQueryService
    {
        DivisionInfo QueryByCityId(long cityId);

        DivisionInfo QueryById(long divisionId);

        IEnumerable<DivisionInfo> Query(long[] divisionIds);

        PagedData<DivisionInfo> QueryPaged(PagedSearch search);
    }
}
