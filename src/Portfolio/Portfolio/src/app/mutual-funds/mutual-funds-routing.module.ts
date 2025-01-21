import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FundOverviewComponent } from './fund-overview/fund-overview.component';
import { InvestmentCalculatorComponent } from './investment-calculator/investment-calculator.component';

const routes: Routes = [
    { path: 'fund-overview', component: FundOverviewComponent },
    { path: 'investment-calculator', component: InvestmentCalculatorComponent },
    { path: '', component: FundOverviewComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'fund-overview' }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MutualFundsRoutingModule { }
