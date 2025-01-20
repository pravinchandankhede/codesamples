import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockPortfolioComponent } from './stock-portfolio.component';

describe('StockPortfolioComponent', () => {
  let component: StockPortfolioComponent;
  let fixture: ComponentFixture<StockPortfolioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StockPortfolioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StockPortfolioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
