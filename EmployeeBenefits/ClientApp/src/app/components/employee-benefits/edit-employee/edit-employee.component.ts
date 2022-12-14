import { Component, Input, isDevMode, OnInit, ViewChild, AfterViewInit, } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
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
        if(!Number.isNaN(id)){
          this.getEmployee(id);
        }
       
        this.isNewEmployee = Number.isNaN(id);
      }
    );

    this.buildForm();
  }

  // ngOnChanges() {
  //   if (this.employee == null) {
  //     this.isNewEmployee = true;
  //     this.employee = new Employee();
  //   } else {
  //     this.isNewEmployee = false;
  //   }

  //   this.resetForm();
  // }

  public onDependentsModified(id: any){
    this.getEmployee(id)
  }

  private buildForm() {
    this.employeeForm = this.formBuilder.group({
      id:[''],
      firstName: new FormControl('', Validators.required),
      lastName: ['', Validators.required],
    });
  }

  private resetForm(){
    this.employeeForm.reset();
  }

  private getEmployee(id: number){
    this.employeeService
    .getEmployee(id)
    .subscribe((employee: Employee) => {
      this.employee = employee;
      this.patchEmployeeForm();
    });
  }

  private patchEmployeeForm(){
    this.employeeForm.patchValue({
      id: this.employee.id,
      firstName: this.employee.firstName,
      lastName: this.employee.lastName,
    });
  }

  public save() {
    // if (!this.form?.submitted) {
    //   // Causes validation to update.
    //   this.form.onSubmit(null);
    //   return;
    // }

    if (!this.employeeForm.valid){
      return;
    }

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
      yearlySalary: this.employee.yearlySalary,
      checkGrossPay: this.employee.checkGrossPay,
      costPerCheck: this.employee.costPerCheck,
      yearlyCost: this.employee.yearlyCost,
      discounts: this.employee.discounts,
      dependents: this.employee.dependents
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

  public hasError(controlName: string, errorName: string) {
    return this.employeeForm.controls[controlName]?.hasError(errorName);
  }
}
 