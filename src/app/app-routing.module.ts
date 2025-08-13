import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { IndustriesComponent } from './modules/industries/industries.component';
import { QualityComponent } from './modules/quality/quality.component';
import { AboutComponent } from './modules/about/about.component';
import { InsightsComponent } from './modules/insights/insights.component';
import { ContactsComponent } from './modules/contacts/contacts.component';
import { ArduinoComponent } from './modules/arduino/arduino.component';
import { RaspberryComponent } from './modules/raspberry/raspberry.component';
import { MicrobitComponent } from './modules/microbit/microbit.component';
import { EspressifComponent } from './modules/espressif/espressif.component';
import { CartComponent } from './modules/cart/cart.component';
import { ShopComponent } from './modules/shop/shop.component';
import { AddComponent } from './modules/add/add.component';
import { UpdateComponent } from './modules/update/update.component';
import { Stm32Component } from './modules/stm32/stm32.component';




const routes: Routes = [ { path: 'shop' , component: ShopComponent},
  { path: 'industries' , component: IndustriesComponent},
  { path: 'insights' , component: InsightsComponent},
  { path: 'home' , component:HomeComponent},
  { path: 'contacts' , component:ContactsComponent},
  { path: 'quality' , component:QualityComponent},
  { path: 'contacts' , component:ContactsComponent},
  { path: 'about' , component:AboutComponent},
  { path: 'arduino' , component:ArduinoComponent},
  { path: 'raspberry' , component:RaspberryComponent},
  { path: 'microbit' , component:MicrobitComponent},
  { path: 'stm32' , component:Stm32Component},
  { path: 'espressif' , component:EspressifComponent},
  { path: 'shop', component: ShopComponent },
  { path: 'cart', component: CartComponent },
  { path: 'add', component: AddComponent },
  { path: 'update/:id', component: UpdateComponent },
  { path: '', redirectTo: '/shop', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
