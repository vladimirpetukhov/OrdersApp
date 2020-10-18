import { ProductComponent } from './product/product.component';
import { OrdersComponent } from './orders/orders.component';
import { RegisterComponent } from './register/register.component';
import { PhotoManagementComponent } from './admin/photo-management/photo-management.component';
import { LoginComponent } from './login/login.component';
import { CategoryComponent } from './admin/category/category.component';

import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ListsResolver } from './_resolvers/lists.resolver';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { ProductListResolver } from './_resolvers/product-resolvers/product-list.resolver';
import { OrderListResolver } from './_resolvers/order-resolvers/order-list.resolver';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'register', component: RegisterComponent
  },
  {
    path: 'products', component: ProductComponent,
    resolve: { products: ProductListResolver }
  },
  {
    path: 'orders', component: OrdersComponent, resolve: { orders: OrderListResolver }
  },
  { path: 'lists', component: ListsComponent, resolve: { users: ListsResolver } },
  // {
  //   path: '',
  //   children: [
  //     {
  //       path: 'products', component: ProductComponent,
  //       resolve: { products: ProductListResolver }
  //     },
  //     {
  //       path: 'members/:id', component: MemberDetailComponent,
  //       resolve: { user: MemberDetailResolver }
  //     },

  //     {
  //       path: 'member/edit', component: MemberEditComponent,
  //       resolve: { user: MemberEditResolver }, canDeactivate: [PreventUnsavedChanges]
  //     },
  //     { path: 'messages', component: MessagesComponent, resolve: { messages: MessagesResolver } },
  //     { path: 'lists', component: ListsComponent, resolve: { users: ListsResolver } },
  //     { path: 'admin/photo-managemen', component: PhotoManagementComponent, data: { roles: ['Admin', 'Moderator'] } },
  //     {
  //       path: 'admin',
  //       loadChildren: () => import('./admin/admin.module')
  //         .then(a => a.AdminModule), data: { roles: ['Admin', 'Moderator'] }
  //     },
  //     { path: 'admin/category', component: CategoryComponent, data: { categories: ['Admin', 'Moderator'] } }
  //   ]
  // },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
