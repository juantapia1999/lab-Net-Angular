import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Shipper } from 'src/app/core/models/shipper.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Shipper[]> {
    return this.http
      .get<Shipper[]>(`${environment.API_URL}/shipper`)
      .pipe(
        catchError(
          (err) => this.handlerError(err)
        )
      );
  }

  add(shipper: any): Observable<any> {
    return this.http
      .post(`${environment.API_URL}/shipper`, shipper)
      .pipe(
        catchError(
          (err) => this.handlerError(err)
        )
      );
  }

  edit(id: number, shipper: any): Observable<any> {
    return this.http
      .put(`${environment.API_URL}/shipper/${id}`, shipper)
      .pipe(
        catchError(
          (err) => this.handlerError(err)
        )
      );
  }

  delete(id: number): Observable<any | void> {
    return this.http
      .delete(`${environment.API_URL}/shipper/${id}`)
      .pipe(
        catchError(
          (err) => this.handlerError(err)
        )
      );
  }

  private handlerError(err: any): Observable<never> {
    let errorMessage = "Ha ocurrido un error al obtener los datos";
    if (err) {
      errorMessage = `Error:\nCode -> ${err.status}\nMessage -> ${err.error.message}`;
    }
    console.log(errorMessage);
    alert(errorMessage);
    if (err.error.errors) {
      console.log("errores: ", err.error?.errors);
    }
    return throwError(errorMessage);
  }
}
