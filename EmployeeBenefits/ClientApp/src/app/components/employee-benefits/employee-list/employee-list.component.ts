
import { Component, isDevMode, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { EmployeeDto } from '../employeeDto';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  
  displayedColumns = ['id','lastName', 'firstName'];
  loadingIndicator: boolean = false;
  dataSource : MatTableDataSource<EmployeeDto>;

  constructor(private employeeBenefitsService: EmployeeService,
    private router: Router) { 

    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.loadData();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private loadData() {
    this.loadingIndicator = true;
    this.employeeBenefitsService.getEmployees().subscribe(
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
  
  public editEmployee (employee?: EmployeeDto){
    this.router.navigateByUrl("edit-employee")
  }

  public updateProject(employee: EmployeeDto) {
    
  }

  public deleteEmployee (employee?: EmployeeDto){

  }
}

