using Core.Entities;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();
        Hotel? GetHotelById(string id);
    }
}
