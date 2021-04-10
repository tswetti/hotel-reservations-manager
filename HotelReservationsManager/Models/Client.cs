﻿using System;
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
        //[Range(3, 30, ErrorMessage = "The first name must be at least 3 characters and no more than 30!")]
        /*[RegularExpression(@"[a-zA]",
            ErrorMessage = "Invalid name format!")]*/
        [Display(Name = "First name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required]
        //[Range(3, 30, ErrorMessage = "The first name must be at least 3 characters and no more than 30!")]
        /*[RegularExpression(@"[a-zA]",
            ErrorMessage = "Invalid name format!")]*/
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
        //[Range(5, 50, ErrorMessage = "The email must be at least 5 characters and no more than 50!")]
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
