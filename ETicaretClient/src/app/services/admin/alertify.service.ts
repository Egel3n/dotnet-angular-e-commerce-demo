import { Injectable } from '@angular/core';
declare var alertify: any;
@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }
  message(message: string,messageType:MessageType,messagePosition:MessagePosition,delay:number){
    alertify.set('notifier','delay', delay);
    alertify.set('notifier','position', messagePosition);
    alertify[messageType](message);
  }
}

export enum MessageType{
  Error = "error",
  Success = "success",
  Message = "message",
  Notify="notify",
  Warning="warning"
}

export enum MessagePosition{
  TopRight = "top-right",
  TopLeft = "top-left",
  TopCenter = "top-center",
  BottomRight = "bottom-right",
  BottomLeft = "bottom-left",
  BottomCenter = "bottom-center"
}
