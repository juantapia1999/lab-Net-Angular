import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShipperComponent } from './components/shipper/shipper.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ShipperComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule    
  ]
})
export class CoreModule { }
