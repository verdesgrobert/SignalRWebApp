using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRWebApp.Models
{
    public class MyClass
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}