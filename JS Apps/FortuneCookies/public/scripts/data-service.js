import { Requester } from 'requester';

export class DataService {
    constructor() {
        this.header = 'x-auth-key';
    }

    getUserData() {
        const usernameInput = $('input[type="username"]'),
            passwordInput = $('input[type="password"]'),
            username = usernameInput.val(),
            passHash = passwordInput.val(),
            user = {
                username,
                passHash
            };

        usernameInput.val('');
        passwordInput.val('');

        return user;
    }

    getCookieData() {
        const text = $('input[type="text"]').val(),
            category = $('input[type="category"]').val(),
            img = $('input[type="img"]').val() || 'https://dayinthelifeofapurpleminion.files.wordpress.com/2014/12/batman-exam.jpg',
            cookie = {
                text,
                category,
                img
            }

        return cookie;
    }
}