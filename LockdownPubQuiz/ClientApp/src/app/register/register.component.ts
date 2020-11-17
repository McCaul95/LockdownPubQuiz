import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

    registerForm;
    loading = false;
    submitted = false;
    returnUrl: string;
    error = '';
    emailPattern= "^(?=.*[0-9])(?=.*[@])$";
    pwdPattern = "^(?=.*[0-9])(?=.*[a-z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$";

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService) { 
      
      this.registerForm = this.formBuilder.group({
        email: [ '', Validators.required, Validators.pattern(this.emailPattern)],
        username: [ '', Validators.required],
        password: [ '', Validators.required, Validators.pattern(this.pwdPattern)],
        confirmPassword: [ '', Validators.required, Validators.pattern(this.pwdPattern)]
      }); 
    }

  ngOnInit(): void {
    console.log(this.registerForm.controls.email)
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }


  async onSubmit(registerForm){
    if (this.registerForm !== null){
      console.log(this.registerForm)
        var response = await this.authService.register(this.registerForm.value).toPromise();
        console.log(response);
          this.router.navigate(['/login']);
    }
    else{
      return console.log("Login Failed");
    }
    
  }
}
