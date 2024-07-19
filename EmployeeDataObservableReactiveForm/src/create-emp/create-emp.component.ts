import { Component } from "@angular/core";

@Component({
    selector : 'create-app-component' ,
    templateUrl : './create-emp.component.html'
})

export class CreateEmp{
    model:any = {
        name : "" ,
        email : "" ,
        password : '' ,
        country : '',
        gender : ''
    } ;
    submitted = false ;

    onSubmit(form : any)
    {
        this.submitted=true ;
        if(form.invalid)
            {
                return ;
            }
        console.log('FormSubmitted' , form.value);
    }
}