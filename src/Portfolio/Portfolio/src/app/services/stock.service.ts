import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class StockService {
    private apiUrl = 'http://localhost:5130/api/stock';

    constructor(private http: HttpClient) { }

    getStockPortfolio(): Observable<any> {
        return this.http.get(`${this.apiUrl}/portfolio`);
    }

    getMarketTrends(): Observable<any> {
        return this.http.get(`${this.apiUrl}/trends`);
    }
}
