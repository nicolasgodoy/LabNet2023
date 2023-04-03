import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customers } from '../models/Customers';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  url: string = "https://localhost:44339/api/Customer";

  getCustomers() {
    return this.http.get<Customers[]>(this.url);

  }

  AddCustomer(customer: Customers): Observable<Customers> {
    return this.http.post<Customers>(this.url, customer);
  }

  UpdateCustomer(id: string, customer: Customers): Observable<Customers> {
    return this.http.put<Customers>(this.url + `/${id}`, customer);
  }

  DeleteCustomer(id: string) {
    return this.http.delete<Customers>(this.url + `/${id}`);
  }



}