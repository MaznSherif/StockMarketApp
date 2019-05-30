import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import {Orders} from '../fetch-orders/orders.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public order: Orders[];

  private hubConnection: signalR.HubConnection;
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                              .withUrl('https://localhost:5001/orderhub', {
                                skipNegotiation: true,
                                transport: signalR.HttpTransportType.WebSockets
                              })
                              .build();
    this.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while starting connection: ' + err));

  }



  public addfetchorderslistener = () => {
  this.hubConnection.on('transferorders', (data) => {
  this.order = data;
  console.log(data);
  });




}
}
