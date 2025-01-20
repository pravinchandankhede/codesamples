import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockPortfolioComponent } from './stock-portfolio/stock-portfolio.component';
import { MarketTrendsComponent } from './market-trends/market-trends.component';

const routes: Routes = [
    { path: 'stock-portfolio', component: StockPortfolioComponent },
    { path: 'market-trends', component: MarketTrendsComponent },
    { path: '', component: StockPortfolioComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class StocksRoutingModule { }
