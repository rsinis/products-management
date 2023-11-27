import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { Product } from '../shared/models/product';
import { CatalogService } from '../shared/services/catalog.service';
import { FabComponent } from "../shared/components/fab/fab.component";

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

  route = inject(ActivatedRoute);
  catalogService = inject(CatalogService);

  constructor() {
    const productId = Number(this.route.snapshot.paramMap.get('id'));
    this._loadProductById(productId);
  }

  private _loadProductById(id: number) {
    this.catalogService.getProductById(id).subscribe(x => {
      this.product = x;
    });
  }

}
