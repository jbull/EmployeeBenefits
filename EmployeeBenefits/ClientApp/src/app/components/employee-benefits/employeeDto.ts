export interface EmployeeDto {
    id:Number;
    firstName: string;
    lastName: string;
    dependents: DependentDto[];
    monthlyCost: Number;
    yearlyCost: Number;
}

export class Employee {
    id:Number = 0;
    firstName?: string;
    lastName?: string;
}

export interface DependentDto {
    id:Number;
    employeeId: Number;
    firstName: string;
    lastName: string;
}
