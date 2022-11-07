import { Component, Input, isDevMode, OnInit, ViewChild, AfterViewInit, } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee, EmployeeDto } from '../employeeDto';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  employeeForm!: FormGroup;
  employee: Employee = new Employee;
  employeeId!: Number;
  isNewEmployee = true;

  constructor(private employeeService: EmployeeService, 
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) {
      this.route.params.subscribe(
        (params) => (this.employeeId = parseInt(params.id))
      );
     }

  ngOnInit() {
    this.getEmployee();
    this.buildForm();
  }

  private buildForm() {
    this.employeeForm = this.formBuilder.group({
      id:[''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      monthlyCost: [''],
      yearlyCost: [''],
      dependents: [''],
    });
  }

  getEmployee(){
    if(this.employeeId != null)
    this.employeeService
    .getEmployee(this.employeeId)
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

    const editedEmplloyee = this.getEmployeeModel();

    if (this.isNewEmployee) {
      this.employeeService.newEmployee(editedEmplloyee).subscribe(
        emp => this.saveCompleted(emp),
        error => this.saveFailed(error));
    } else {
      this.employeeService.updateEmployee(editedEmplloyee).subscribe(
        () => this.saveCompleted(editedEmplloyee),
        error => this.saveFailed(error));
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

  private saveFailed(error: any) {
    if(isDevMode())
      console.log(error)
  }

}
 