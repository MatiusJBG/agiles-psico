using Application.Interfaces;
using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class HotelService : IHotelService
    {
        private readonly List<Hotel> _hoteles;

        public HotelService()
        {
            _hoteles = new List<Hotel>
            {
                new Hotel 
                { 
                    Id = "hotel-ambato",
                    Name = "Hotel Ambato", 
                    StarRating = 4,
                    PricePerNight = 85.00m,
                    Description = "Considerado un ícono de la ciudad, el Hotel Ambato combina tradición y confort. Ofrece una vista panorámica del centro de Ambato y es conocido por su hospitalidad y servicio de primera clase.",
                    Images = new List<string> { "img/H-Ambato/H-Ambato.jpg", "img/H-Ambato/H-Ambato1.jpg", "img/H-Ambato/H-Ambato2.jpg" },
                    Location = "Av. Cevallos y Montalvo, Ambato, Ecuador",
                    Website = "https://hotelambato.com",
                    SocialMedia = "https://www.facebook.com/HotelAmbato/",
                    Comments = new List<string> { "Excelente ubicación y personal muy amable.", "Las habitaciones son cómodas y la vista es increíble.", "Un clásico de Ambato, siempre confiable." }
                },
                new Hotel 
                { 
                    Id = "roka-plaza",
                    Name = "Roka Plaza Hotel Boutique", 
                    StarRating = 4,
                    PricePerNight = 120.00m,
                    Description = "Ubicado en una casa colonial restaurada, Roka Plaza ofrece una experiencia de lujo con un toque histórico. Sus patios internos y su cuidada decoración lo convierten en un oasis de tranquilidad.",
                    Images = new List<string> { "img/H-Roka/H-Roka.jpg", "img/H-Roka/H-Roka1.jpg", "img/H-Roka/H-Roka2.jpg" },
                    Location = "Calle Bolívar y Montalvo, Ambato, Ecuador",
                    Website = "https://rokaplaza.com",
                    SocialMedia = "https://www.facebook.com/RokaPlazaHotel/",
                    Comments = new List<string> { "Un lugar mágico, lleno de historia.", "El desayuno en el patio es una maravilla.", "Atención al detalle en cada rincón." }
                },
                new Hotel 
                { 
                    Id = "hotel-seny",
                    Name = "Hotel Seny", 
                    StarRating = 3,
                    PricePerNight = 65.00m,
                    Description = "Moderno y funcional, el Hotel Seny es ideal tanto para viajeros de negocios como para turistas. Destaca por sus instalaciones impecables y su personal siempre dispuesto a ayudar.",
                    Images = new List<string> { "img/H-Seny/H-Seny.jpg", "img/H-Seny/H-Seny1.jpg", "img/H-Seny/H-Seny2.jpg" },
                    Location = "Av. de las Américas, Ambato, Ecuador",
                    Website = "https://hoteleseny.com",
                    SocialMedia = "https://www.instagram.com/hoteleseny/",
                    Comments = new List<string> { "Muy limpio y moderno.", "Perfecto para viajes de trabajo.", "El personal es excepcionalmente atento." }
                },
                new Hotel 
                { 
                    Id = "hotel-miraflores",
                    Name = "Hotel Miraflores", 
                    StarRating = 2,
                    PricePerNight = 45.00m,
                    Description = "Con una larga trayectoria en la ciudad, el Hotel Miraflores ofrece un ambiente familiar y acogedor. Es una opción excelente para quienes buscan comodidad a un precio razonable.",
                    Images = new List<string> { "img/H-Miraflores/H-Miraflores.jpg", "img/H-Miraflores/H-Miraflores1.jpg", "img/H-Miraflores/H-Miraflores2.jpg" },
                    Location = "Av. Miraflores, Ambato, Ecuador",
                    Website = "https://hotelmiraflores.com.ec",
                    SocialMedia = "https://www.facebook.com/HotelMirafloresAmbato/",
                    Comments = new List<string> { "Buena relación calidad-precio.", "Un hotel tranquilo y confortable.", "El personal te hace sentir como en casa." }
                },
                new Hotel 
                { 
                    Id = "hotel-cedro-sonado",
                    Name = "Hotel Cedro Soñado", 
                    StarRating = 3,
                    PricePerNight = 75.00m,
                    Description = "Un hotel nuevo con un concepto fresco y natural. Sus espacios están diseñados para el descanso y la relajación, con acabados en madera que le dan un toque cálido y único.",
                    Images = new List<string> { "img/H-Cedro/H-Cedro.jpg", "img/H-Cedro/H-Cedro1.jpg", "img/H-Cedro/H-Cedro2.jpg" },
                    Location = "Sector Ficoa, Calle Los Cedros, Ambato, Ecuador",
                    Website = "https://cedrosonado.com",
                    SocialMedia = "https://www.instagram.com/cedrosonado/",
                    Comments = new List<string> { "El diseño es espectacular.", "Un lugar perfecto para desconectar.", "Las camas son increíblemente cómodas." }
                },
                new Hotel 
                { 
                    Id = "hotel-golosone",
                    Name = "Hotel Golosone", 
                    StarRating = 4,
                    PricePerNight = 95.00m,
                    Description = "Famoso por su restaurante, el Hotel Golosone también ofrece un alojamiento de primera. Es el lugar ideal para los amantes de la buena comida que buscan una estancia confortable.",
                    Images = new List<string> { "img/H-Golosone/H-Golosone.jpg", "img/H-Golosone/H-Golosone1.jpg", "img/H-Golosone/H-Golosone2.jpg" },
                    Location = "Calle Darquea y Sevilla, Ambato, Ecuador",
                    Website = "https://hotelgolosone.com",
                    SocialMedia = "https://www.facebook.com/GolosoneRestaurante/",
                    Comments = new List<string> { "La comida es simplemente la mejor.", "Habitaciones impecables y un servicio de 10.", "Una experiencia gastronómica y de hospedaje inigualable." }
                },
                new Hotel 
                { 
                    Id = "hotel-florida",
                    Name = "Hotel Florida", 
                    StarRating = 3,
                    PricePerNight = 70.00m,
                    Description = "Este hotel destaca por sus hermosos, jardines y áreas verdes. Es un refugio de paz en medio de la ciudad, ideal para relajarse después de un día de turismo o trabajo.",
                    Images = new List<string> { "img/H-Florida/H-Florida.jpg", "img/H-Florida/H-Florida1.jpg", "img/H-Florida/H-Florida2.jpg" },
                    Location = "Av. Rodrigo Pachano, Ambato, Ecuador",
                    Website = "https://hotelflorida.com.ec",
                    SocialMedia = "https://www.facebook.com/HotelFloridaAmbato/",
                    Comments = new List<string> { "Los jardines son preciosos.", "Un oasis en la ciudad.", "Muy tranquilo y relajante." }
                },
                new Hotel 
                { 
                    Id = "hotel-de-las-americas",
                    Name = "Hotel de las Américas - Ambato", 
                    StarRating = 3,
                    PricePerNight = 80.00m,
                    Description = "Un hotel moderno y bien equipado, con un restaurante que ofrece una variada carta de platos nacionales e internacionales. Su terraza es perfecta para disfrutar de una vista de la ciudad.",
                    Images = new List<string> { "img/H-Americas/H-Americas.jpg", "img/H-Americas/H-Americas1.jpg", "img/H-Americas/H-Americas2.jpg" },
                    Location = "Av. de las Américas y México, Ambato, Ecuador",
                    Website = "https://hoteldelasamericasambato.com",
                    SocialMedia = "https://www.facebook.com/HoteldelasAmericasAmbato/",
                    Comments = new List<string> { "El restaurante es muy bueno.", "Instalaciones modernas y limpias.", "La terraza tiene una vista espectacular." }
                },
                new Hotel 
                { 
                    Id = "hotel-madurai",
                    Name = "Hotel Madurai", 
                    StarRating = 2,
                    PricePerNight = 50.00m,
                    Description = "Hotel Madurai ofrece una propuesta de valor con habitaciones cómodas y funcionales. Es una opción popular por su excelente servicio al cliente y su ambiente tranquilo.",
                    Images = new List<string> { "img/H-Madurai/H-Madurai.jpg", "img/H-Madurai/H-Madurai1.jpg", "img/H-Madurai/H-Madurai2.jpg" },
                    Location = "Avenida Atahualpa, Ambato, Ecuador",
                    Website = "https://hotelmadurai.com",
                    SocialMedia = "https://www.facebook.com/HotelMaduraiAmbato/",
                    Comments = new List<string> { "Servicio al cliente de primera.", "Habitaciones muy cómodas y limpias.", "Un lugar tranquilo para descansar." }
                },
                new Hotel 
                { 
                    Id = "hotel-emperador",
                    Name = "Hotel Emperador", 
                    StarRating = 3,
                    PricePerNight = 90.00m,
                    Description = "Conocido por su piscina cubierta y su spa, el Hotel Emperador es el lugar ideal para una escapada de relax. Ofrece todas las comodidades para una estancia placentera y rejuvenecedora.",
                    Images = new List<string> { "img/H-Emperador/H-Emperador.jpg", "img/H-Emperador/H-Emperador1.jpg", "img/H-Emperador/H-Emperador2.jpg" },
                    Location = "Av. Cevallos, Ambato, Ecuador",
                    Website = "https://hotelemperador.com.ec",
                    SocialMedia = "https://www.facebook.com/hotelemperadorambato/",
                    Comments = new List<string> { "La piscina es fantástica.", "Ideal para un fin de semana de spa y relax.", "Muy buen servicio en general." }
                }
            };
        }

        public List<Hotel> GetAllHotels() => _hoteles;

        public Hotel? GetHotelById(string id) => _hoteles.FirstOrDefault(h => h.Id == id);
    }
}
