import { Component, ElementRef, ViewChild, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Category } from '../shared/models/category';
import { CatalogParams } from '../shared/models/catalogParams';
import { CatalogService } from '../shared/services/catalog.service';
import { ProductItemComponent } from "../shared/components/product-item/product-item.component";

@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [CommonModule, ProductItemComponent]
})
export class HomeComponent {
  @ViewChild('search') searchTerm?: ElementRef;

  pageTitle = 'Home';
  errorMessage = '';
  catalogService = inject(CatalogService);

  products = this.catalogService.products;
  selectedProduct = this.catalogService.selectedProduct;
  
  categories: Category[] = [];  
  catalogParams!: CatalogParams;

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ];

  onSortSelected(event: any) {
  }

  onCategorySelected(brandId: number) {
  }

  onSearch() {
  }

  onReset() {
  }
}
