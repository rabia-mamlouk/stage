import { Component, OnInit } from '@angular/core';
import { CartService } from '../../core/services/cart.service'; 

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  items: any[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.items = this.cartService.getItems();
    console.log('Contenu du panier:', this.items); 
  }

  clearCart() {
  this.cartService.clearCart();
  this.items = [];
}

getTotal(): number {
  return this.items.reduce((total, item) => {
    const numericPrice = parseFloat(item.price.replace(' TND', ''));
    return total + numericPrice;
  }, 0);
}

removeItem(index: number): void {
  this.cartService.removeItem(index);
  this.items = this.cartService.getItems();
}



}
