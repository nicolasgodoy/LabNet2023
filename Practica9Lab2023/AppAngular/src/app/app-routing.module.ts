import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { listCustomersComponent} from './components/Customer.ListView/listCustomers.component';



const routes: Routes = [

  {path: '', component: listCustomersComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
