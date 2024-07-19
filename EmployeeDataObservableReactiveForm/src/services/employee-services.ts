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
        return this._http.get<EmployeeLists[]>("http://localhost:3000/employees");
    }
    
    private apiUrl = "http://localhost:3000/employees";
    addStudent(student:any):Observable<any>
    {
        return this._http.post<any>(this.apiUrl , student);
    }
}

