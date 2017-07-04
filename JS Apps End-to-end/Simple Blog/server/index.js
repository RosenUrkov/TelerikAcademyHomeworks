const server = require('express')();
require('../config/auth.config')(server, require('../database'));
require('../config/app.config')(server);

module.exports = server;
