import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Customers } from 'src/app/models/Customers';


@Component({
  selector: 'app-delete-customers',
  templateUrl: './component.delete.customers.html',

})
export class ComponentDeleteCustomers implements OnInit {

  constructor(
    private dialogoReferencia: MatDialogRef<ComponentDeleteCustomers>,
    @Inject(MAT_DIALOG_DATA) public dataCustomers: Customers,

  ) { }

  ngOnInit(): void {

  }

  deleteCustomer() {
    if (this.dataCustomers) {
      this.dialogoReferencia.close("eliminar");
    }
  }



}
