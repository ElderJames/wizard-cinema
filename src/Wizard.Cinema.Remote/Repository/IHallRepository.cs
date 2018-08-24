using System.Collections.Generic;
using Wizard.Cinema.Remote.Models;
using Wizard.Infrastructures;

namespace Wizard.Cinema.Remote.Repository
{
    public interface IHallRepository
    {
        int Insert(Hall hall);

        int InsertBatch(IEnumerable<Hall> halls);

        IEnumerable<Hall> QueryByCinemaId(int cinemaId);

        Hall QueryById(int hallId);

        IEnumerable<Hall> Query(PagedSearch condition);

        PagedData<Hall> QueryPaged(PagedSearch condition);
    }
}