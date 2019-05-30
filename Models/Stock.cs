using System;
using System.Collections.Generic;
namespace StockMarketApp.Models
{
    public class Stock
    {
        
        public Guid Id {get; set;}
        public string Name {get; set;}

        public int Price {get; set;}

        public List<Order> Orders {get; set;}


    }
}