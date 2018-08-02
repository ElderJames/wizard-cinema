using System.Collections.Generic;

namespace Wizard.Cinema.Remote.Repository
{
    public interface ICinemaRepository
    {
        int Insert(Models.Cinema cinema);

        int InsertBatch(params Models.Cinema[] cinemas);

        //int Update(Models.Cinema cinema);

        //IEnumerable<Models.Cinema> Query();
    }
}