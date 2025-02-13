import { Component, OnInit } from '@angular/core';
import { MutualFundService } from '../../services/mutualfund.service';

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

    constructor(private fundService: MutualFundService) { }

    ngOnInit(): void {
        this.fundService.getFundOverview().subscribe(data => {
            this.funds = data;
        });
    }
}
