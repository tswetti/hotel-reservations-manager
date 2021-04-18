 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Models
{
    public class Room
    {
        [Required]
        [Key]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Invalid id format!")]
        public int RoomId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Capacity must only consist of numbers!")]
        [Column(TypeName = "int")]
        public int Capacity { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Available { get; set; }

        [Required]
        [Display(Name = "Price for adults")]
        [Column(TypeName = "money")]
        public decimal PriceAdults { get; set; }

        [Required]
        [Display(Name = "Price for children")]
        [Column(TypeName = "money")]
        public decimal PriceChildren { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-]+$",
            ErrorMessage = "Invalid room number format!")]
        [Display(Name = "Room number")]
        [Column(TypeName = "int")]
        public int Number { get; set; }

        [NotMapped]
        [Display(Name = "Reservations list")]
        public IList<Reservation> RoomReservations { get; set; }
    }
}
