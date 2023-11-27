import { Routes } from '@angular/router';

export const routes: Routes = [
{
    path: 'home',
    loadComponent: () =>
    import('./home/home.component').then((m) => m.HomeComponent),
},
{
    path: 'product-details/:id',
    loadComponent: () =>
    import('./product-details/product-details.component').then((m) => m.ProductDetailsComponent),
},
{
    path: 'trash',
    loadComponent: () =>
    import('./trash/trash.component').then((m) => m.TrashComponent),
},
{
    path: 'auth',
    loadComponent: () =>
    import('./auth/auth.component').then((m) => m.AuthComponent),
},
{
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
},
];