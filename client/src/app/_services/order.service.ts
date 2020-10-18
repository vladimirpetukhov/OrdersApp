import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { Product } from '../_models/Product';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';
import { Order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {


  //#region fields
  baseUrl = environment.apiUrl;
  private create = environment.apiUrl + 'order/create-order';
  private getAll = environment.apiUrl + 'order/get-orders';
  //#endregion

  //#region ctor
  constructor(private http: HttpClient, private authService: AuthService) { }
  //#endregion

  //#region methods
  createProduct(data) {
    return this.http.post(this.create, data);
  }

  public getOrders(page?, itemsPerPage?, productParams?): Observable<PaginatedResult<Order[]>> {
    const paginatedResult: PaginatedResult<Order[]> = new PaginatedResult<Order[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (productParams != null) {
      // params = params.append('minAge', productParams.minAge);
      // params = params.append('maxAge', productParams.maxAge);
      // params = params.append('gender', productParams.gender);
      // params = params.append('orderBy', productParams.orderBy);
    }
    return this.http.get<Order[]>(this.baseUrl + 'product/get-orders', { observe: 'response', params,withCredentials:true})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }
  //#endregion

}
