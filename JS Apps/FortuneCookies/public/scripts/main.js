import { Controller } from 'controller';

const controller = new Controller(),
    router = $.sammy(function() {
        this.get('#/login', () => controller.login());

        this.get('#/share', () => controller.shareCookie());

        this.get('#/my-cookie', () => controller.myCookie());

        this.get('#/home', function(context) {
            controller
                .home()
                .then(() => {
                    if (context.params.category) {
                        controller.checkCategories(context.params.category);
                    }
                })
        });

        this.get('#/', function() {
            this.redirect('#/home');
        });
    });

$('.content')
    .on('click', '#register', () => controller.registerUser())
    .on('click', '#sign-in', () => controller.loginUser())

.on('click', '#users', () => controller.getUsers())
    .on('click', '#categories', () => controller.getCategories())
    .on('click', '#search', () => window.location.hash = `#/home?category=${$('input[type="search"]').val()}`)

.on('click', '#add-cookie', () => controller.share())
    .on('click', '#rate', (event) => {
        controller.rateCookie($(event.currentTarget).attr('cookieID'), $(event.target).attr('id'));
        controller.home();
    });

router.run('#/home');