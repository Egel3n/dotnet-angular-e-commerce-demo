import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator ,MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { CreateProduct } from 'src/app/contracts/create_product';
import { ListProduct } from 'src/app/contracts/list_products';
import { PageAdminProduct } from 'src/app/contracts/page_admin_products';
import { AlertifyService, MessagePosition, MessageType } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;

    displayedColumns: string[] = ['name', 'stock', 'price', 'createdDate','updatedDate','delete'];
    dataSource : MatTableDataSource<ListProduct>=null; 
  
  constructor(spinner:NgxSpinnerService,private productService:ProductService,private alertifyService:AlertifyService){
    super(spinner)
  }


  async getProducts(){
    this.showSpinner(SpinnerType.Pacman)
      const Results:PageAdminProduct = await this.productService.read(this.paginator? this.paginator.pageIndex:0 ,this.paginator? this.paginator.pageSize : 5,()=>{this.hideSpinner(SpinnerType.Pacman)},(errorMessage)=>{this.alertifyService.message(errorMessage,MessageType.Error,MessagePosition.BottomRight,10)})
      


      console.log(Results)
      this.dataSource = new MatTableDataSource<ListProduct>(Results.products)
     
      this.paginator.length = Results.totalCount;

      
      
  }


 async ngOnInit(){
      await this.getProducts();

    }


    

}
