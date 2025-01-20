import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-stock-portfolio',
    templateUrl: './stock-portfolio.component.html',
    styleUrls: ['./stock-portfolio.component.css'],
    standalone: false,
})
export class StockPortfolioComponent implements OnInit {
    stocks = [
        { name: 'AAPL', quantity: 10, price: 150 },
        { name: 'GOOGL', quantity: 5, price: 2800 },
        { name: 'AMZN', quantity: 2, price: 3400 }
    ];

    constructor() { }

    ngOnInit(): void {
    }
}
