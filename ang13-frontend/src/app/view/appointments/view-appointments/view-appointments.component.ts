import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { Appointment } from 'src/app/models/appointment.model';
import { AppointmentService } from 'src/app/_services/appointment.service';
import { CommentComponent } from '../../dialog/comment/comment.component';

@Component({
  selector: 'app-view-appointments',
  templateUrl: './view-appointments.component.html',
  styleUrls: ['./view-appointments.component.scss']
})
export class ViewAppointmentsComponent implements OnInit {
  appointments: Appointment[] = [];
  message = '';

  constructor(private appointmentService : AppointmentService, public dialog: MatDialog) { } 

  ngOnInit(): void {
    
    this.appointmentService.GetAllAppointments().subscribe(
      data=>{       
        for (var i = 0; i < data.length; i++){          
          this.appointments.push({
            AppointmentId : data[i].appointmentId,
            AppointmentType : data[i].appointmentType,
            AppointmentTypeId : data[i].appointmentTypeId,
            User : { FirstName : data[i].user.firstName, LastName : data[i].user.lastName, 
                      PhoneNumber : data[i].user.phoneNumber, Email : data[i].user.email, Sex : data[i].user.sex,
                      DateOfBirth : data[i].user.dateOfBirth
                    },
            Session : {SessionId : data[i].sessionId, StartTime : data[i].session.startTime, EndTime : data[i].session.endTime},
            SessionId : data[i].sessionId,
            Comments : data[i].comments,
            AppointmentDate : new Date(data[i].appointmentDate)
          });     
        }   
      });
  }    

  UpdateComment(result: any) {
    this.appointments = this.appointments.filter((value,key)=>{
      if(value.AppointmentId == result[0]){     
        value.Comments = result.Comments;
        this.appointmentService.UpdateAppointmentComments(value).subscribe();
      }
      return true;
    });
  }

  OpenDialog(obj : any) {
    const dialogRef = this.dialog.open(CommentComponent, {
      width: '50%',
      data:obj
    });
    
    dialogRef.afterClosed().subscribe(result => {
      this.UpdateComment(result);
    });
  }
}
