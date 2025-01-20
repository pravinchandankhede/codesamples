import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ProfileComponent } from './profile/profile.component';
import { CoreModule } from '../core/core.module';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        HeaderComponent,
        FooterComponent,
        ProfileComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        RouterModule
    ],
    exports: [
        HeaderComponent,
        FooterComponent,
        ProfileComponent,
        HomeComponent
    ]
})
export class SharedModule { }
