import { DataService } from 'data-service';
import { Requester } from 'requester';

export class Controller {
    constructor() {
        this.dataService = new DataService();
        this.requester = new Requester();
    }

    home() {
        let data;
        this.requester
            .getJSON('api/cookies')
            .catch((response) => data = JSON.parse(response.responseText));

        return this.requester.getTemplate('cookie')
            .then((content) => Promise.resolve(Handlebars.compile(content)))
            .then((template) => Promise.resolve(template(data)))
            .then((cookies) => this.requester.getTemplate('homepage').then((home) => home + cookies))
            .then((homepage) => $('.content').html(homepage))
            .then(() => this.checkUser())
            .catch(console.log);
    }

    login() {
        this.requester
            .getTemplate('login')
            .then((content) => $('.content').html(content));
    }

    shareCookie() {
        this.requester
            .getTemplate('shareCookie')
            .then((content) => $('.content').html(content));
    }

    registerUser() {
        const user = this.dataService.getUserData();

        this.requester
            .postJSON('api/users', user)
            .catch(console.log);
    }

    loginUser() {
        const user = this.dataService.getUserData();

        return this.requester
            .putJSON('api/auth', user)
            .then(user => {
                window.localStorage.setItem('username', user.result.username);
                window.localStorage.setItem('authKey', user.result.authKey);
            })
            .then(() => {
                $('#log')
                    .html('Logout')
                    .attr('href', '#/home');
            })
            .then(() => {
                $('#log').one('click', () => this.logoutUser());
            })
            .catch(console.log);
    }

    logoutUser() {
        $('#log')
            .html('Login')
            .attr('href', '#/login');

        $('.user-controls').hide();
        $('#user').css('visibility', 'hidden');

        window.localStorage.clear();
    }

    checkUser() {
        return new Promise((resolve, reject) => {
                if (window.localStorage.getItem('username')) {
                    resolve();
                } else {
                    reject();
                }
            })
            .then(() => {
                $('#log')
                    .html('Logout')
                    .attr('href', '#/home');
            })
            .then(() => {
                $('#log').one('click', () => this.logoutUser());
            })
            .then(() => $('.user-controls').show())
            .then(() => $('#user').css('visibility', 'visible'))
            .then(() => $('#user').html(`User: ${window.localStorage.getItem('username')}`));
    }

    share() {
        const cookie = this.dataService.getCookieData(),
            options = {
                [this.dataService.header]: window.localStorage.getItem('authKey')
            }

        this.requester
            .postJSON('api/cookies', cookie, options);
    }

    rateCookie(id, type) {
        const options = {
            [this.dataService.header]: window.localStorage.getItem('authKey')
        };

        this.requester
            .putJSON('api/cookies/' + id, { type }, options);
    }

    checkCategories(category) {
        $('.content').children().each((_, x) => {
            if (!$(x).hasClass('wrapper')) {
                return;
            }

            if (!($(x).attr('category').toLowerCase() === category.toLowerCase())) {
                $(x).hide();
            }
        });
    }

    myCookie() {
        const options = {
            [this.dataService.header]: window.localStorage.getItem('authKey')
        };

        return this.requester
            .getJSON('api/my-cookie', options)
    }

    getUsers() {
        const options = {
            [this.dataService.header]: window.localStorage.getItem('authKey')
        };

        return this.requester
            .getJSON('api/users', options)
    }

    getCategories() {
        const options = {
            [this.dataService.header]: window.localStorage.getItem('authKey')
        };

        return this.requester
            .getJSON('api/categories', options)
    }
}