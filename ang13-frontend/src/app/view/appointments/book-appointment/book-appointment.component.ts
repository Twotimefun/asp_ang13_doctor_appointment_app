import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/models/appointment.model';
import { Session } from 'src/app/models/session.model';
import { User } from 'src/app/models/user.model';
import { AppointmentService } from 'src/app/_services/appointment.service';
import { UserTokenConverter } from 'src/app/_helpers/user-from-token-converter';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-book-appointment',
  templateUrl: './book-appointment.component.html',
  styleUrls: ['./book-appointment.component.scss'],
  providers: [UserTokenConverter]
})
export class BookAppointmentComponent implements OnInit {
  appointmentForm: Appointment;
  user: User;
  sessions = [] as any;
  isSubmitted = false;
  appointmentTypes = [] as any;
  isBackendError = false;
  errorMessage = "";

  constructor(private token: TokenStorageService, private userTokenConverter: UserTokenConverter, private appointmentService: AppointmentService) { 
    this.user = new User();    
    this.appointmentForm = new Appointment(0,this.user,new Session(),'',0,0,'',new Date());
  }
  
  ngOnInit(): void {
    this.user = this.userTokenConverter.AssignUserFromToken(this.token);
    this.appointmentForm.User = this.user;
    this.appointmentService.GetAppointmentTypes().subscribe(
      data => {
        for (var i = 0; i < data.length; i++){
          this.appointmentTypes.push({id: data[i].appointmentTypeId, type: data[i].type});
        }
      });  
      this.GetSessions(this.appointmentForm.AppointmentDate);
  }

  ValidateDate(date : Date): boolean{
    if (date == new Date()){
      return false;
    }
    return true;
  }

  ValidateSubmission(): boolean{
    return !(this.appointmentForm.AppointmentTypeId == 0 || this.appointmentForm.SessionId == 0 || this.appointmentForm.AppointmentDate == new Date());
  }

  GetSessions(value : Date) {
    if (!this.ValidateDate(value)){
      return;
    }
    this.appointmentService.GetAvailableSessions(value).subscribe(
      data => {
        this.sessions = [];
        for (var i = 0; i < data.length; i++) {
          var startTime = data[i].startTime;
          var endTime = data[i].endTime;
          this.sessions.push({ id: data[i].sessionId, description: startTime + " - " + endTime})
        }
      });    
  }

  OnSubmit(): void{
    if (this.ValidateSubmission()){   
      if (window.confirm("Are you sure you want to book an appointment?")) { 
        this.appointmentService.CreateAppointment(this.appointmentForm).subscribe(
          data => {
            this.isSubmitted = true;
            this.isBackendError = false;
            this.errorMessage = "";
          },
          err => {
            this.errorMessage = err.error.message;
            this.isBackendError = true;
            this.isSubmitted = false;
          }
        )
      }
    }
  }
}
