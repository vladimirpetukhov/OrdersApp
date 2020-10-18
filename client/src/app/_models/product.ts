import { Category } from './Category';
export interface Product {
  id: number;
  name: string;
  price: number;
  description: string;
  category: Category;
}
