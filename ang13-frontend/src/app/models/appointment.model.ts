import { User } from '../models/user.model';
import { Session } from '../models/session.model';

export class Appointment{
    AppointmentId: number;
    User: User;
    AppointmentType: String;
    AppointmentTypeId: number;
    Session: Session;  
    SessionId: number;  
    Comments: String;
    AppointmentDate: Date;

    constructor(appointmentId: number, user: User, session: Session, appointmentType : string, appointmentTypeId: number, sessionId: number, comments: string, appointmentDate: Date){
        this.AppointmentId = appointmentId;
        this.User = user;
        this.Session = session;
        this.AppointmentType = appointmentType;
        this.AppointmentTypeId = appointmentTypeId;
        this.SessionId = sessionId;
        this.Comments = comments;
        this.AppointmentDate = appointmentDate;
    }
}
