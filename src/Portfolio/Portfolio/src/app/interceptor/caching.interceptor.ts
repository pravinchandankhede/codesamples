import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';

interface CachedEntry {
    response: HttpEvent<any>;
    expiration: number;
}

@Injectable()
export class CachingInterceptor implements HttpInterceptor {
    private cache = new Map<string, CachedEntry>();
    private cacheExpirationTime = 20000; // Set cache expiration time in milliseconds

    constructor() {
        //Set the eviction handler to run every minute
        setInterval(() => this.evictHandler(), 60000);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.method !== 'GET') {
            return next.handle(req);
        }

        const cachedResponse = this.cache.get(req.url);
        const now = Date.now();

        if (cachedResponse && cachedResponse.expiration > now) {
            return of(cachedResponse.response);
        }

        return next.handle(req).pipe(
            tap(event => {
                this.cache.set(req.url, {
                    response: event,
                    expiration: now + this.cacheExpirationTime
                });
            })
        );
    }

    private evictHandler(): void {
        const now = Date.now();
        this.cache.forEach((value, key) => {
            if (value.expiration <= now) {
                this.cache.delete(key);
            }
        });
    }
}
