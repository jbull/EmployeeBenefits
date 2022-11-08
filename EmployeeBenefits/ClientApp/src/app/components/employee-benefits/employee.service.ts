import { Injectable } from '@angular/core';
import { EmployeeEndpoint } from './employee-endpoint';
import { DependentDto, EmployeeDto } from './employee.models';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private employeeEndpoint: EmployeeEndpoint) {

  }

  getEmployees() {
    return this.employeeEndpoint.getEmployeesEndpoint<EmployeeDto[]>();
  }

  getEmployee(employeeId: number) {
    return this.employeeEndpoint.getEmployeeByIdEndpoint<EmployeeDto>(employeeId);
  }

  newEmployee(employee: EmployeeDto) {
    return this.employeeEndpoint.getNewEmployeeEndpoint<EmployeeDto>(employee);
  }

  updateEmployee(employee: EmployeeDto) {
    return this.employeeEndpoint.getUpdateEmployeeEndpoint(employee.id, employee);
  }

  deleteEmployee(employeeId: number) {
    return this.employeeEndpoint.getDeleteEmployeeEndpoint<boolean>(employeeId);
  }

  getDependents(employeeId: number) {
    return this.employeeEndpoint.getDependentsEndpoint<DependentDto[]>(employeeId);
  }

  newDependent(dependent: DependentDto) {
    return this.employeeEndpoint.getNewDependentEndpoint<DependentDto>(dependent);
  }

  updateDependent(dependent: DependentDto) {
    return this.employeeEndpoint.getUpdateDependentEndpoint(dependent.id, dependent);
  }

  deleteDependent(dependentId: number) {
    return this.employeeEndpoint.getDeleteDependentEndpoint<boolean>(dependentId);
  }
}
