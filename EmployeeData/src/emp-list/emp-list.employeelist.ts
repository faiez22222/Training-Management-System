import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
    selector : 'app-employeelist' ,
    templateUrl : './emp-list.employeelist.html'

})

export class EmployeeList
{
    employees : any[]=[{
        code:'1', name:'Tom', gender:'male',salary:4000, dob :'01/01/1998'
      },
      {
          code:'2', name:'John', gender:'male',salary:6000, dob :'10/04/1997'
        },
        {
          code:'3', name:'Mark', gender:'male',salary:5000, dob :'12/05/1996'
        },
        {
          code:'4', name:'Mary', gender:'Female',salary:2000, dob :'05/07/1995'
        }];
}