import { templateController } from 'template-controller';
import { userController } from 'user-controller';

const router = $.sammy(function() {

    this.get('#/home', () => templateController.home());
    this.get('#/login', () => templateController.login());
    this.get('#/todos', () => templateController.home());
    this.get('#/events', () => templateController.home());
    this.get('#/', context => context.redirect('#/home'));
});

$('.container')
    .on('click', '#sign-in', () => userController.login())
    .on('click', '#sign-up', () => userController.register());

templateController.header();

router.run('#/home');