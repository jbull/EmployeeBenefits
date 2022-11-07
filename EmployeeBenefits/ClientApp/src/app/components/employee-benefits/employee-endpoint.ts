import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeDto } from './employeeDto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeEndpoint {

  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};
  
constructor(private  http: HttpClient) { 

}

public baseUrl = environment.baseUrl;
get employeesUrl() { return this.baseUrl + '/api/employees'; }

getEmployeesEndpoint<T>(): Observable<T> {
  const endpointUrl = this.employeesUrl;

  return this.http.get<T>(endpointUrl).pipe(
    catchError(
      this.handleError
    ));
}

getEmployeeByIdEndpoint<T>(employeeId: Number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.get<T>(endpointUrl).pipe(
    catchError(
      this.handleError
    ));
}

getNewEmployeeEndpoint<T>(employee: EmployeeDto): Observable<T> {
  const endpointUrl = this.employeesUrl;
  const headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');
  return this.http.post<T>(endpointUrl, JSON.stringify(employee), { 'headers': headers }).pipe(
    catchError(
      this.handleError
    ));
}

getUpdateEmployeeEndpoint<T>(employeeId: Number, employee: EmployeeDto): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.post<T>(endpointUrl, JSON.stringify(employee)).pipe(
    catchError(
      this.handleError
    ));
}

getDeleteEmployeeEndpoint<T>(employeeId: Number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.delete<T>(endpointUrl).pipe(
    catchError(
      this.handleError
    ));
}


handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\\nMessage: ${error.message}`;
    }

    return throwError(errorMessage);
  }
  
}
