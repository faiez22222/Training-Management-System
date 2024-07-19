import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable , map } from "rxjs";
import { EmployeeLists } from "../models/EmployeeLists";

@Injectable()
export class EmployeeService
{
    constructor(private _http:HttpClient)
    {

    }

    employees:any[] =[] ;
    getEmployees():Observable<EmployeeLists[]>
    {
        return this._http.get<EmployeeLists[]>("http://localhost:5230/api/Employee");
    }
}

