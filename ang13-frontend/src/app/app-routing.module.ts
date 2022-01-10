import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StaffGuard } from './authGuards/staff.guard';
import { UserGuard } from './authGuards/user.guard';
import { AboutComponent } from './view/about/about.component';
import { BookAppointmentComponent } from './view/appointments/book-appointment/book-appointment.component';
import { ViewAppointmentsComponent } from './view/appointments/view-appointments/view-appointments.component';
import { FaqComponent } from './view/faq/faq.component';
import { LandingPageComponent } from './view/landing-page/landing-page.component';
import { LoginComponent } from './view/login/login.component';
import { ProfileComponent } from './view/profile/profile.component';
import { RegisterComponent } from './view/register/register.component';

const routes: Routes = [
  {
    component: LandingPageComponent,
    path: 'landing-page'
  },
  {
    path: '',
    redirectTo: '/landing-page',
    pathMatch: 'full'
  },
  {
    component: RegisterComponent,
    path: 'register'
  },
  {
    component: LoginComponent,
    path: 'login'
  },
  {
    component: AboutComponent,
    path: 'about'
  },
  {
    component: FaqComponent,
    path: 'faq'
  },
  {
    component: ProfileComponent,
    path: 'profile',
    canActivate: [UserGuard]
  },
  {
    component: BookAppointmentComponent,
    path: 'book-appointment',
    canActivate: [UserGuard]
  },
  {
    component: ViewAppointmentsComponent,
    path: 'view-appointments',
    canActivate: [StaffGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
