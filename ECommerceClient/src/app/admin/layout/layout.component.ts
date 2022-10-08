import { Component, OnInit } from '@angular/core';
import { AlertifyOptions, AlertifyService } from 'src/app/services/common/alertify.service';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor(private alertify:AlertifyService) { }

  ngOnInit(): void {
    this.alertify.message('merhaba',new AlertifyOptions());
  }
}

