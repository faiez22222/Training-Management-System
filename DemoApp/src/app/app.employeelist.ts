import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
    selector : 'app-employeelist' ,
    standalone : true,
    imports : [RouterOutlet] ,
    templateUrl : './app.employeelist.html'

})

export class EmployeeList
{
    title = 'EmployeeList' ;
}