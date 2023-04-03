import { Component, OnInit, Inject, AfterViewInit, ViewChild, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Customers } from '../../models/Customers';
import { CustomerService } from '../../services/customer.service';



@Component({
  selector: 'app-edit-tarea',
  templateUrl: './editOrAdd.component.html',

})
export class editOrAddComponent implements AfterViewInit, OnInit {

  formCustomers: FormGroup;
  tituloAccionCustomers: string = "Nuevo";
  botonAccionCustomers: string = "Guardar";
  listaCustomers: Customers[] = [];
  dataSource = new MatTableDataSource<Customers>();
  displayedColumns: string[] = ['CustomID', 'CompanyName', 'ContactName', 'Acciones'];
  public isEdit = false;




  constructor(
    private dialogoReferencia: MatDialogRef<editOrAddComponent>,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private customerService: CustomerService,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public dataCustomer: Customers

  ) {
    this.formCustomers = this.fb.group({
      CustomerID: ["", [Validators.required, Validators.pattern('[a-zA-Z]{1,254}')]],
      CompanyName: ["", [Validators.required, Validators.pattern('[a-zA-Z]{1,254}')]],
      ContactName: ["", [Validators.required, Validators.pattern('[a-zA-Z]{1,254}')]]
    })

  }

  ngOnInit(): void {

    this.mostrarCustomers();

    if (this.dataCustomer) {
      this.isEdit = true;
      this.formCustomers.patchValue({

        CustomerID: this.dataCustomer.CustomerID,
        CompanyName: this.dataCustomer.CompanyName,
        ContactName: this.dataCustomer.ContactName,

      })

      this.tituloAccionCustomers = "Editar";
      this.botonAccionCustomers = "Actualizar";
    } else {

    }

  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  mostrarCustomers() {
    this.customerService.getCustomers().subscribe({
      next: (dataResponse) => {
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      }, error: (e) => { }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
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

    if (this.dataCustomer == null) {
      this.customerService.AddCustomer(modelo).subscribe({
        next: (data) => {
          this.mensajeAlerta("Customer Creado", "Listo")
          this.dialogoReferencia.close("creado");
        }, error: (e) => {
          this.mensajeAlerta("Ocurrio un error verifique que todos los inputs esten correctos", "Cerrar")
        }
      })
    } else {
      this.customerService.UpdateCustomer(this.dataCustomer.CustomerID, modelo).subscribe({
        next: (data) => {
          this.mensajeAlerta("Customer Editado", "Listo")
          this.dialogoReferencia.close("editado");
        }, error: (e) => {
          this.mensajeAlerta("No se pudo editar", "error");
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

  dialogUpdateCustomers(dataCustomer: Customers) {
    this.dialog.open(editOrAddComponent, {
      disableClose: true,
      data: dataCustomer,
    }).afterClosed().subscribe(resultado => {
      if (resultado === "editado") {
        this.mostrarCustomers();

      }
    })
  }

}
