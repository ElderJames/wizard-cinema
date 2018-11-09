using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Remote.Models;

namespace Wizard.Cinema.Remote.Repository
{
    public interface IHallRepository
    {
        int Insert(Hall hall);

        int InsertBatch(IEnumerable<Hall> halls);

        IEnumerable<Hall> QueryByCinemaId(int cinemaId);

        Hall QueryById(int hallId);

        IEnumerable<Hall> QueryByIds(IEnumerable<long> hallIds);

        IEnumerable<Hall> Query(PagedSearch condition);

        PagedData<Hall> QueryPaged(PagedSearch condition);
    }
}
