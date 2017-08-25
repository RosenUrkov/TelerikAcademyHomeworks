import { Injectable } from '@angular/core';

import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {
  constructor(private readonly http: Http) { }

  getUsers() {
    return this.http.get('/api/users')
      .map(x => x.json());
  }
}
