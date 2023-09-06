import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { CreateProduct } from 'src/app/contracts/create_product';
import { ListProduct } from 'src/app/contracts/list_products';
import { AlertifyService, MessagePosition, MessageType } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends BaseComponent  {

/**
 *
 */
constructor(spinner:NgxSpinnerService,private productService:ProductService,private alertifyService:AlertifyService) {
  super(spinner); 
}
  

@Output() createdProduct : EventEmitter<CreateProduct> = new EventEmitter();



create(name:HTMLInputElement,price:HTMLInputElement,stock:HTMLInputElement){
let product : CreateProduct = new CreateProduct();
this.showSpinner(SpinnerType.BallSpinFadeRotating);
product.name = name.value;
product.price = parseFloat(price.value);
product.stock = parseInt(stock.value);

this.productService.create(product,()=>{
  this.hideSpinner(SpinnerType.BallSpinFadeRotating);
  this.alertifyService.message("Ürün Eklendi",MessageType.Success,MessagePosition.BottomLeft,10);

  this.createdProduct.emit(product);

}, (errorMessage:string) => {

  this.hideSpinner(SpinnerType.BallSpinFadeRotating)
  this.alertifyService.message(errorMessage,MessageType.Error,MessagePosition.BottomLeft,10)


});


}



}
