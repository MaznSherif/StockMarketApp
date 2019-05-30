using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using StockMarketApp.Data;
using StockMarketApp.Hubs;
using StockMarketApp.Timer;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using StockMarketApp.Models;

namespace StockMarketApp.Services
{
    public class OrderService : IHostedService, IDisposable
    {

        private TimerManager timerManager;
        public IServiceProvider _serviceprovider;

        public OrderService(IServiceProvider serviceprovider) 
        {
            _serviceprovider = serviceprovider;
        }

        private void ReturnOrders()
        {
             using (var scope = _serviceprovider.CreateScope())
            {
                 var _context = scope.ServiceProvider.GetRequiredService<StockMarketContext>();
                var _hub = scope.ServiceProvider.GetRequiredService<IHubContext<OrderHub>>();

                Random rand=new Random();

                int totalstocks = _context.Stocks.Count();
                int totalclients = _context.People.Count();
                Stock randomstock;
                Broker broker;
                Person randomclient;
                int r = rand.Next(0,2);
                
                if(r==0)
                {
                        for(int i=0;i<10;i++)
                {
                     randomstock = _context.Stocks.Skip(rand.Next(0,totalstocks)).FirstOrDefault();
                    
                   
                    
                    
                        broker = _context.Brokers.FirstOrDefault();
                        var order = new Order 
                        {
                            StockId = randomstock.Id,
                            Id = Guid.NewGuid(),
                            Price = randomstock.Price,
                            Quantity = rand.Next(1,1001),
                            BrokerId = broker.Id,
                            
                            
                        };
                        order.Commission=(order.Quantity * order.Price) * 0.01;
                        order.stock = randomstock;
                        order.broker = broker;
                        _context.Orders.Add(order);
                        randomstock.Orders.Add(order);
                        broker.Orders.Add(order);

                        
                        
                }
                }

            
                        

                    

                    else 
                    {
                        for(int i=0;i<10;i++)
                        {

                        randomstock = _context.Stocks.Skip(rand.Next(0,totalstocks)).FirstOrDefault();

                        randomclient = _context.People.Skip(rand.Next(0,2)).FirstOrDefault();
                        var order = new Order 
                        {
                            StockId = randomstock.Id,
                            Id = Guid.NewGuid(),
                            Price = randomstock.Price,
                            Quantity = rand.Next(1,1001),
                            ClientId = randomclient.Id
                        };
                        order.Commission=(order.Quantity * order.Price) * 0.02;
                        order.stock = randomstock;
                        order.client = randomclient;
                        _context.Orders.Add(order);
                        randomstock.Orders.Add(order);
                        randomclient.Orders.Add(order);
                        
                        
                        }

                    }

                    _context.SaveChanges();

                

                

                _hub.Clients.All.SendAsync("transferorders",_context.Orders.Include(b => b.broker).Include(c => c.client).Include(s => s.stock).ToArray());
                
            }

            
        }
        
         public Task StartAsync(CancellationToken cancellationToken)
        {
            timerManager= new TimerManager(() => ReturnOrders());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceprovider.CreateScope())
            {
                 var _context = scope.ServiceProvider.GetRequiredService<StockMarketContext>();
                 _context.Database.ExecuteSqlCommand("DELETE FROM ORDERS");
            }
            
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            timerManager._timer?.Dispose();
        }
    }
}