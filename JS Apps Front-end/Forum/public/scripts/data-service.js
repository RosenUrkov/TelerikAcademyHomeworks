export class DataService {
    getUser() {
        const username = $('#username').val(),
            passHash = $('#password').val(),
            user = {
                username,
                passHash: CryptoJS.SHA1(passHash).toString()
            };

        return user;
    }

    getRequestData(selector, key) {
        const data = {
            [key]: $(selector).val(),
            username: window.localStorage.getItem('username'),
            authKey: window.localStorage.getItem('authKey')
        };

        $(selector).val('');
        return data;
    }
}