
import { Component, isDevMode, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { EmployeeDto } from '../employee.models';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  
  displayedColumns = ['id','lastName', 'firstName', 'actions'];
  loadingIndicator: boolean = false;
  dataSource : MatTableDataSource<EmployeeDto>;

  constructor(private employeeService: EmployeeService,
    private router: Router) { 

    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.loadData();
  }


  private loadData() {
    this.loadingIndicator = true;
    this.employeeService.getEmployees().subscribe(
      employees => this.onDataLoadSuccessful(employees),
      error => this.onDataLoadFailed(error)
    );
  }

  private onDataLoadFailed(error: any) {
    this.loadingIndicator = false;
    if(isDevMode())
      console.log(error);
  }
  
  private onDataLoadSuccessful(employees: any) {
    if(isDevMode())
      console.log(employees)

    this.loadingIndicator = false;
    this.dataSource.data = employees;
  }
  
  public addEmployee (){
    this.router.navigate([`edit-employee`]);
  }
  
  public editEmployee (id?: number){
    this.router.navigate([`edit-employee/${id}`]);
  }

  public editDependents(id?: number){
    this.router.navigate([`employee-dependents/${id}`]);
  }

  public deleteEmployee (employee: EmployeeDto){
     this.employeeService.deleteEmployee(employee.id).subscribe(() => {
     }, err => {
        if(isDevMode())
          console.log(err);
     });
  }
}

