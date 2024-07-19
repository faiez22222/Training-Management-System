import { Component , OnInit} from "@angular/core";
import { FormBuilder , FormGroup , Validator, Validators } from "@angular/forms";
import { CustomEmailValidator } from "../CustomEmailValidators";
import { EmployeeService } from "../services/employee-services";
import { response } from "express";
import { error } from "console";

@Component({
    selector : 'create-std-component' ,
    templateUrl : './create-std.Component.html'
})

export class Students implements OnInit
{
    myForm: FormGroup = this.formBuilder.group({}); 
   constructor (private formBuilder : FormBuilder , private studentService : EmployeeService)
   {

   }
   ngOnInit() {
       this.myForm = this.formBuilder.group({
         FirstName: [""  , Validators.required] ,
         MiddleName : [""] ,
         LastName : ["" , Validators.required] ,
         Age: ["", [Validators.required, Validators.max(100), Validators.min(1)]],
         DateOfBirth : [""] ,
         Gender : [""] ,
         Email : ["" ,[Validators.required , CustomEmailValidator]] ,
         Country : [""] , 
       })
   }
   onSubmit()
   {
     if(this.myForm.valid)
        {
             this.studentService.addStudent(this.myForm.value).subscribe(response=>{
                console.log("student added successfully" , response);
             }, error=>{
                console.error("Error adding student" , error);
             })
        }
   }
}