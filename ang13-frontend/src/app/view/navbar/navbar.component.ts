import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  private UserType: string[] = [];
  isLoggedIn = false;
  isAdmin = false;
  isStaff = false;
  showAny = false;
  username?: string;

  constructor(private tokenService: TokenStorageService, private router: Router) { }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenService.getUser();
      this.showAny = this.validateUserAttributes(user);
      this.UserType = user.userType;
      this.isAdmin = this.UserType.includes('Admin') && this.showAny;
      this.isStaff = (this.UserType.includes('Admin') || this.UserType.includes('Staff')) && this.showAny;
      this.username = user.email;
    }
  }

  validateUserAttributes(user: any): boolean{
    if (!user.firstName || !user.lastName || !user.phoneNumber || !user.dateOfBirth){
      return false;
    }
    return true;
  }

  logout(): void {
    this.tokenService.signOut();
    this.router.navigate(['/landing-page']).then(
      () => {
        window.location.reload();
      }
    )
  }

}
