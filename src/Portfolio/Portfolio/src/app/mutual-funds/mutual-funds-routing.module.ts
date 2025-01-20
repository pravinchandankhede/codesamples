import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FundOverviewComponent } from './fund-overview/fund-overview.component';
import { InvestmentCalculatorComponent } from './investment-calculator/investment-calculator.component';

const routes: Routes = [
    { path: 'fund-overview', component: FundOverviewComponent },
    { path: 'investment-calculator', component: InvestmentCalculatorComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MutualFundsRoutingModule { }
