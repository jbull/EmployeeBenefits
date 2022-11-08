import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from "@angular/material/input"; 
import { MatPaginatorModule } from "@angular/material/paginator"; 
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner"; 
import { MatSortModule } from "@angular/material/sort"; 
import { MatTableModule } from "@angular/material/table";
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatIconModule } from '@angular/material/icon';
import { EmployeeListComponent } from './components/employee-benefits/employee-list/employee-list.component';
import { EmployeeService } from './components/employee-benefits/employee.service';
import { EmployeeEndpoint } from './components/employee-benefits/employee-endpoint';
import { EditEmployeeComponent } from './components/employee-benefits/edit-employee/edit-employee.component';
import { MatButtonModule } from '@angular/material/button';
import { EmployeeDependentsComponent } from './components/employee-benefits/employee-dependents/employee-dependents.component';

@NgModule({
  declarations: [	
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EmployeeListComponent,
    EditEmployeeComponent,
    EmployeeDependentsComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    FormsModule, 
    ReactiveFormsModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'employee-list', component: EmployeeListComponent },
      { path: 'edit-employee', component: EditEmployeeComponent },
      { path: 'edit-employee/:id', component: EditEmployeeComponent },
      { path: 'employee-dependents/:id', component: EmployeeDependentsComponent }
    ]),

    BrowserAnimationsModule
  ],
  providers: [EmployeeService, EmployeeEndpoint],
  bootstrap: [AppComponent]
})
export class AppModule { }
