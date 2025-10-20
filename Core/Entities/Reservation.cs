namespace Core.Entities
{
    public class Reservation
    {
        public string Id { get; set; } = "";
        public string UserId { get; set; } = "";
        public string HotelId { get; set; } = "";
        public string HotelName { get; set; } = "";
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int GuestCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
