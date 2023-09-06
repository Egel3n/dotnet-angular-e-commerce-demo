import { Component,OnInit } from '@angular/core';
import {NgxSpinnerService} from 'ngx-spinner'

export class BaseComponent  {


    constructor(private spinner:NgxSpinnerService){
      
    }


    showSpinner(spinnerType:SpinnerType){
      this.spinner.show(spinnerType)
    }

     hideSpinner(spinnerType:SpinnerType){
      setTimeout(() => {
        this.spinner.hide(spinnerType)
      }, 1000);
    }
}

export enum SpinnerType{
  BallSpinFadeRotating = "s1",  
  Pacman = "s2"
}
