using System;
using System.ComponentModel.DataAnnotations;

namespace AcTraining.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Text!")]
        public string FirstName { get; set; }


        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        //--public DateTime DateOfBirth { get; set; }
    }
}