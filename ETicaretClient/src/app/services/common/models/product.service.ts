import { Injectable } from '@angular/core';
import { HttpClientService, RequestParameters } from '../http-client.service';
import { CreateProduct} from 'src/app/contracts/create_product';
import { HtmlParser } from '@angular/compiler';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { ListProduct } from 'src/app/contracts/list_products';
import { PageAdminProduct } from 'src/app/contracts/page_admin_products';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService:HttpClientService) { }


  create(product:CreateProduct,succesMethod?:any,errorMethod?:any){
    this.httpClientService.post({
      controller:"product"
    },product).subscribe(result=>{
      succesMethod();
    },(errorResponse:HttpErrorResponse)=>{

      const _error : Array<{key:string, value:Array<string>}>= errorResponse.error;
      let message = ""
      console.log(errorResponse)
      _error.forEach((v,index)=>{
        v.value.forEach((_v,_index)=>
        {
          message+= `${_v}<br>`
        })
      })

      errorMethod(message)


    });
  }

 async read(page:number=0,size:number=5,succesMethod?:any, errorMethod?:any) : Promise<PageAdminProduct>
 {
   var promiseData : Promise<PageAdminProduct> =  this.httpClientService.get<PageAdminProduct>(
    {controller:"product",queryString:`page=${page}&size=${size}`}).toPromise();
   promiseData.then(d => succesMethod()).catch((errorMessage:HttpErrorResponse)=> errorMethod(errorMessage.message))
   return await promiseData;
  }


  async remove(id:string,succesMethod?:any,errorMethod?:any)
  {
  const deleteObs =  this.httpClientService.delete({controller:"product"},id)
  var a = await firstValueFrom(deleteObs).then(succesMethod()).catch((errorMessage:HttpErrorResponse)=>errorMethod(errorMessage.error))
  }

}
