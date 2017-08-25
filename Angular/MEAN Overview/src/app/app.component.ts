import { DataService } from './services/data/data.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  users: Array<any>;

  constructor(private readonly dataService: DataService) {
    this.dataService.getUsers()
      .subscribe(res => this.users = res);
  }
}
