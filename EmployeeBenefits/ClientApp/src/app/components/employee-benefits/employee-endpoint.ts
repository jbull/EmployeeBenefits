import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DependentDto, EmployeeDto } from './employee.models';

@Injectable({
  providedIn: 'root'
})
export class EmployeeEndpoint {
  
constructor(private  http: HttpClient) { 

}

public baseUrl = environment.baseUrl;

get employeesUrl() { return this.baseUrl + '/api/employees'; }

get headers() { return new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');
}

getEmployeesEndpoint<T>(): Observable<T> {
  const endpointUrl = this.employeesUrl;

  return this.http.get<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getEmployeeByIdEndpoint<T>(employeeId: number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.get<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getNewEmployeeEndpoint<T>(employee: EmployeeDto): Observable<T> {
  const endpointUrl = this.employeesUrl;

  return this.http.post<T>(endpointUrl, JSON.stringify(employee), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getUpdateEmployeeEndpoint<T>(employeeId: number, employee: EmployeeDto): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.post<T>(endpointUrl, JSON.stringify(employee), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getDeleteEmployeeEndpoint<T>(employeeId: number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.delete<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getDependentsEndpoint<T>(employeeid: number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/dependents/${employeeid}`;

  return this.http.get<T>(endpointUrl, { 'headers': this.headers } ).pipe(
    catchError(
      this.handleError
    ));
}

getNewDependentEndpoint<T>(dependent: DependentDto): Observable<T> {
  const endpointUrl = this.employeesUrl;

  return this.http.post<T>(endpointUrl, JSON.stringify(dependent), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getUpdateDependentEndpoint<T>(dependentId: number, dependent: DependentDto): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${dependentId}`;

  return this.http.post<T>(endpointUrl, JSON.stringify(dependent), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

getDeleteDependentEndpoint<T>(employeeId: number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.delete<T>(endpointUrl, { 'headers': this.headers }).pipe(
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
