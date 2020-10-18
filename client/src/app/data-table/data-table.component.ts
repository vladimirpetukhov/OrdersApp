import { Component, OnInit, Input, Output } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css']
})
export class DataTableComponent<T> implements OnInit {

  //#region fields
  @Input() dtOptions: DataTables.Settings;
  @Input() data: T[];
  //#endregion

  //#region ctor
  constructor() { }
  //#endregion

  ngOnInit() {
  }


}
