import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-button',
    templateUrl: './button.component.html',
    styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {
    public readonly clickMessage: string;

    constructor() {
        this.clickMessage = 'Click me!';
    }

    ngOnInit() {
    }

    changeColor(event) {
        event.target.style.backgroundColor =
            `rgb(${Math.random() * 255},${Math.random() * 255},${Math.random() * 255})`;
    }
}
