import { Product } from './Product';
export interface Category {
  id:number;
  name:string;
  createdOn:string;
  updatedOn:string;
  isActive:boolean;
  products:Array<Product>;
}
