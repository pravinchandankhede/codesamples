import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-hello-world',
    standalone: false,
    templateUrl: './hello-world.component.html',
    styleUrl: './hello-world.component.css'
})
export class HelloWorldComponent {
    @Input() name: string = 'World';
}
