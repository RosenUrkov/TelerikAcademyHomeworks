import { requester } from 'requester';

class UserDataService {
    constructor(requester) {
        this.requester = requester;
        this.AUTH_KEY_HEADER_NAME = 'x-auth-key';
        this.USERNAME_HEADER_NAME = 'username';
    }

    register() {
        return this.requester.postJSON('api/users', this.getUserData());
    }

    login() {
        return this.requester.putJSON('api/users/auth', this.getUserData())
            .then((data) => {
                localStorage.setItem(this.USERNAME_HEADER_NAME, data.result.username);
                localStorage.setItem(this.AUTH_KEY_HEADER_NAME, data.result.authKey);
            })
            .then(() => $("#user").html(`User: ${localStorage.getItem(this.USERNAME_HEADER_NAME)}`));
    }

    logout() {
        return new Promise((resolve, reject) => {
            localStorage.removeItem(this.USERNAME_HEADER_NAME);
            localStorage.removeItem(this.AUTH_KEY_HEADER_NAME);
            resolve();
        });
    }

    getUserData() {
        const user = {
            username: $('#input-username').val(),
            passHash: CryptoJS.SHA1($('#input-password').val()).toString()
        };

        $('#input-username').val('');
        $('#input-password').val('');

        return user;
    }

    checkUser() {
        return localStorage.getItem(this.USERNAME_HEADER_NAME);
    }
}

const userDataService = new UserDataService(requester);
export { userDataService };