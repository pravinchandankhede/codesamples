import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountSummaryComponent } from './account-summary/account-summary.component';
import { TransactionHistoryComponent } from './transaction-history/transaction-history.component';
import { BankingRoutingModule } from './banking-routing.module';

@NgModule({
  declarations: [
    AccountSummaryComponent,
    TransactionHistoryComponent
  ],
  imports: [
    CommonModule,
    BankingRoutingModule
  ]
})
export class BankingModule { }
