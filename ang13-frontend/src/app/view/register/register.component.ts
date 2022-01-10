import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/_services/auth.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  hide = true;
  form: any = {
    username: null,
    password: null,
    userType: "",
  };
  userTypes: Array<string>;
  isSuccessful = false;
  isSignUpFailed = false;
  isAdmin = false;
  errorMessage = '';

  

  constructor(private authService: AuthService, private token : TokenStorageService, private _snackBar: MatSnackBar) {
    this.userTypes = ["Admin", "Staff", "Client"];
   }

  ngOnInit(): void {
    this.isAdmin = this.token.getUser()?.userType == "Admin";
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, "Close", {
      duration: 5000,
    });
  }

  OnSubmit(): void {
    const { username, password, userType } = this.form;
    if (this.isAdmin){
      this.authService.RegisterStaff(username, password, userType).subscribe(
        () => {
          this.isSuccessful = true;
          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
          this.openSnackBar('An error occurred while registering an account.');
        }
      );
    }
    else{
      this.authService.Register(username, password).subscribe(
        () => {
          this.isSuccessful = true;
          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
          this.openSnackBar('An error occurred while registering an account.');
        }
      );
    }    
  }
}
