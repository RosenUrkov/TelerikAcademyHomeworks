import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit {
    public name: string;
    public age: number;
    public email: string;
    public address: Address;
    public hobbies: string[];
    public isEdit: boolean;

    constructor() { }

    ngOnInit() {
        this.name = 'Pesho';
        this.age = 30;
        this.email = 'peshaka@abv.bg';
        this.hobbies = ['write code', 'watch movies', 'drink beer'];
        this.address = {
            street: 'Vihren 18',
            city: 'Pleven',
            country: 'Bulgaria',
        };

        this.isEdit = false;
    }

    addHobbie(hobbie: string): void {
        this.hobbies.push(hobbie);
    }

    removeHobbie(hobbie: string): void {
        this.hobbies = this.hobbies.filter(x => x !== hobbie);
    }

    toggleEdit(): void {
        this.isEdit = !this.isEdit;
    }
}

interface Address {
    street: string;
    city: string;
    country: string;
}
