using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarketApp.Models;
using StockMarketApp.Data;
using StockMarketApp.Hubs;
using StockMarketApp.Timer;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Web;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace StockMarketApp.Services
{
    public class StockService : IHostedService, IDisposable
    {
         

        private TimerManager timerManager;
        public IServiceProvider _services;

public StockService(IServiceProvider services )
        {
           _services = services;
        }


        private void GetStocks()
        {
            
            using (var scope = _services.CreateScope())
            {

                var _context = scope.ServiceProvider.GetRequiredService<StockMarketContext>();
                var _hub = scope.ServiceProvider.GetRequiredService<IHubContext<StockHub>>();
                Random rand=new Random();

                
                 foreach (var stock in _context.Stocks)
            {
                stock.Price=rand.Next(1,101);
            }

            
            _context.SaveChanges();
            _hub.Clients.All.SendAsync("transferstocks",_context.Stocks.ToArray());
            
            }
        
            
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            timerManager= new TimerManager(() => GetStocks());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

        public void Dispose()
    {
        timerManager._timer?.Dispose();
    }
        
    }
}