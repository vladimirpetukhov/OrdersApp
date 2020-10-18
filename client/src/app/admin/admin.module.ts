//#region usings
import { ProductModule } from './product/product.module';
import { CategoryModule } from './category/category.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
//#endregion

//#region constants
const MODULES = [];
const COMPONENTS = [];
//#endregion

@NgModule({
  //#region declarations
  declarations: [

  ],
  //#endregion

  //#region imports
  imports: [
    CommonModule,
    AdminRoutingModule,
    CategoryModule,
    ProductModule
  ],
  //#endregion

  //#region exports
  exports: [
  ]
  //#endregion
})
export class AdminModule { }
