using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Models
{
    public class Reservation
    {
        [Required]
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Room { get; set; }

        [NotMapped]
        [Display(Name = "Rooms list")]
        public IList<Room> Rooms { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int UserId { get; set; }

        [NotMapped]
        public User User { get; set; }

        [NotMapped]
        [Display(Name = "Clients list")]
        public List<Client> Clients { get; set; }

        [Required]
        [Display(Name = "Arrival date")]
        [Column(TypeName = "date")]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [Display(Name = "Departure date")]
        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Breakfast { get; set; }

        [Required]
        [Display(Name = "All inclusive")]
        [Column(TypeName = "bit")]
        public bool AllInclusive { get; set; }

        [Required]
        [Display(Name = "Total price")]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
    }
}
