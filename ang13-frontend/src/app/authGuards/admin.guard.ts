import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../_services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  private UserType: string[] = [];
  isLoggedIn = false;
  isAdmin = false;
  showAny = false;

  constructor(private tokenService: TokenStorageService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
    this.isLoggedIn = !!this.tokenService.getToken();
    
    if (this.isLoggedIn) {
      const user = this.tokenService.getUser();
      this.UserType = user.userType;
      this.isAdmin = (this.UserType.includes('Admin'));
    }

    if (this.isAdmin == true) {
      return true;
    }

    window.alert('You don\'t have permission to view this page');
    this.router.navigate(['/login']);
    return false;

  }
  
}
