using System.Collections.Generic;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Remote.Repository.Condition;

namespace Wizard.Cinema.Remote.Repository
{
    public interface ICinemaRepository
    {
        int Insert(Models.Cinema cinema);

        int InsertBatch(IEnumerable<Models.Cinema> cinemas);

        //int Update(Models.Cinema cinema);

        IEnumerable<Models.Cinema> GetList(SearchCinemaCondition condition);

        PagedData<Models.Cinema> QueryPage(SearchCinemaCondition condition);
    }
}