import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './shared/home/home.component';

const routes: Routes = [
    {
        path: 'app',
        component: HomeComponent,        
        children: [
            {
                path: 'banking',
                loadChildren: () => import('./banking/banking.module')
                    .then(mod => mod.BankingModule)
            },
            {
                path: 'mutual-funds',
                loadChildren: () => import('./mutual-funds/mutual-funds.module')
                    .then(mod => mod.MutualFundsModule)
            },
            {
                path: 'stocks',
                loadChildren: () => import('./stocks/stocks.module')
                    .then(mod => mod.StocksModule)
            },
            {
                path: '', pathMatch: 'full', redirectTo: 'banking'
            },
            {
                path: '**', pathMatch: 'full', redirectTo: 'banking',
            }
        ]
    },    
    {
        path: '', pathMatch: 'full', redirectTo: 'app/banking',
    },
    {
        path: '**', pathMatch: 'full', redirectTo: 'app/banking',
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
