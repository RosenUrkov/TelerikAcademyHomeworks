export class Controller {
    constructor(requester, dataService) {
        this.requester = requester;
        this.dataService = dataService;
    }

    loadLoginTemplate() {
        if (window.localStorage.getItem('username')) {
            window.location.hash = '#/home';
            return;
        }

        this.requester.getTemplate('login')
            .then(data => $('.container').html(data));
    }

    loadHomeTemplate() {
        if (!window.localStorage.getItem('username')) {
            window.location.hash = '#/login';
            return;
        }

        this.requester.getTemplate('home')
            .then(data => $('.container').html(data))
            .then(() => $('#logged').html('User: ' + window.localStorage.getItem('username')));
    }

    registerUser() {
        const user = this.dataService.getUser();

        this.requester.postJSON('api/users', user)
            .catch(() => this.loadLoginTemplate());
    }

    loginUser() {
        const user = this.dataService.getUser();

        this.requester.putJSON('api/auth', user)
            .catch(data => {
                const response = JSON.parse(data.responseText);

                if (response.username) {
                    window.localStorage.setItem("username", response.username);
                    window.localStorage.setItem("authKey", response.authKey);

                    window.location.hash = '#/home';
                } else {
                    this.loadLoginTemplate();
                }
            });
    }

    logoutUser() {
        window.localStorage.clear();
    }

    showUsers() {
        this.requester.getTemplate('user')
            .then((template) => Handlebars.compile(template))
            .then((template) => {
                return new Promise((resolve, reject) => {
                        this.requester.getJSON('api/users')
                            .catch(data => resolve(data));
                    })
                    .catch(data => {
                        const result = template(JSON.parse(data.responseText));
                        $('.main').html(result);
                    });
            });
    }

    showThreads() {
        this.requester.getTemplate('thread')
            .then((template) => Handlebars.compile(template))
            .then((template) => {
                return new Promise((resolve, reject) => {
                        this.requester.getJSON('api/threads')
                            .catch(data => resolve(data));
                    })
                    .catch(data => {
                        const result = template(JSON.parse(data.responseText));
                        $('.main').html(result);
                    });
            });
    }

    searchThread() {
        const id = $('#search').val();

        $('.main')
            .children('.wrapper')
            .each((_, element) => {
                if (id === '' || $(element).attr('id') === id) {
                    $(element).show();
                } else {
                    $(element).hide();
                }
            })
    }

    addThread() {
        const thread = this.dataService.getRequestData('#title', 'title');

        this.requester.postJSON('api/threads', thread);
    }

    addMessage(event) {
        const id = $(event.target).parents('.wrapper').attr('id'),
            data = this.dataService.getRequestData('#message', 'content');

        this.requester.postJSON(`api/threads/${id}/messages`, data);
    }
}