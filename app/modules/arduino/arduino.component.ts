import { Component } from '@angular/core';
import { CartService } from '../../core/services/cart.service';

@Component({
  selector: 'app-arduino',
  templateUrl: './arduino.component.html',
  styleUrls: ['./arduino.component.css']
})
export class ArduinoComponent {
  arduino_products = [
  {
    name: 'Arduino UNO R3 ORIGINAL',
    price: '100.000 TND',
    image: 'assets/arduno.jpg',
    brand: 'Arduino',
    description: 'Micro PC 2GB version'
  },
  {
    name: 'ARDUINO MEGA 2560 R3 OFFICIEL',
    price: '145.000 TND',
    image: 'assets/arduino.jpg',
    brand: 'Arduino',
    description: 'Arduino UNO R3 VERSION ORIGINAL'
  },
  {
    name: 'Arduino PRO MICRO ATMEGA 32U4',
    price: '40.000 TND',
    image: 'assets/arduino_atmega.jpg',
    brand: 'Arduino',
    description: 'Arduino PRO MICRO ATMEGA 32U4'
  },

  { 
     name: 'Arduino MEGA 2560 CH340 R3 + cable USB',
    price: '60.000 TND',
    image: 'assets/ch340.jpg',
    brand: 'Arduino',
    description: 'Arduino MEGA 2560 CH340 R3 + cable USB'
  },

  { 
     name: 'Arduino PRO MINI ATMEGA328P 5V 16MHZ',
    price: '20.000 TND',
    image: 'assets/arduino-pro-mini.jpg',
    brand: 'Arduino',
    description: 'Arduino PRO MINI ATMEGA328P 5V 16MHZ'
  },
 
 { 
     name: 'Arduino Nano REV3 CH340',
    price: '22.000 TND',
    image: 'assets/arduino-nano.jpg',
    brand: 'Arduino',
    description: 'Arduino Nano REV3 CH340 Sans Cable USB'
  },
 { 
     name: 'Arduino MEGA 2560 R3 + cable USB',
    price: '65.000 TND',
    image: 'assets/arduino-mega-2560-r3.jpg',
    brand: 'Arduino',
    description: 'carte Arduino Mega 2560 ATMega16U2 R3'
  }
  

];

  constructor(private cartService: CartService) {}

  addToCart(product: any) {
    this.cartService.addToCart(product);
    console.log('Produit ajouté au panier:', product);
  }



}
