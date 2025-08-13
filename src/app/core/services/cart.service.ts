import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private items: any[] = [];

  constructor() {}

  addToCart(product: any) {
    this.items.push(product);
    console.log('Panier:', this.items);
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }

  removeItem(index: number) {
  this.items.splice(index, 1);
}

}
