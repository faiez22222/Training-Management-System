import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from '../emp/emp.employeecomponent';
import { EmployeeList } from '../emp-list/emp-list.employeelist';
import { FormsModule } from '@angular/forms';
import { EmployeeTitlePipe } from '../Pipe/employee-title.pipe';
import { RouterModule, Routes } from '@angular/router';
import { CreateEmp } from '../create-emp/create-emp.component';
import { EmployeeService } from '../services/employee-services';
import { provideHttpClient, withFetch } from '@angular/common/http'; // Import withFetch
import { ReactiveFormsModule } from '@angular/forms';
import { Students } from '../create-std/create-std.Component';
import { CustomEmailValidator } from '../CustomEmailValidators';
const appRoutes: Routes = [
  { path: 'emp-list', component: EmployeeList },
  { path: 'emp-data', component: EmployeeComponent },
  { path: 'emp-create', component: CreateEmp },
  { path: 'std-create', component: Students },
  { path: '', redirectTo: '/emp-list', pathMatch: 'full' },
  { path: '**', component: EmployeeList }
];

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    EmployeeList,
    EmployeeTitlePipe,
    CreateEmp ,
    Students ,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule.forRoot(appRoutes) ,
    ReactiveFormsModule
  ],
  providers: [
    EmployeeService,
    provideHttpClient(withFetch()) // Add withFetch() here
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
