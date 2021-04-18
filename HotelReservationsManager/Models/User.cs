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
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Invalid id format!")]
        public int UserId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]{3,25}$",
            ErrorMessage = "Invalid username format! " +
            "Username must be at least 3 characters and no more than 25. " +
            "Only letters, numbers, '_.-' symbols allowed.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-z-A-Z,.'-]{3,30}$",
            ErrorMessage = "Invalid name format! " +
            "First name must be at least 3 characters and no more than 30!")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        [RegularExpression(@"^[a-z-A-Z,.'-]{3,30}$",
            ErrorMessage = "Invalid name format! " +
            "First name must be at least 3 characters and no more than 30!")]
        [Column(TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-z-A-Z,.'-]{3,30}$",
            ErrorMessage = "Invalid name format! " +
            "First name must be at least 3 characters and no more than 30!")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Invalid EGN format!")]
        [Column(TypeName = "nvarchar(20)")]
        public string EGN { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage= "Invalid email format!")]
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