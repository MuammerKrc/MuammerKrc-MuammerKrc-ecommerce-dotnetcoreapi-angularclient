import { Inject, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})

export class SignalRService {

  constructor(@Inject("baseSignalRUrl") private baseSignalRUrl: string) { }

  start(hubUrl: string): HubConnection {
    debugger;
    var url = this.baseSignalRUrl + hubUrl;
    if (_signalRConnection == undefined || _signalRConnection || _signalRConnection?.state == HubConnectionState.Disconnected) {
      const builder: HubConnectionBuilder = new HubConnectionBuilder();
      const connection: HubConnection = builder.withUrl(url).withAutomaticReconnect().build();

      connection.start()
        .then(() => console.log("product hub connected"))
        .catch(err => setTimeout(() => {
          this.start(url)
        }, 3000));

      connection.onreconnected(connectionId => console.log("Reconnected"));
      connection.onreconnecting(err => console.log("Reconnecting"));
      connection.onclose(err => console.log("Closer reconnection"));
      _signalRConnection = connection;
    }
    return _signalRConnection;
  }

  invoke(hubUrl: string, producerName: string, message: any, successCallback?: (value: any) => void, errorCallback?: (error: any) => void) {
    this.start(hubUrl).invoke(producerName, message)
      .then(successCallback)
      .catch(errorCallback);
  }

  on(hubUrl: string, producerName: string, callback: (...message: any) => void) {
    debugger;
    this.start(hubUrl).on(producerName, callback);
  }
}

export enum HubUrls {
  ProductHub = "products-hub",
  OrderHub = "orders-hub"
}

export let _signalRConnection: HubConnection;
