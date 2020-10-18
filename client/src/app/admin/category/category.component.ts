import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  tableHeaders = ['Header 1', 'Header 2', 'Header 3'];
  tableRows = [
    ['Cell', 'Cell', 'Cell'],
    ['Cell', 'Cell', 'Cell'],
    ['Cell', 'Cell', 'Cell']
  ];
  constructor() { }

  ngOnInit() {
  }

}
