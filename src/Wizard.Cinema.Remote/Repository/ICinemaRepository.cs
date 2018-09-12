using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Remote.Repository.Condition;

namespace Wizard.Cinema.Remote.Repository
{
    public interface ICinemaRepository
    {
        int Insert(Models.Cinema cinema);

        int InsertBatch(IEnumerable<Models.Cinema> cinemas);

        int QueryCount(long CityId);

        //int Update(Models.Cinema cinema);

        IEnumerable<Models.Cinema> Query(SearchCinemaCondition condition);

        PagedData<Models.Cinema> QueryPaged(SearchCinemaCondition condition);
    }
}
