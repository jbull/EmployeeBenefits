export interface EmployeeDto {
    id: number;
    firstName: string;
    lastName: string;
    yearlySalary: number;
    checkGrossPay: number;
    costPerCheck: number;
    yearlyCost: number;
    discounts: number;
    dependents: number;
}

export class Employee {
    id: number = 0;
    firstName?: string;
    lastName?: string;
    yearlySalary: number = 0;
    checkGrossPay: number = 0;
    costPerCheck: number = 0;
    yearlyCost: number  = 0;
    discounts: number = 0;
    dependents: number = 0;
}

export interface DependentDto {
    id: number;
    employeeId: number;
    firstName: string;
    lastName: string;
}

export class Dependent {
    id: number = 0;
    employeeId: number = 0;
    firstName?: string;
    lastName?: string;
}

