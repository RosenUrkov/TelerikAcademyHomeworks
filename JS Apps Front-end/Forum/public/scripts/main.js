import { Controller } from 'controller';
import { Requester } from 'requester';
import { DataService } from 'data-service';

const controller = new Controller(new Requester(), new DataService());

const router = $.sammy(function() {
    this.get('#/login', () => controller.loadLoginTemplate());
    this.get('#/home', () => controller.loadHomeTemplate());
});

router.run('#/login');

$('.container')
    .on('click', '#register', () => controller.registerUser())
    .on('click', '#sign-in', () => controller.loginUser())
    .on('click', '#sign-out', () => controller.logoutUser())
    .on('click', '#users', () => controller.showUsers())
    .on('click', '#threads', () => controller.showThreads())
    .on('input', '#search', () => controller.searchThread())
    .on('click', '#add-thread', () => controller.addThread())
    .on('click', '#add-message', (event) => controller.addMessage(event))