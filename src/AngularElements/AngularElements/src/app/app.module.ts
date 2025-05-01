import { Injector, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { createCustomElement } from '@angular/elements';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HelloWorldComponent } from './hello-world/hello-world.component';

@NgModule({
    declarations: [
        AppComponent,
        HelloWorldComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule
    ],
    providers: [],
})
export class AppModule {

    constructor(private injector: Injector) {
        const helloWorldElement = createCustomElement(HelloWorldComponent, { injector });
        customElements.define('app-hello-world', helloWorldElement);
    }

    ngDoBootstrap() {
    }
}
