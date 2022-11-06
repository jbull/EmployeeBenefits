import { Injectable } from '@angular/core';
import { EmployeeBenefitEndpointService } from './employee-benefit-endpoint.service';
import { EmployeeDto } from './employeeDto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeBenefitsService {

  constructor(private employeeEndpoint: EmployeeBenefitEndpointService) {

  }

  getEmployees() {
   // return this.employeeEndpoint.getEmployeesEndpoint<EmployeeDto[]>();
  }

  getEmployee(employeeId: number) {
   // return this.employeeEndpoint.getemployeeByIdEndpoint<EmployeeDto>(employeeId);
  }

  updateEmployee(employee: EmployeeDto) {
   // return this.employeeEndpoint.getUpdateemployeeEndpoint(EmployeeDto, employee.id);
  }

  newEmployee(employee: EmployeeDto) {
   // return this.employeeEndpoint.getNewemployeeEndpoint<EmployeeDto>(employee);
  }

  deleteemployee(employeeOremployeeId: number) {
      // return this.employeeEndpoint.getDeleteemployeeEndpoint<boolean>(employeeOremployeeId);
  }
}
