using Application.Repository;
using Domain.Entity;

namespace Application.Service
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository repository)
        {
            _reservationRepository = repository;
        }

        public async Task CreateReservationAsync()
        {
            //
            //await _reservationRepository.CreateReservationAsync(reservation);
        }
    }
}
