using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcTraining.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Bitte geben Sie einen Text an.")]
        public string FirstName { get; set; } // Aufgrund der Annotation [Required] muss das Feld FirstName angegeben werden; MaxLength ist eine weitere
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int AmountOfOrders { get; set; }
        public int AmountOfInvoices { get; set; }

        public virtual ICollection<Customer> Children { get; set; }
        //virtual vermeidet, dass die Abfrage sofort gesendet wird und die Daten direkt geladen werden
    }
}