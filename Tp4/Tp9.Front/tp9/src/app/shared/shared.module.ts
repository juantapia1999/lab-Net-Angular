import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AppRoutingModule } from '../app-routing.module';
import { HomeComponent } from './components/home/home.component';



@NgModule({
  declarations: [
    NavbarComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule    
  ],
  exports:[
    NavbarComponent
  ]
})
export class SharedModule { }
