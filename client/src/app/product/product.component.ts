import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Category } from './../_models/category';
import { AlertifyService } from './../_services/alertify.service';

import { ProductService } from './../_services/product.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Product } from '../_models/product';
import { Pagination, PaginatedResult } from '../_models/pagination';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})


export class ProductComponent implements OnInit {

  //#region fields
  createForm: FormGroup;
  pagination: Pagination;
  products: Product[];
  //#endregion

  //#region ctor
  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private productService: ProductService,
    private alertify: AlertifyService,
    private http: HttpClient) {
    this.createForm = this.fb.group({
      'name': ['', Validators.required],
      'price': ['', Validators.required],
      'description': ['', Validators.required],
      'category': []
    });
  }
  //#endregion

  ngOnInit() {
    this.route.data.subscribe(data => {
      console.log(data);
      this.products = data['products'].result;
      this.pagination = data['products'].pagination;
    });
  }

  loadProducts(){
    this.productService
      .getProducts(this.pagination.currentPage, this.pagination.itemsPerPage, null)
      .subscribe((res: PaginatedResult<Product[]>) => {
        this.products = res.result;
        console.log(res);
        this.pagination = res.pagination;
      }, error => {
        this.alertify.error(error);
      });
  }

  //#region props
  get productName() {
    return this.createForm.get('name');
  }

  get productPrice() {
    return this.createForm.get('price');
  }
  get productDescription() {
    return this.createForm.get('description');
  }
  get productCategory() {
    return this.createForm.get('category');
  }
  //#region methods

  hide() {
    jQuery('#addProductModal').hide();
  }

  openAddModal() {
    jQuery('#addProductModal').show();
  }

  create() {
    this.productService.createProduct(this.createForm.value).subscribe(res => {
      console.log(res);
      jQuery('#addProductModal').hide();
      this.createForm.reset();

      this.alertify.success('Success!!!');
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadProducts();
  }

  //#endregion
}
