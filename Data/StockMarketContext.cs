using StockMarketApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace StockMarketApp.Data
{
    public class StockMarketContext : DbContext
    {
       

        public StockMarketContext(DbContextOptions<StockMarketContext> options) : base (options)
        {
            
        }
        public DbSet<Stock> Stocks {get; set;}
        public DbSet<Broker> Brokers {get; set;}
        public DbSet<Person> People {get; set;}
        public DbSet<Order> Orders {get; set;}
        

        
protected override void OnModelCreating(ModelBuilder builder) 
     {
         
         base.OnModelCreating(builder);
         Random r=new Random();
         builder.Entity<Stock>().HasData(
             new Stock() {Id=Guid.NewGuid(),Name="Vianet",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Agritek",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Akamai",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Baidu",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Blinkx",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Blucora",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Boingo",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Brainybrawn",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Carbonite",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="China Finance",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="ChinaCache",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="ADR",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="ChitrChatr",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Cnova",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Cogent",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Crexendo",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="CrowdGather",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="EarthLink",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Eastern",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="ENDEXX",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Envestnet",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Epazz",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="FlashZero",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Genesis",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="InterNAP",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="MeetMe",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Netease",Price=r.Next(1,101)},
             new Stock() {Id=Guid.NewGuid(),Name="Qihoo",Price=r.Next(1,101)}
         );

         
        Guid BrokerID=Guid.NewGuid();
        builder.Entity<Broker>().HasData(
             new Broker() {Id=BrokerID,Name="Broker1"}
         );
         
        
        
        builder.Entity<Person>().HasData(
            new {Id=Guid.NewGuid(),Name="Client1",BrokerId=BrokerID},
            new {Id=Guid.NewGuid(),Name="Client2",BrokerId=BrokerID}
            );
            
            
        
            
            
           
        
         
     } 


    }
}