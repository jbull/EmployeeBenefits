import { Injectable } from '@angular/core';
import { EmployeeEndpoint } from './employee-endpoint';
import { EmployeeDto } from './employeeDto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private employeeEndpoint: EmployeeEndpoint) {

  }

  getEmployees() {
    return this.employeeEndpoint.getEmployeesEndpoint<EmployeeDto[]>();
  }

  getEmployee(employeeId: Number) {
    return this.employeeEndpoint.getEmployeeByIdEndpoint<EmployeeDto>(employeeId);
  }

  updateEmployee(employee: EmployeeDto) {
    return this.employeeEndpoint.getUpdateEmployeeEndpoint(employee.id, employee);
  }

  newEmployee(employee: EmployeeDto) {
    return this.employeeEndpoint.getNewEmployeeEndpoint<EmployeeDto>(employee);
  }

  deleteemployee(employeeId: number) {
    return this.employeeEndpoint.getDeleteEmployeeEndpoint<boolean>(employeeId);
  }
}
