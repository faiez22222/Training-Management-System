import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from '../emp/emp.employeecomponent';
import { EmployeeList } from '../emp-list/emp-list.employeelist';
import { FormsModule } from '@angular/forms';
import { EmployeeTitlePipe } from '../Pipe/employee-title.pipe';
import { RouterModule , Routes } from '@angular/router';

const appRoutes :Routes=[
  {path:'emp-list' , component : EmployeeList} ,
  {path : 'emp-data' , component: EmployeeComponent} ,
   {path : '' , redirectTo : '/emp-list' , pathMatch:'full'  } ,
   {path : '**' , component:EmployeeList}
] 

@NgModule({
  declarations: [
    AppComponent , EmployeeComponent , EmployeeList , EmployeeTitlePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule ,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
