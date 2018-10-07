namespace Wizard.Cinema.Domain.Cinema
{
    public interface ISeatRepository
    {
        int Insert(Seat seat);

        int BatchInsert(Seat[] seats);

        int Choose(Seat seat);

        Seat Query(long seatId);

        Seat Query(string seatNo);
    }
}
