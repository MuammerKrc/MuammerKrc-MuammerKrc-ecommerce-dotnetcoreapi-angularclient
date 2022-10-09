import { Component, OnInit } from '@angular/core';
import { AlertifyOptions, AlertifyService } from 'src/app/services/common/alertify.service';
import { CustomToastrService, ToastrOptions } from 'src/app/services/common/custom-toastr.service';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
}

