using Application.Interfaces;
using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly List<Reservation> _reservations;

        public ReservationService()
        {
            _reservations = new List<Reservation>();
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.Id = $"res-{_reservations.Count + 1:D3}";
            reservation.Status = "Confirmada";
            _reservations.Add(reservation);
        }

        public List<Reservation> GetUserReservations(string userId)
        {
            return _reservations.Where(r => r.UserId == userId).ToList();
        }

        public Reservation? GetReservationById(string id)
        {
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

        public bool CancelReservation(string reservationId)
        {
            var reservation = GetReservationById(reservationId);
            if (reservation != null && reservation.Status == "Confirmada")
            {
                reservation.Status = "Cancelada";
                return true;
            }
            return false;
        }

        public int DeleteCancelledForUser(string userId)
        {
            var toDelete = _reservations.Where(r => r.UserId == userId && r.Status == "Cancelada").ToList();
            foreach (var r in toDelete)
            {
                _reservations.Remove(r);
            }
            return toDelete.Count;
        }
    }
}
