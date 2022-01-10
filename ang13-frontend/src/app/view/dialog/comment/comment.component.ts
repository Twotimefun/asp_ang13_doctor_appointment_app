import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Appointment } from 'src/app/models/appointment.model';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent {

  local_data:any;

  constructor(
    public dialogRef: MatDialogRef<CommentComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Appointment) {
    this.local_data = {...data};
  }

  doAction(){
    this.dialogRef.close(this.local_data);
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}
