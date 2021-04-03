using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm password")]
        //[CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        [Column(TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string EGN { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Admin { get; set; }

        [Required]
        [Display(Name = "Hire date")]
        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Active { get; set; }

        [Display(Name = "Dismissal date")]
        [Column(TypeName = "date")]
        public DateTime? DismissalDate { get; set; }

        [NotMapped]
        [Display(Name = "Reservations list")]
        public IList<Reservation> UserReservations { get; set; }
    }
}