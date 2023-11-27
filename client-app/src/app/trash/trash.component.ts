import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Product } from '../shared/models/product';
import { CatalogService } from '../shared/services/catalog.service';
import { ProductItemComponent } from "../shared/components/product-item/product-item.component";

@Component({
    selector: 'app-trash',
    standalone: true,
    templateUrl: './trash.component.html',
    styleUrl: './trash.component.css',
    imports: [CommonModule, ProductItemComponent]
})
export class TrashComponent {
  pageTitle = 'Trash';
  errorMessage = '';
  deletedProducts: Product[] = [];
  catalogService = inject(CatalogService);

  constructor() { 
    this._loadDeletedProducts()
  }

  private _loadDeletedProducts() {
    this.catalogService.getDeletedProducts().subscribe(x => {
      this.deletedProducts = x;
    });
  }
}
