import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountSummaryComponent } from './account-summary/account-summary.component';
import { TransactionHistoryComponent } from './transaction-history/transaction-history.component';
import { BankingRoutingModule } from './banking-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [
        AccountSummaryComponent,
        TransactionHistoryComponent
    ],
    imports: [
        CommonModule,
        BankingRoutingModule,
        SharedModule
    ]
})
export class BankingModule { }
