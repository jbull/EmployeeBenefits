import { Component, Input, isDevMode, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Router, ActivatedRoute } from '@angular/router';
import { Dependent, DependentDto, Employee, EmployeeDto } from '../employee.models';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-dependents',
  templateUrl: './employee-dependents.component.html',
  styleUrls: ['./employee-dependents.component.css']
})
export class EmployeeDependentsComponent implements OnInit {

  @Input() employee!: Employee;
  
  
  displayedColumns = ['id','lastName', 'firstName', 'actions'];
  loadingIndicator: boolean = false;
  dataSource : MatTableDataSource<DependentDto>;
  
  dependentForm!: FormGroup;
  dependent: Dependent = new Dependent;

  constructor(private employeeService: EmployeeService, 
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) {

      this.dataSource = new MatTableDataSource();
    
    }

  ngOnInit() {
    this.buildForm();
   
  }

  ngOnChanges(changes: SimpleChanges) {
    if(this.employee?.id > 0)
    {
      this.loadDependents();
    }

    console.log(changes);
  }
  
  private loadDependents() {
    this.loadingIndicator = true;
    this.employeeService.getDependents(this.employee.id).subscribe(
      dependents => this.onDataLoadSuccessful(dependents),
      error => this.onDataLoadFailed(error)
    );
  }

  private onDataLoadSuccessful(employees: any) {
    if(isDevMode())
      console.log(employees)

    this.loadingIndicator = false;
    this.dataSource.data = employees;
  }

  private onDataLoadFailed(error: any) {
    this.loadingIndicator = false;
    if(isDevMode())
      console.log(error);
  }

  private buildForm() {
    this.dependentForm = this.formBuilder.group({
      firstName: ['', Validators.required, Validators.maxLength(50)],
      lastName: ['', Validators.required, Validators.maxLength(50)],
    });
  }

  public save() {
    const model = this.getDependentsModel();

    this.employeeService.newDependent(model).subscribe(
      dependent => this.onSaveCompleted(dependent),
        error => this.onSaveFailed(error));
  }

  private getDependentsModel(): DependentDto {
    const formModel = this.dependentForm.value;

    return {
      id: 0,
      employeeId: this.employee.id,
      firstName: formModel.firstName,
      lastName: formModel.lastName
    };
  }

  private onSaveCompleted(dependent?: DependentDto) {
    if(isDevMode())
    console.log(dependent)

    this.router.navigateByUrl("employee-list")
  }

  private onSaveFailed(error: any) {
    if(isDevMode())
      console.log(error)
  }


  public deleteDependent(id: number) {
    // TODO:
  }

}
