/* globals __dirname */
const config = (server) => {
    const path = require('path');
    const express = require('express');
    const parser = require('body-parser');
    const morgan = require('morgan');

    server.set('view engine', 'pug');

    server.use(parser.json());
    server.use(morgan('combined'));

    server.use('/public', express.static(path.join(__dirname, '../public')));
    server.use('/libs', express.static(path.join(__dirname, '../node_modules')));

    require('../routes/server.routes')(server);
};

module.exports = config;
