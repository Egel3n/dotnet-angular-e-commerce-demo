import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { HttpClientService } from '../services/common/http-client.service';
import { ProductService } from '../services/common/models/product.service';
import { AlertifyService, MessagePosition, MessageType } from '../services/admin/alertify.service';
import { ListProduct } from '../contracts/list_products';
declare var $:any

@Directive({
  selector: '[appDeleteDirective]'
})
export class DeleteDirectiveDirective {

  constructor(
    private render: Renderer2,
    private productService:ProductService,
    private element:ElementRef,
    private alertify:AlertifyService
  ) { 

    const img = render.createElement("img")
    img.setAttribute("src","../../../../../assets/delete.png")
    img.setAttribute("style","cursor:pointer;")
    img.width= 25;
    img.length = 25;
    render.appendChild(element.nativeElement,img)
  }

@Input() id:string;
@Output() callback: EventEmitter<ListProduct> = new EventEmitter();

  @HostListener("click")
  onClick(){
    const td:HTMLTableCellElement = this.element.nativeElement;
    console.log(this.id)
    td.hidden = true;

    this.productService.remove(this.id,()=>{
      $(td.parentElement).fadeOut(2000,()=>{this.callback.emit()})
      
    },(errorMessage:string)=>{
      this.alertify.message(errorMessage,MessageType.Error,MessagePosition.BottomLeft,100)
    })

  }

}
