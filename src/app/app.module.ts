import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { SharedModule } from './shared/shared.module';
import { RouterLink, RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
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


@NgModule({
  declarations: [AppComponent, HomeComponent, ShopComponent, IndustriesComponent, QualityComponent, AboutComponent, InsightsComponent, ContactsComponent, ArduinoComponent, RaspberryComponent, MicrobitComponent, Stm32Component, EspressifComponent,CartComponent, AddComponent, UpdateComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    ButtonModule,
    InputTextModule,
    TableModule,
    SharedModule,
    AppRoutingModule,
    RouterLink,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
