using Core.Entities;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);
        List<Reservation> GetUserReservations(string userId);
        Reservation? GetReservationById(string id);
        bool CancelReservation(string reservationId);
        int DeleteCancelledForUser(string userId);
    }
}
