import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { Product } from '../_models/Product';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  //#region fields
  baseUrl = environment.apiUrl;
  private create = environment.apiUrl + 'product/create-product';
  private getAll = environment.apiUrl + 'product/get-products';
  //#endregion

  //#region ctor
  constructor(private http: HttpClient, private authService: AuthService) { }
  //#endregion

  //#region methods
  createProduct(data) {
    return this.http.post(this.create, data);
  }

  public getProducts(page?, itemsPerPage?, productParams?): Observable<PaginatedResult<Product[]>> {
    const paginatedResult: PaginatedResult<Product[]> = new PaginatedResult<Product[]>();

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
    return this.http.get<Product[]>(this.baseUrl + 'product/get-products', { observe: 'response', params})
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
