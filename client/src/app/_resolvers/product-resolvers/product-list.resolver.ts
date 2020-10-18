import {Injectable} from '@angular/core';
import {Product} from '../../_models/product';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { ProductService} from '../../_services/product.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ProductListResolver implements Resolve<Product[]> {
  pageNumber = 1;
  pageSize = 5;

  constructor(private productService: ProductService, private router: Router,
      private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Product[]> {
      return this.productService.getProducts(this.pageNumber, this.pageSize, null)
      .pipe(
          catchError(error => {
              this.alertify.error('Problem retrieving data');
              this.router.navigate(['/home']);
              return of(null);
          })
      );
  }
}
