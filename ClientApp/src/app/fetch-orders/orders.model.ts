import {Stock} from './stock.model';
import {Client} from './client.model';
import {Broker} from './broker.model';
export class Orders {
  quantity: number;
  commission: number;
  stock: Stock;
  client: Client;
  broker: Broker;

  orderedby() {
    if (this.broker === null ) {
      return this.client;
    } else {
      return this.broker;
    }
  }


}





