using Wizard.Cinema.Remote.Models;

namespace Wizard.Cinema.Remote.Repository
{
    public interface IHallRepository
    {
        int Insert(Hall hall);

        int InsertBatch(Hall[] halls);

        //Hall Query(int hallId);

        //Hall Query(object condition);
    }
}