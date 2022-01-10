import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appointment } from '../models/appointment.model';

const AUTH_API = 'http://localhost:3000/api/Appointment/';
const headers = new HttpHeaders({ 'Content-Type': 'application/json' })

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http: HttpClient) { }

  GetAvailableSessions(appointmentDate: Date): Observable<any> {
    var params = new HttpParams().append('appointmentDate', appointmentDate.toISOString());
    return this.http.get(AUTH_API + 'GetAvailableSessions', {headers,params});
  }

  CreateAppointment(appointment: Appointment): Observable<any> {
    return this.http.post(AUTH_API + 'CreateAppointment', {
      AppointmentId : appointment.AppointmentId,
      AppointmentType : appointment.AppointmentType,
      AppointmentTypeId : appointment.AppointmentTypeId,
      AppointmentDate : appointment.AppointmentDate,
      SessionId : appointment.SessionId
    }, {headers});
  }

  UpdateAppointmentComments(appointment: Appointment): Observable<any> {
    return this.http.post(AUTH_API + 'UpdateAppointmentComments', {
      AppointmentId : appointment.AppointmentId,
      Comments : appointment.Comments
    }, {headers});
  }

  GetAppointmentTypes(): Observable<any> {
    return this.http.get(AUTH_API + 'GetAppointmentTypes', {headers});
  }

  GetAllAppointments(): Observable<any> {
    return this.http.get(AUTH_API + 'GetAllAppointments', {headers});
  }
}
