import { Injectable } from '@angular/core';
import { EmployeeEndpoint } from './employee-endpoint';
import { DependentDto, EmployeeDto } from './employee.models';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private employeeEndpoint: EmployeeEndpoint) {

  }

  public getEmployees() {
    return this.employeeEndpoint.getEmployeesEndpoint<EmployeeDto[]>();
  }

  public getEmployee(employeeId: number) {
    return this.employeeEndpoint.getEmployeeByIdEndpoint<EmployeeDto>(employeeId);
  }

  public newEmployee(employee: EmployeeDto) {
    return this.employeeEndpoint.getNewEmployeeEndpoint<EmployeeDto>(employee);
  }

  public updateEmployee(employee: EmployeeDto) {
    return this.employeeEndpoint.getUpdateEmployeeEndpoint(employee.id, employee);
  }

  public deleteEmployee(employeeId: number) {
    return this.employeeEndpoint.getDeleteEmployeeEndpoint<boolean>(employeeId);
  }

  public getDependents(employeeId: number) {
    return this.employeeEndpoint.getDependentsEndpoint<DependentDto[]>(employeeId);
  }

  public newDependent(dependent: DependentDto) {
    return this.employeeEndpoint.getNewDependentEndpoint<DependentDto>(dependent);
  }

  public updateDependent(dependent: DependentDto) {
    return this.employeeEndpoint.getUpdateDependentEndpoint(dependent.id, dependent);
  }

  public deleteDependent(dependentId: number) {
    return this.employeeEndpoint.getDeleteDependentEndpoint<boolean>(dependentId);
  }
}
