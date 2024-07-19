import { Component } from "@angular/core";


import { RouterOutlet } from '@angular/router';

@Component({
selector: 'app-employee', 
 templateUrl : './emp.employeecomponent.html'
})
export class EmployeeComponent {
    firstName:string="John";
    lastName:string="Moore"
    Country:string="USA";
    gender:string="Male" ;
    state:string="California" ;
}
