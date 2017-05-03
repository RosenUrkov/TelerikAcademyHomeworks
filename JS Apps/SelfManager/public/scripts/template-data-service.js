import { requester } from 'requester';

class DataService {
    constructor(requester) {
        this.requester = requester;
        this.cache = {};
    }

    header() {
        if (!this.cache.header) {
            this.cache.header = this.requester.getTemplate('header');

        }

        return this.cache.header;
    }

    home() {
        if (!this.cache.home) {
            this.cache.home = this.requester.getTemplate('home');
        }

        return this.cache.home;
    }

    login() {
        if (!this.cache.login) {
            this.cache.login = this.requester.getTemplate('login');

        }

        return this.cache.login;
    }
}

const templateDataService = new DataService(requester);
export { templateDataService };