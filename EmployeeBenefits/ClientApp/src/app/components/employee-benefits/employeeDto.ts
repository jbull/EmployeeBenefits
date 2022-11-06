export interface EmployeeDto {
    id:Number;
    firstName: string;
    lastName: string;
    dependents: DependentDto[];
    monthlyCost: Number;
    yearlyCost: Number;
}

export interface DependentDto {
    id:Number;
    employeeId: Number;
    firstName: string;
    lastName: string;
}
