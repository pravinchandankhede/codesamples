import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-fund-overview',
    templateUrl: './fund-overview.component.html',
    styleUrls: ['./fund-overview.component.css'],
    standalone: false,
})
export class FundOverviewComponent implements OnInit {
    funds = [
        { name: 'Equity Fund', value: 10000 },
        { name: 'Debt Fund', value: 5000 },
        { name: 'Hybrid Fund', value: 7500 }
    ];

    constructor() { }

    ngOnInit(): void {
    }
}
