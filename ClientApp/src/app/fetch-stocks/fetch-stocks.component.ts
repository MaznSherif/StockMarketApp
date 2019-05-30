import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../fetch-stocks/signal-r.service';




@Component({
  selector: 'app-fetch-stocks',
  templateUrl: './fetch-stocks.component.html'

})


export class FetchStocksComponent implements OnInit {



  constructor(public signalRService: SignalRService) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addfetchstockslistener();




}





}


