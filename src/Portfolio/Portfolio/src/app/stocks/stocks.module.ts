import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockPortfolioComponent } from './stock-portfolio/stock-portfolio.component';
import { MarketTrendsComponent } from './market-trends/market-trends.component';
import { StocksRoutingModule } from './stocks-routing.module';

@NgModule({
    declarations: [
        StockPortfolioComponent,
        MarketTrendsComponent
    ],
    imports: [
        CommonModule,
        StocksRoutingModule
    ]
})
export class StocksModule { }
