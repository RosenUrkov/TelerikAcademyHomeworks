const server = require('express')();
require('../config/app.config')(server);

module.exports = server;
