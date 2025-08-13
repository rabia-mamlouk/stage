import { Component } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { ApiService } from '../../core/services/api.service';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent {
  products: any
  constructor(private cartService: CartService, private ApiService: ApiService) { }

  ngOnInit() {
    this.getApis()
  }
  getApis() {
    this.ApiService.getApis().subscribe((res: any) => {
      console.log(res)
      this.products = res.resultat.items;
    })
  }
  addToCart(product: any) {
    this.cartService.addToCart(product);
    console.log('Produit ajouté au panier:', product);
  }

  deleteAPI(id: any) {
    if (confirm('Are you sure you want to delete this product ? ')) {
      this.ApiService.deleteAPI(id).subscribe({
        next: () => {
          this.products = this.products.filter((product: any) => product.id !== id);
          console.log('product deleted');
        },
        error: (err) => {
          console.error('Deletion error :', err);
        }
      });
    }
  }



}
