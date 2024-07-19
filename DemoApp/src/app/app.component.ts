import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeComponent } from './app.employeecomponent';
import { EmployeeList } from './app.employeelist';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet , EmployeeComponent , EmployeeList],
 template : `<div  style="border: 1px solid black; padding : 10px ; ">
                <app-employee></app-employee>
                 <app-employeelist></app-employeelist>
                </div>
            `
})
export class AppComponent {
  title = 'DemoApp';
}
