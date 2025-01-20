import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../core/logger.service';
import { CachingService } from '../core/caching.service';

@Component({
    selector: 'app-account-summary',
    templateUrl: './account-summary.component.html',
    styleUrls: ['./account-summary.component.css']
})
export class AccountSummaryComponent implements OnInit {
    accountBalance: number = 5000;

    constructor(private logger: LoggerService,
                private cache: CachingService) {
    }

    ngOnInit(): void {
        this.cache.set('accountBalance', this.accountBalance);
        const cachedBalance = this.cache.get('accountBalance');
        this.logger.log('Cached Account Balance:', cachedBalance);        
    }
}
