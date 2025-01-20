import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FundOverviewComponent } from './fund-overview/fund-overview.component';
import { InvestmentCalculatorComponent } from './investment-calculator/investment-calculator.component';
import { MutualFundsRoutingModule } from './mutual-funds-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        FundOverviewComponent,
        InvestmentCalculatorComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        MutualFundsRoutingModule
    ]
})
export class MutualFundsModule { }
