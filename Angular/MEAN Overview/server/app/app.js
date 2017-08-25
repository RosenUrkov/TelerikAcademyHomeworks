/* globals __dirname */
const path = require('path');

const express = require('express');
const app = express();

const init = (data) => {
    require('./app.config')(app, data);

    // eslint-disable-next-line
    app.use('/libs', express.static(path.join(__dirname, '../../node_modules')));
    app.use(express.static(path.join(__dirname, '../../dist')));

    const api = require('./routes')(data);
    app.use('/api', api);

    app.get('*', (req, res) => {
        res.sendFile(path.join(__dirname, '../../dist/index.html'));
    });

    return Promise.resolve(app);
};

module.exports = init;
