import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeBenefitEndpointService {

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
