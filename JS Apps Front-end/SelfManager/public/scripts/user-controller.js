import { userDataService } from 'user-data-service';

class UserController {
    constructor(dataService) {
        this.dataService = dataService;
    }

    register() {
        this.dataService.register()
            .then(() => toastr.success('Registered succesfully!'))
            .catch((responce) => toastr.error(responce.responceText));
    }

    login() {
        this.dataService.login()
            .then(() => toastr.success(`Welcome, ${localStorage.getItem(this.dataService.USERNAME_HEADER_NAME)}!`))
            .then(() => $('#login').html('Logout').one('click', () => this.logout()))
            .then(() => $("#user").show())
            .catch((responce) => toastr.error(responce.responceText));
    }

    logout() {
        this.dataService.logout()
            .then(() => $('#login').html("Login"))
            .then(() => $("#user").hide())
            .then(() => toastr.success(`Goodbye!`))
            .catch(() => toastr.error('Failed to logout!'));
    }

    checkUser() {
        if (this.dataService.checkUser()) {
            $('#login')
                .html('Logout')
                .one('click', () => this.logout());

            $("#user").show();
        }
    }

    getUsers() {

    }
}

const userController = new UserController(userDataService);
export { userController };