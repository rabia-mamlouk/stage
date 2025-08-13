import { Component } from '@angular/core';
import { CartService } from '../../core/services/cart.service';

@Component({
  selector: 'app-microbit',
  templateUrl: './microbit.component.html',
  styleUrls: ['./microbit.component.css']
})
export class MicrobitComponent {
  microbit_products = [
  {
    name: 'Carte Micro:bit BBC ',
    price: '75.000 TND',
    image: 'assets/carte-microbit-bbc.jpg',
    brand: 'Micro:bit',
    description: 'Carte Micro:bit BBC (Version Originale)'
  },
  {
    name: "Carte d'Extension GPIO Pour Micro:bit",
    price: '25.000 TND',
    image: 'assets/carte-gpio.jpg',
    brand: 'Micro:bit',
    description: "Carte d'Extension GPIO Pour Micro:bit"
  },

  { 
     name: 'Carte Micro: bit BBC V2',
    price: '110.000 TND',
    image: 'assets/microbit.jpg',
    brand: 'Micro:bit',
    description: 'Carte de Développement Micro:bit BBC'
  }
  
];

  constructor(private cartService: CartService) {}

  addToCart(product: any) {
    this.cartService.addToCart(product);
    console.log('Produit ajouté au panier:', product);
  }

}
