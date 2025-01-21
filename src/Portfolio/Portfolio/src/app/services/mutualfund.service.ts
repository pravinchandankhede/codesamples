import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class MutualFundService {
    private apiUrl = 'http://localhost:5130/api/mutualfund';

    constructor(private http: HttpClient) { }

    getFundOverview(): Observable<any> {
        return this.http.get(`${this.apiUrl}/overview`);
    }

    calculateInvestment(principal: number, rate: number, time: number): Observable<any> {
        return this.http.get(`${this.apiUrl}/calculate`, {
            params: {
                principal: principal.toString(),
                rate: rate.toString(),
                time: time.toString()
            }
        });
    }
}
