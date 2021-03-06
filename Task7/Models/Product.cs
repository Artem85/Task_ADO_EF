﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
