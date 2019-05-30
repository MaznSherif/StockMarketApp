using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StockMarketApp.Models
{
    public class Order
    {
        
        
        
        public Guid StockId {get; set;}
        [ForeignKey("StockId")]
        public Stock stock {get; set;}
        public Nullable<Guid> BrokerId {get; set;}
        [ForeignKey("BrokerId")]
        public Broker broker {get; set;}
        public Nullable<Guid> ClientId {get; set;}
        [ForeignKey("ClientId")] 
        public Person client {get; set;}
        [Key]
        public Guid Id {get; set;}

        public double Price {get; set;}
        public int Quantity {get; set;}
        public double Commission {get; set;}
            
        
        
    }
}