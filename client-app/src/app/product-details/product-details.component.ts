import { Component, inject } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { Product } from '../shared/models/product';
import { CatalogService } from '../shared/services/catalog.service';
import { FabComponent } from "../shared/components/fab/fab.component";
import { FormBuilder } from '@angular/forms';

@Component({
    selector: 'app-product-details',
    standalone: true,
    templateUrl: './product-details.component.html',
    styleUrl: './product-details.component.css',
    imports: [CommonModule, FabComponent]
})
export class ProductDetailsComponent {
  pageTitle = 'Trash';
  errorMessage = '';
  product?: Product;

  location = inject(Location);
  route = inject(ActivatedRoute);
  catalogService = inject(CatalogService);

  constructor() {
    const productId = Number(this.route.snapshot.paramMap.get('id'));
    this._loadProductById(productId);
  }

  onBack() {
    this.location.back();
  }

  private _loadProductById(id: number) {
    this.catalogService.getProductById(id).subscribe(x => {
      this.product = x;
    });
  }

}
