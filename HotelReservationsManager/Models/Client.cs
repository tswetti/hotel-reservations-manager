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
        [Display(Name = "First name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [Required]
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
