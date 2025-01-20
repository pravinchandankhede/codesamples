import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css'],
    standalone: false,
})
export class ProfileComponent implements OnInit {
    user = {
        name: 'pravin c',
        email: 'pravin.c@git.com',
        phone: '123-456-7890'
    };

    constructor() { }

    ngOnInit(): void {
    }
}
