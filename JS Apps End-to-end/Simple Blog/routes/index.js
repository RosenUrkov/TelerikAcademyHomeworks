/* globals __dirname */

const fileSystem = require('fs');
const path = require('path');

const attachRouters = (server) => {
    fileSystem.readdirSync(__dirname)
        .filter((x) => x.includes('.router'))
        .forEach((x) => {
            require(path.join(__dirname, x))(server);
        });
};

module.exports = attachRouters;
