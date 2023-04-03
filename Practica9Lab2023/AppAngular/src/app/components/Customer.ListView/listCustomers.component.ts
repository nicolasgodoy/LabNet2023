import { Component, OnInit, Inject, AfterViewInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { CustomerService } from '../../services/customer.service';
import { Customers } from 'src/app/models/Customers';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { NgxSpinnerService } from 'ngx-spinner';
import { editOrAddComponent } from '../Customers.edit.add/editOrAdd.component';
import { ComponentDeleteCustomers } from '../Customers.delete/component.delete';


@Component({
  selector: 'addOrUpdate',
  templateUrl: './listCustomers.component.html',

})
export class listCustomersComponent implements OnInit, AfterViewInit {

  formCustomers: FormGroup;
  tituloAccionCustomers: string = "Nuevo";
  botonAccion: string = "Guardar";
  listaCustomers: Customers[] = [];
  dataSource = new MatTableDataSource<Customers>();
  displayedColumns: string[] = ['CustomerID', 'CompanyName', 'ContactName', 'Acciones'];




  constructor(
    private spinnerService: NgxSpinnerService,
    private dialogoReferencia: MatDialogRef<editOrAddComponent>,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private customerService: CustomerService,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public dataCustomers: Customers

  ) {
    this.formCustomers = this.fb.group({
      CustomerID: ["", [Validators.required, Validators.pattern('[a-zA-Z ]{1,254}')]],
      CompanyName: ["", [Validators.required, Validators.pattern('[a-zA-Z ]{1,254}')]],
      ContactName: ["", [Validators.required, Validators.pattern('[a-zA-Z ]{1,254}')]]

    })

    this.customerService.getCustomers().subscribe({
      next: (data) => {
        this.listaCustomers = data;
      }, error: (e) => { }
    })

  }

  ngOnInit(): void {

    this.mostrarCustomers();


  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  mostrarCustomers() {
    this.spinnerService.show();
    this.customerService.getCustomers().subscribe({
      next: (dataResponse) => {
        console.log(dataResponse)
        this.dataSource.data = dataResponse;
        this.spinnerService.hide();
      }, error: (e) => {
        this.spinnerService.hide();
      }

    })

  }

  mensajeAlerta(msg: string, accion: string) {
    this._snackBar.open(msg, accion, {
      horizontalPosition: "center",
      verticalPosition: "bottom",
      duration: 3000
    });
  }

  AddOrUpdateCustomers() {

    console.log(this.formCustomers.value)
    const modelo: Customers = {
      CustomerID: this.formCustomers.value.CustomerID,
      CompanyName: this.formCustomers.value.CompanyName,
      ContactName: this.formCustomers.value.ContactName,
    }

    if (this.dataCustomers == null) {
      this.customerService.AddCustomer(modelo).subscribe({
        next: (data) => {
          this.mensajeAlerta("Customer Creado", "Listo")
          this.dialogoReferencia.close("creado");
        }, error: (e) => {
          this.mensajeAlerta("Ocurrio un error verifique que todos los inputs esten correctos", "error");
        }
      })
    }
  }


  dialogAddCustomers() {
    this.dialog.open(editOrAddComponent, {
      disableClose: true,

    }).afterClosed().subscribe(resultado => {
      if (resultado === "creado") {
        this.mostrarCustomers();
      }
    })
  }

  dialogUpdateCustomers(dataCustomers: Customers) {
    this.dialog.open(editOrAddComponent, {
      disableClose: true,
      data: dataCustomers,
    }).afterClosed().subscribe(resultado => {
      if (resultado === "editado") {
        this.mostrarCustomers();
      }
    })
  }


  dialogDeleteCustomers(dataCustomers: Customers) {
    this.dialog.open(ComponentDeleteCustomers, {
      disableClose: true,
      data: dataCustomers,
    }).afterClosed().subscribe(resultado => {
      if (resultado === "eliminar") {
        this.customerService.DeleteCustomer(dataCustomers.CustomerID).subscribe({
          next: (data) => {
            this.mensajeAlerta("Customer Eliminado Correctamente!!", "Listo")
            this.mostrarCustomers();
          },
          error: (e) => { this.mensajeAlerta("Ocurrio un error al Eliminar", "cerrar") }
        })
      }
    })
  }





 
}

