import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CachingService {
    private cache = new Map<string, any>();

    set(key: string, value: any): void {
        this.cache.set(key, value);
    }

    get(key: string): any {
        return this.cache.get(key);
    }

    clear(): void {
        this.cache.clear();
    }

    remove(key: string): void {
        this.cache.delete(key);
    }
}
