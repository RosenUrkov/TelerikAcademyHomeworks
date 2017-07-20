const express = require('express');

const application = (data) => {
    const app = express();

    app.use('/public', express.static('public'));
    app.use('/libs', express.static('node_modules'));

    require('./config/app.config')(app);

    const controllers = require('./controllers')(data);
    require('./routers')(app, controllers);

    const server = require('./config/socket.config')(app);
    return Promise.resolve(server);
};

module.exports = application;
