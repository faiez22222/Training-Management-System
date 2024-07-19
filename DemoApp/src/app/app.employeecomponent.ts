import { Component } from "@angular/core";


import { RouterOutlet } from '@angular/router';

@Component({
selector: 'app-employee', 
standalone: true,
imports: [RouterOutlet],
 templateUrl : './app.employeecomponent.html'
})
export class EmployeeComponent {
  title = 'EmployeeApp';
}
