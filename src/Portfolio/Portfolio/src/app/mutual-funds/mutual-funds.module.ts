import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FundOverviewComponent } from './fund-overview/fund-overview.component';
import { InvestmentCalculatorComponent } from './investment-calculator/investment-calculator.component';
import { MutualFundsRoutingModule } from './mutual-funds-routing.module';

@NgModule({
    declarations: [
        FundOverviewComponent,
        InvestmentCalculatorComponent
    ],
    imports: [
        CommonModule,
        MutualFundsRoutingModule
    ]
})
export class MutualFundsModule { }
