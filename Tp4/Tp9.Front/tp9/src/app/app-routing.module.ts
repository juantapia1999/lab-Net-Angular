import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperComponent } from './core/components/shipper/shipper.component';
import { HomeComponent } from './shared/components/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'shipper', component: ShipperComponent },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
