const { Router } = require('express');

const attach = (app, { serverController }) => {
    const serverRouter = new Router();

    serverRouter.get('/', serverController.home);
    serverRouter.get('/flash', serverController.flash);

    app.use('/', serverRouter);
};

module.exports = attach;
