const express = require('express');

const app = (data) => {
    const server = express();

    server.use('/public', express.static('public'));
    server.use('/libs', express.static('node_modules'));

    require('./config')(server);

    const controllers = require('./controllers')(data);
    require('./routers')(server, controllers);

    return Promise.resolve(server);
};

module.exports = app;
