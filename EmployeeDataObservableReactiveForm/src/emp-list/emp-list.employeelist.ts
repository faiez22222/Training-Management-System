import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { EmployeeService } from "../services/employee-services";

@Component({
    selector : 'app-employeelist' ,
    templateUrl : './emp-list.employeelist.html'

})

export class EmployeeList
{
   employees:any[]=[];
   constructor(private _empservice:EmployeeService)
   {

   }
   ngOnInit()
   {
     this._empservice.getEmployees().subscribe(data=>{
      this.employees=data;
     })
   }
}