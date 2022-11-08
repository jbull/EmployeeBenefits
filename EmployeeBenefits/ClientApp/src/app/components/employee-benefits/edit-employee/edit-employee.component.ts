import { Component, Input, isDevMode, OnInit, ViewChild, AfterViewInit, } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee, EmployeeDto } from '../employee.models';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  employeeForm!: FormGroup;
  employee: Employee = new Employee;

  isNewEmployee = true;

  constructor(private employeeService: EmployeeService, 
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) {
    
  }

  ngOnInit() {
    this.route.params.subscribe(
      (params) => {
        let id = parseInt(params.id);
        this.getEmployee(id);
      }
    );

    this.buildForm();
  }

  private buildForm() {
    this.employeeForm = this.formBuilder.group({
      id:[''],
      firstName: ['', Validators.required, Validators.maxLength(50)],
      lastName: ['', Validators.required, Validators.maxLength(50)],
      monthlyCost: [''],
      yearlyCost: [''],
      dependents: [''],
    });
  }

  getEmployee(id: number){
    this.employeeService
    .getEmployee(id)
    .subscribe((employee: Employee) => {
      this.employee = employee;
      this.patchEmployeeForm();
    });
  }

  patchEmployeeForm(){
    this.employeeForm.patchValue({
      id: this.employee.id,
      firstName: this.employee.firstName,
      lastName: this.employee.lastName,
    });
  }

  public save() {
    const model = this.getEmployeeModel();

    if (this.isNewEmployee) {
      this.employeeService.newEmployee(model).subscribe(
        emp => this.saveCompleted(emp),
        error => this.onSaveFailed(error));
    } else {
      this.employeeService.updateEmployee(model).subscribe(
        () => this.saveCompleted(model),
        error => this.onSaveFailed(error));
    }
  }

  private getEmployeeModel(): EmployeeDto {
    const formModel = this.employeeForm.value;

    return {
      id: this.employee.id,
      firstName: formModel.firstName,
      lastName: formModel.lastName,
      monthlyCost: 0,
      yearlyCost: 0,
      dependents:[]
    };
  }

  private saveCompleted(employee?: EmployeeDto) {
    if(isDevMode())
    console.log(employee)
    
    if (employee) {
      this.employee = employee;
    }

    this.router.navigateByUrl("employee-list")
  }

  private onSaveFailed(error: any) {
    if(isDevMode())
      console.log(error)
  }

}
 