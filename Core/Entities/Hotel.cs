namespace Core.Entities
{
    public class Hotel
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int StarRating { get; set; } = 0; // 0-4 estrellas
        public decimal PricePerNight { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<string> Images { get; set; } = new List<string>();
        public string Location { get; set; } = "";
        public string Website { get; set; } = "";
        public string SocialMedia { get; set; } = "";
        public List<string> Comments { get; set; } = new List<string>();
    }
}
