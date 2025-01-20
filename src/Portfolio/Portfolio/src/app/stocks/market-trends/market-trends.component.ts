import { Component, OnInit } from '@angular/core';

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

    constructor() { }

    ngOnInit(): void {
    }
}
