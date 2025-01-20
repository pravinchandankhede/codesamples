import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-investment-calculator',
    templateUrl: './investment-calculator.component.html',
    styleUrls: ['./investment-calculator.component.css'],
    standalone: false,
})
export class InvestmentCalculatorComponent implements OnInit {
    principal: number = 1000;
    rateOfReturn: number = 5;
    years: number = 10;
    futureValue: number = 0;

    constructor() { }

    ngOnInit(): void {
    }

    calculateFutureValue(): void {
        this.futureValue = this.principal * Math.pow((1 + this.rateOfReturn / 100), this.years);
    }
}
