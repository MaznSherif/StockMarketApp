import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../fetch-orders/signal-r.service';
@Component({
  selector: 'app-fetch-orders',
  templateUrl: './fetch-orders.component.html',
  styleUrls: ['./fetch-orders.component.css']
})
export class FetchOrdersComponent implements OnInit {

  constructor(public signalRService: SignalRService) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addfetchorderslistener();

}
}
