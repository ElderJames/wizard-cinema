using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Ministry
{
    public interface IDivisionRepository
    {
        int Insert(Divisions divisions);

        int Update(Divisions divisions);

        Divisions Query(long divisionId);

        Divisions QueryByCityId(long cityId);
    }
}
