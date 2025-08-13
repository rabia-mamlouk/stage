import { Component } from '@angular/core';
import { CartService } from '../../core/services/cart.service';


@Component({
  selector: 'app-espressif',
  templateUrl: './espressif.component.html',
  styleUrls: ['./espressif.component.css']
})
export class EspressifComponent {
  esp_products = [
  {
    name: 'ESP32-CAM Carte de développement ESP32 CP2102 + Caméra OV2640 Avec USB',
    price: '45.000 TND',
    image: 'assets/esp-1.jpg',
    brand: 'ESP32',
    description: 'ESP32-CAM, ESP32 CP2102 Carte de développement + Caméra OV2640 Avec Port Micro USB'
  },
  {
    name: 'Carte ESP32 WROOM-32 WiFi & Bluetooth CP2102',
    price: '30.000 TND',
    image: 'assets/esp-2.jpg',
    brand: 'ESP32',
    description: 'Carte De Développement ESP32 WROOM-32 WiFi & Bluetooth Dual Core CP2102 30 pines'
  },
  {
    name: 'Carte ESP32 WROOM-32 WiFi & Bluetooth CP2102 + Cable USB Micro USB 1M',
    price: '40.000 TND',
    image: 'assets/esp-3.jpg',
    brand: 'ESP32',
    description: 'Carte ESP32 WROOM-32 WiFi & Bluetooth CP2102 + Cable USB Micro USB 1M ( Charge & Data)'
  },

  { 
     name: 'Nouvelle Version Carte ESP32 ESP-32S CH9102X WiFi + Bluetooth',
    price: '35.000 TND',
    image: 'assets/esp-4.jpg',
    brand: 'ESP32',
    description: "Carte ESP32 ESP-32S CH9102X WiFi + Bluetooth 30 pines , Nouvelle Version Consommation D'énergie Ultra Faible  "
  }
  
];

  constructor(private cartService: CartService) {}

  addToCart(product: any) {
    this.cartService.addToCart(product);
    console.log('Produit ajouté au panier:', product);
  }

}
