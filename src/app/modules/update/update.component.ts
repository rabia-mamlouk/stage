import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../core/services/api.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  productForm!: FormGroup;
  id: any;
  imagePreview: string | ArrayBuffer | null = null;

  constructor(
    private fb: FormBuilder,
    private act: ActivatedRoute,
    private productService: ApiService,
    private route: Router
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      companyName: ['', Validators.required],
      description: ['', Validators.required],
      quantityinstock: [0, [Validators.required, Validators.min(0)]],
      image: [''],
      carteElectroniqueId: ['']
    });
  }

  ngOnInit(): void {
    this.id = this.act.snapshot.paramMap.get('id');
    console.log('ID récupéré depuis l’URL :', this.id);

    if (this.id) {
      this.productService.getAPIById(this.id).subscribe((product: any) => {
        const retrivedProduct = product.resultat;
        if (retrivedProduct) {
          this.productForm.patchValue({
            name: retrivedProduct.name,
            price: retrivedProduct.price,
            companyName: retrivedProduct.companyName,
            description: retrivedProduct.description,
            quantityinstock: retrivedProduct.quantityInStock,
            image: retrivedProduct.image
          });

          this.imagePreview = retrivedProduct.image;
        }
      });
    }
  }

  onImageSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result;
        this.productForm.patchValue({
          image: reader.result
        });
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      this.productForm.get('carteElectroniqueId')?.setValue(this.id);
      const product = this.productForm.value;
      this.productService.updateAPI(product).subscribe(
        (res: any) => {
          this.route.navigate(['/shop']);
        }
      );
    }
  }
}
