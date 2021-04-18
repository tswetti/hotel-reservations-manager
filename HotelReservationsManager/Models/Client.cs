using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Models
{
    public class Client
    {
        [Required]
        [Key]
        public int ClientId { get; set; }

        [Required]
        [RegularExpression(@"^[a-z-A-Z,.'-]+$",
            ErrorMessage = "Invalid name format!")]
        [Display(Name = "First name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-z-A-Z,.'-]+$",
            ErrorMessage = "Invalid name format!")]
        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Invalid phone number!")]
        [Display(Name = "Phone number")]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format!")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Adult { get; set; }

        [NotMapped]
        [Display(Name = "Reservations list")]
        public IList<Reservation> ClientReservations { get; set; }
    }
}
