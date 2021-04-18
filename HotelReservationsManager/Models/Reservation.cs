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
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Invalid id format!")]
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Invalid room id format!")]
        public Room Room { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Invalid user id format!")]
        public int UserId { get; set; }

        [NotMapped]
        public User User { get; set; }

        [NotMapped]
        [Display(Name = "Clients list")]
        public List<Client> Clients { get; set; }

        [Required]
        [Display(Name = "Arrival date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [Display(Name = "Departure date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "datetime")]
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
