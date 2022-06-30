import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import { BaseFormErrorService } from 'src/app/shared/utils/base-form-error.service';
import { Shipper } from '../../models/shipper.interface';
import { ShipperService } from '../../services/shipper/shipper.service';

@Component({
  selector: 'app-shipper',
  templateUrl: './shipper.component.html',
  styleUrls: ['./shipper.component.css']
})
export class ShipperComponent implements OnInit, OnDestroy {

  shipper: Shipper[] = [];
  private subscription: Subscription = new Subscription();
  shipperForm = this.formBuilder.group({
    companyName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(40)]],
    phone: ['', [Validators.maxLength(24)]]
  });
  edit: boolean = false;
  idShipper: number | any = null;

  constructor(
    private shipperService: ShipperService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private baseFormError: BaseFormErrorService
  ) { }
  
  ngOnDestroy(): void {
    this.modalService.dismissAll();
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {    
    this.subscription.add(this.shipperService.getAll().subscribe(res => this.shipper = res));
    this.baseFormError.baseForm = this.shipperForm;
  }

  open(content: any, item?: Shipper) {
    if (item) {
      this.shipperForm.setValue({
        companyName: item.companyName,
        phone: item.phone
      });
      this.edit = true;
      this.idShipper = item.shipperID;
    } else {
      this.edit = false;
      this.idShipper = null;
      this.shipperForm.reset();
    }
    this.modalService.open(content, { ariaLabelledBy: 'modal-shipper' })
  }

  saveChange() {
    if (this.shipperForm.invalid) {
      return;
    }

    if (this.idShipper != null) {
      this.subscription.add(
        this.shipperService.edit(this.idShipper, this.shipperForm.value).subscribe(
          (res) => {
            this.modalService.dismissAll();
            alert(res.message);
            this.ngOnInit();
          }
        )
      );
    } else {
      this.subscription.add(
        this.shipperService.add(this.shipperForm.value).subscribe(
          (res) => {
            this.modalService.dismissAll();
            alert(res.message);
            this.ngOnInit();
          }
        )
      );
    }

  }

  eliminar(id: number) {
    if (confirm("¿Desea eliminar el expedidor?")) {
      this.subscription.add(
        this.shipperService.delete(id).subscribe(
          (res) => {
            alert(res.message);
            this.ngOnInit();
          }
        )
      );
    }
  }

  checkField(field: string): boolean {
    return this.baseFormError.isValidField(field);
  }

  fieldMessage(field: string): string {
    return this.baseFormError.getErrorMessage(field);
  }

}
