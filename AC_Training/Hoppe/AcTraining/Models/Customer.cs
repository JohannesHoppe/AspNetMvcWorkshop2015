﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AcTraining.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        //public DateTime DateOfBirth { get; set; }

        public int AmountOfOrders { get; set; }
        public int AmountOfInvoices { get; set; }
    }
}