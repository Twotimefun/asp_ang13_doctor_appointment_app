import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../_services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class StaffGuard implements CanActivate {
  private UserType: string[] = [];
  isLoggedIn = false;
  isStaff = false;
  showAny = false;

  constructor(private tokenService: TokenStorageService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
    this.isLoggedIn = !!this.tokenService.getToken();
    
    if (this.isLoggedIn) {
      const user = this.tokenService.getUser();
      this.UserType = user.userType;
      this.isStaff = (this.UserType.includes('Admin') || this.UserType.includes('Staff'));
    }

    if (this.isStaff == true) {
      return true;
    }
    
    window.alert('You don\'t have permission to view this page');
    return false;

  }
  
}
