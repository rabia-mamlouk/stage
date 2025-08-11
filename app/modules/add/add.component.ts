import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService} from '../../core/services/api.service';
import { Router } from '@angular/router';
import { Api } from '../../core/models/api.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent implements OnInit {
  productForm!: FormGroup;
  submitted = false;
  imagePreview: string | ArrayBuffer | null = null;

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      companyName: [''],
      description: [''],
      price: [''],
      quantityinstock: [''],
      image: [''],
    });
  }

  onImageSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result;
        this.productForm.patchValue({
          image: reader.result,
        });
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.productForm.valid) {
      const newProduct: Api = this.productForm.value;
      this.apiService.addApi(newProduct).subscribe({
        next: () => {
          console.log('Product successfully added.');
          this.router.navigate(['/shop']);
        },
        error: (err) => {
          console.error('Error while adding product:', err);
        },
      });
    } else {
      console.warn('Invalid form');
    }
  }
}
