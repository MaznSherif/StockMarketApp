using System;
using System.Collections.Generic;
namespace StockMarketApp.Models
{
    public class Broker
    {
        public string Name {get; set;}
        public Guid Id {get; set;}

        public List<Order> Orders {get; set;}
        public List<Person> Clients {get; set;}
        

    }
}