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
        //[Range(3,25, ErrorMessage="The username must be at least 3 characters and no more than 25!")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+$",
            ErrorMessage = "Invalid username format!")]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Required]
        //[Range(6,25, ErrorMessage="The password must be at least 6 characters and no more than 20!")]
        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm password")]
        //[CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        //[Range(3, 30, ErrorMessage = "The first name must be at least 3 characters and no more than 30!")]
        /*[RegularExpression(@"[a-zA]",
            ErrorMessage = "Invalid name format!")]*/
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        //[Range(3, 30, ErrorMessage = "The middle name must be at least 3 characters and no more than 30!")]
        /*RegularExpression(@"^[a-zA]",
            ErrorMessage = "Invalid name format!")]*/
        [Column(TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        //[Range(3, 30, ErrorMessage = "The last name must be at least 3 characters and no more than 30!")]
        /*[RegularExpression(@"^[a-zA]",
            ErrorMessage = "Invalid name format!")]*/
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Invalid EGN format!")]
        [Column(TypeName = "nvarchar(20)")]
        public string EGN { get; set; }

        [Required]
        //[Range(5, 50, ErrorMessage = "The email must be at least 5 characters and no more than 50!")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage="Invalid email format!")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Admin { get; set; }

        [Required]
        [Display(Name = "Hire date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Active { get; set; }

        [Display(Name = "Dismissal date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime? DismissalDate { get; set; }

        [NotMapped]
        [Display(Name = "Reservations list")]
        public IList<Reservation> UserReservations { get; set; }
    }
}