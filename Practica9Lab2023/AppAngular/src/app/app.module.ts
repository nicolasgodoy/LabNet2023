import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { listCustomersComponent } from './components/Customer.ListView/listCustomers.component';
import { ComponentDeleteCustomers } from './components/Customers.delete/component.delete';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { editOrAddComponent } from './components/Customers.edit.add/editOrAdd.component';


@NgModule({
  declarations: [
    AppComponent,
    listCustomersComponent,
    editOrAddComponent,
    ComponentDeleteCustomers,
   
  ],
  imports: [
    HttpClientModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
