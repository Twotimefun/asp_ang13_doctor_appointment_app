import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/models/user.model';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  currentUser: any;
  errorMessage = '';
  form: User;
  isUpdated: boolean = false;
  
  constructor(private token: TokenStorageService, private userService: UserService, private _snackBar: MatSnackBar) { 
    this.form = new User()
  }

  ngOnInit(): void {
    this.userService.GetUserByToken().subscribe(
      data => {  
        this.currentUser = data;      
        this.form.FirstName = data.firstName;
        this.form.LastName = data.lastName;
        this.form.DateOfBirth = new Date(data.dateOfBirth);
        this.form.Sex = data.sex;
        this.form.PhoneNumber = data.phoneNumber;
        this.form.Email = data.email;    
        this.token.saveUser(data);
      });
  }

  onSave(): void {
    this.userService.UpdateUser(this.form).subscribe(
      data => {
        this.isUpdated = true;
        this.token.getUser().FirstName = this.form.FirstName;
        this.token.getUser().LastName = this.form.LastName;
        this.token.getUser().DateOfBirth = this.form.DateOfBirth;
        this.token.getUser().PhoneNumber = this.form.PhoneNumber;
        this.reloadPage();
      },
      err => {
        this.openSnackBar("An Error Occurred while updating");
      });
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, "Close", {
      duration: 5000,
    });
  }

  reloadPage(): void {
    window.location.reload();
  }
}
