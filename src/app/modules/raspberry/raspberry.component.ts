import { Component } from '@angular/core';
import { CartService } from '../../core/services/cart.service';


@Component({
  selector: 'app-raspberry',
  templateUrl: './raspberry.component.html',
  styleUrls: ['./raspberry.component.css']
})
export class RaspberryComponent {
    raspberry_products = [
  {
    name: 'Raspberry PI PICO-W RP2040',
    price: '40.000 TND',
    image: 'assets/raspberry-pico.jpg',
    brand: 'Raspberry PI',
    description: 'Raspberry PI PICO-W RP2040 Wifi+Bluetooth'
  },
  {
    name: 'Raspberry Pi PICO 2 W',
    price: '35.000 TND',
    image: 'assets/raspberry-pico2.jpg',
    brand: 'Raspberry PI',
    description: 'La gamme Pico avec la nouvelle série Pico 2 !'
  },
  {
    name: 'Carte Raspberry PI5 2GB',
    price: '234.000 TND',
    image: 'assets/CarteRaspberrypi52gb.jpg',
    brand: 'Raspberry PI',
    description: 'Micro PC 2GB version'
  },

  { 
     name: 'Raspberry Pi Zero WH GPIO soudé',
    price: '90.000 TND',
    image: 'assets/raspberry-zero.jpg',
    brand: 'Raspberry PI',
    description: 'Raspberry Pi Zero WH'
  },

  { 
     name: 'Raspberry Pi 3 Modèle B+ 1 GB',
    price: '190.000 TND',
    image: 'assets/raspberry-3.jpg',
    brand: 'Raspberry PI',
    description: 'Raspberry Pi 3 Modèle B+ 1 GB'
  }
  

];

  constructor(private cartService: CartService) {}

  addToCart(product: any) {
    this.cartService.addToCart(product);
    console.log('Produit ajouté au panier:', product);
  }



}

