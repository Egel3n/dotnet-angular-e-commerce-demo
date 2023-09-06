import { Component } from '@angular/core';
import { CustomToastrService, ToastrMessageType } from './services/ui/custom-toastr.service';
declare var $: any




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ETicaretClient';
  /**
   *
   */
  constructor(private toastr:CustomToastrService) {
    this.toastr.message("Ege","Gelen",ToastrMessageType.Info)
  }

}


