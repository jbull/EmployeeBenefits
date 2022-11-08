export interface EmployeeDto {
    id: number;
    firstName: string;
    lastName: string;
    dependents: DependentDto[];
    monthlyCost: number;
    yearlyCost: number;
}

export class Employee {
    id: number = 0;
    firstName?: string;
    lastName?: string;
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

