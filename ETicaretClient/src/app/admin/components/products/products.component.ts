import { Component,OnInit, ViewChild } from '@angular/core';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import {NgxSpinnerService} from 'ngx-spinner'
import { HttpClientService, RequestParameters } from 'src/app/services/common/http-client.service';
import { AlertifyService, MessagePosition, MessageType } from 'src/app/services/admin/alertify.service';
import { CreateProduct } from 'src/app/contracts/create_product';
import { ListComponent } from './list/list.component';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends BaseComponent implements OnInit {
/**
 *
 */
constructor(spinner:NgxSpinnerService, private httpClientService:HttpClientService,private messageger:AlertifyService) {
  super(spinner);
  
}

@ViewChild(ListComponent) listComponent : ListComponent;
createdProduct(product:CreateProduct){
this.listComponent.getProducts();
}

ngOnInit(): void {

  
this.showSpinner(SpinnerType.BallSpinFadeRotating);
this.hideSpinner(SpinnerType.BallSpinFadeRotating);
  



  // this.httpClientService.get({
  //   controller:"product"
  // }).subscribe()

  // this.httpClientService.post({
  //   controller:"product",
  // },{
  //   stock:1,
  //   name:"kalem",
  //   price:7
  // }).subscribe()

  // this.httpClientService.put({controller:"product"},{id:"d628f230-dfbb-4017-84e5-b5e070d141d2",name:"Ali Cabbar",price:3,stock:2}).subscribe()
  // this.httpClientService.delete({controller:"product"},"d628f230-dfbb-4017-84e5-b5e070d141d2").subscribe()


}

}
