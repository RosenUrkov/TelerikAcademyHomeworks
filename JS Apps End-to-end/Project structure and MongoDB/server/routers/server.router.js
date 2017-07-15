const { Router } = require('express');

const attach = (app, { serverController }) => {
    const serverRouter = new Router();

    serverRouter.get('/', serverController.redirectHome);
    serverRouter.get('/home', serverController.home);

    serverRouter.get('/flash', serverController.flash);

    serverRouter.get('/items', serverController.showItems);
    serverRouter.post('/items', serverController.addItem);

    app.use('/', serverRouter);
};

module.exports = attach;
