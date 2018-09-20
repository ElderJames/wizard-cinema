using Wizard.Cinema.Domain.Cinema;

namespace Wizard.Cinema.Domain.Movie
{
    public interface ISessionRepository
    {
        int Insert(Session session);

        int Update(Session session);

        Session Query(long sessionId);
    }
}
