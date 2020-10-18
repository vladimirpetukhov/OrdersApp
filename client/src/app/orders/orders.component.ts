import { AlertifyService } from './../_services/alertify.service';
import { OrderService } from './../_services/order.service';
import { Order } from './../_models/order';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Pagination, PaginatedResult } from '../_models/pagination';


@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  //#region fields
  pagination: Pagination;
  orders: Order[];
  //#endregion

  //#region ctor
  constructor(private route: ActivatedRoute, private orderService: OrderService, private alertify: AlertifyService) { }
  //#endregion

  ngOnInit() {
    this.route.data.subscribe(data => {
      console.log(data);
      this.orders = data['orders'].result;
      this.pagination = data['orders'].pagination;
    });

  }

  loadOrders() {
    this.orderService
      .getOrders(this.pagination.currentPage, this.pagination.itemsPerPage, null)
      .subscribe((res: PaginatedResult<Order[]>) => {
        this.orders = res.result;
        console.log(res);
        this.pagination = res.pagination;
      }, error => {
        this.alertify.error(error);
      });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadOrders();
  }

}
