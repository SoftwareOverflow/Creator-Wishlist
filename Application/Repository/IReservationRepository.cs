using Domain.Entity;

namespace Application.Repository
{
    public interface IReservationRepository
    {
        Task CreateReservationAsync(ItemReservation reservation);

        Task UpdateReservationAsync(ItemReservation reservation);
    }
}
