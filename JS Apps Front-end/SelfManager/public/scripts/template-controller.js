import { templateDataService } from 'template-data-service';

class Controller {
    constructor(dataService) {
        this.dataService = dataService;
    }

    header() {
        this.dataService.header()
            .then(template => $('.container').html(template));
    }

    home() {
        this.dataService.home()
            .then(template => $('#content').html(template));
    }

    login() {
        this.dataService.login()
            .then(template => $('#content').html(template));
    }
}

const templateController = new Controller(templateDataService);
export { templateController };