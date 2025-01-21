import { Component, OnInit } from '@angular/core';
import { StockService } from '../../services/stock.service';

@Component({
    selector: 'app-market-trends',
    templateUrl: './market-trends.component.html',
    styleUrls: ['./market-trends.component.css'],
    standalone: false,
})
export class MarketTrendsComponent implements OnInit {
    trends = [
        { name: 'Tech', change: 2.5 },
        { name: 'Healthcare', change: -1.2 },
        { name: 'Finance', change: 0.8 }
    ];

    constructor(private stockService: StockService) {
    }

    ngOnInit(): void {
        this.stockService.getMarketTrends().subscribe(data => {
            this.trends = data;
        });
    }
}
