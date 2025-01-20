import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../core/logger.service';
import { CachingService } from '../../core/caching.service';

@Component({
    selector: 'app-transaction-history',
    templateUrl: './transaction-history.component.html',
    styleUrls: ['./transaction-history.component.css'],
    standalone: false,
})
export class TransactionHistoryComponent implements OnInit {
    transactions = [
        { date: '2025-01-01', amount: -100, description: 'Grocery Shopping' },
        { date: '2025-01-05', amount: 2000, description: 'Salary' },
        { date: '2025-01-10', amount: -50, description: 'Electricity Bill' }
    ];

    constructor(private logger: LoggerService,
                private cache: CachingService) {
    }

    ngOnInit(): void {
        this.cache.set('transactions', this.transactions);
        const cachedTransactions = this.cache.get('transactions');
        this.logger.log('Cached Transactions:' + cachedTransactions);        
    }
}
