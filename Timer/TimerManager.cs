using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using StockMarketApp.Models;
using StockMarketApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;

namespace StockMarketApp.Timer
{
    public class TimerManager
    {

   
    public System.Threading.Timer _timer;
    private AutoResetEvent _autoResetEvent;
    private Action _action;
    

    public TimerManager(Action action)
    {
        _action = action;
        _autoResetEvent = new AutoResetEvent(false);
        _timer = new System.Threading.Timer(Execute, _autoResetEvent, 1000, 10000);
        
        
    }

    public void Execute(object stateInfo)
    {
        _action();

    }

        
        
    }
}