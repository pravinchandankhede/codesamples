import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountSummaryComponent } from './account-summary/account-summary.component';
import { TransactionHistoryComponent } from './transaction-history/transaction-history.component';

const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'account-summary', component: AccountSummaryComponent },
            { path: 'transaction-history', component: TransactionHistoryComponent },
            { path: '', component: AccountSummaryComponent },
            { path: '**', pathMatch: 'full', redirectTo: 'account-summary'}
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BankingRoutingModule { }
