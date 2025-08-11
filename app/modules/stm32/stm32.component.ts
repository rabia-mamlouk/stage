import { Component } from '@angular/core';
import { CartService } from '../../core/services/cart.service';

@Component({
  selector: 'app-stm32',
  templateUrl: './stm32.component.html',
  styleUrls: ['./stm32.component.css']
})
export class Stm32Component {
  stm32_products = [
  {
    name: 'Carte de Développement STM32F407G DISC1',
    price: '120.000 TND',
    image: 'assets/stm32-1.jpg',
    brand: 'STM32',
    description: 'STM32F407G DISC1'
  },
  {
    name: 'Carte de Développement STM32F429L DISC1',
    price: '190.000 TND',
    image: 'assets/stm32-2.jpg',
    brand: 'STM32',
    description: 'STM32F429L DISC1'
  },
  {
    name: 'Carte de Développement STM32 NUCLEO-F401RE',
    price: '95.000 TND',
    image: 'assets/stm32-3.jpg',
    brand: 'STM32',
    description: 'STM32 NUCLEO-F401RE'
  },

  { 
     name: 'Carte de Développement STM32 NUCLEO-F411RE',
    price: '95.000 TND',
    image: 'assets/stm32-4.jpg',
    brand: 'STM32',
    description: 'STM32 NUCLEO-F411RE'
  },

  {
    name: 'STM32F429I DISCOVERY Carte de Développement',
    price: '270.000 TND',
    image: 'assets/stm32.jpg',
    brand: 'STM32',
    description: 'Carte de Développement STM32'
  },
 
 { 
     name: 'STM32L475VGT6 Development Kit',
    price: '380.000 TND',
    image: 'assets/stm32-5.jpg',
    brand: 'STM32',
    description: 'B-L475E-IOT01A2 - STM32L475VGT6 Development Kit, IoT Node, Low Power, Wi-Fi, BLE, NFC, 868 MHz'
  },
 { 
     name: 'STM NUCLEO-H7A3ZI-Q PLATINE NUCLEO-144',
    price: '170.000 TND',
    image: 'assets/stm32-6.jpg',
    brand: 'STM32',
    description: 'Carte de développement STM NUCLEO-H7A3ZI-Q PLATINE NUCLEO-144, CORTEX-M4/CORTEX-M7'
  }
  

];

  constructor(private cartService: CartService) {}

  addToCart(product: any) {
    this.cartService.addToCart(product);
    console.log('Produit ajouté au panier:', product);
  }

}
