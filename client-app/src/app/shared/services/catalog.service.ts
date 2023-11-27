import { Injectable, inject, signal } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, map, throwError } from 'rxjs';
import { toSignal } from '@angular/core/rxjs-interop';

import { Product } from '../models/product';
import { Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  // Inject the HttpClient service
  http = inject(HttpClient);

  // TODO: Add environments (ng g environments) and read the value from it
  catalogUrl = 'http://localhost:5299/api/v1/catalog';

  // Retrieve the products from the API using RxJS
  private products$ = this.http.get<Pagination<Product[]>>(`${this.catalogUrl}/products`).pipe(
    map((x) => 
      x.data
    ),
    catchError(this.handleError)
  );

  // Expose signals from this service
  products = toSignal(this.products$, {initialValue: [] as Product[]});
  selectedProduct = signal<Product | undefined>(undefined);

  productSelected(id: number) {
    const foundProduct = this.products().find(x => x.id === id);
    this.selectedProduct.set(foundProduct);
  }

  getDeletedProducts() {
    return this.http.get<Product[]>(`${this.catalogUrl}/products/deleted`);
  }

  getProductById(id: number) {
    return this.http.get<Product>(`${this.catalogUrl}/products/${id}`);
  }  

  private handleError(err: HttpErrorResponse): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message
        }`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }

}
