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
get dependentsUrl() { return this.baseUrl + '/api/dependents'; }

get headers() { return new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');
}

public getEmployeesEndpoint<T>(): Observable<T> {
  const endpointUrl = this.employeesUrl;

  return this.http.get<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getEmployeeByIdEndpoint<T>(employeeId: number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.get<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getNewEmployeeEndpoint<T>(employee: EmployeeDto): Observable<T> {
  const endpointUrl = this.employeesUrl;

  return this.http.post<T>(endpointUrl, JSON.stringify(employee), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getUpdateEmployeeEndpoint<T>(employeeId: number, employee: EmployeeDto): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.put<T>(endpointUrl, JSON.stringify(employee), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getDeleteEmployeeEndpoint<T>(employeeId: number): Observable<T> {
  const endpointUrl = `${this.employeesUrl}/${employeeId}`;

  return this.http.delete<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getDependentsEndpoint<T>(employeeid: number): Observable<T> {
  const endpointUrl = `${this.dependentsUrl}/dependents/${employeeid}`;

  return this.http.get<T>(endpointUrl, { 'headers': this.headers } ).pipe(
    catchError(
      this.handleError
    ));
}

public getNewDependentEndpoint<T>(dependent: DependentDto): Observable<T> {
  const endpointUrl = `${this.dependentsUrl}/dependents`;

  return this.http.post<T>(endpointUrl, JSON.stringify(dependent), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getUpdateDependentEndpoint<T>(dependentId: number, dependent: DependentDto): Observable<T> {
  const endpointUrl = `${this.dependentsUrl}/dependents/${dependentId}`;

  return this.http.post<T>(endpointUrl, JSON.stringify(dependent), { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public getDeleteDependentEndpoint<T>(employeeId: number): Observable<T> {
  const endpointUrl = `${this.dependentsUrl}/dependents/${employeeId}`;

  return this.http.delete<T>(endpointUrl, { 'headers': this.headers }).pipe(
    catchError(
      this.handleError
    ));
}

public handleError(error: HttpErrorResponse) {
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
