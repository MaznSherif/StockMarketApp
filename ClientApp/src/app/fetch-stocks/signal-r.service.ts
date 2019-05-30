import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import {Stocks} from '../fetch-stocks/stocks.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public stock: Stocks[];

  private hubConnection: signalR.HubConnection;
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                              .withUrl('https://localhost:5001/stockhub', {
                                skipNegotiation: true,
                                transport: signalR.HttpTransportType.WebSockets
                              })
                              .build();
    this.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while starting connection: ' + err));

  }



  public addfetchstockslistener = () => {
  this.hubConnection.on('transferstocks', (data) => {
  this.stock = data;
  console.log(data);
  });




}
}
