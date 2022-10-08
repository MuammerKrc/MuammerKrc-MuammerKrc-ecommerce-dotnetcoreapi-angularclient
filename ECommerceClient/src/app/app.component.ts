import { Component } from '@angular/core';
import { JQueryStyleEventEmitter } from 'rxjs/internal/observable/fromEvent';

declare var $:any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ECommerceClient';

}
