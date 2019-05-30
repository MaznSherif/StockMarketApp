using System;
using System.Collections.Generic;

namespace StockMarketApp.Models
{
    public class Person
    {
        public string Name {get; set;}
        public Guid Id {get; set;}

        public List<Order> Orders {get; set;}


    }
}