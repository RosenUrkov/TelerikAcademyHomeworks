/* globals __dirname */

const path = require('path');
const fileSystem = require('fs');

const attachRouters = (app, controllers) => {
    fileSystem.readdirSync(__dirname)
        .filter((file) => file.includes('.router'))
        .forEach((file) => {
            const modulePath = path.join(__dirname, file);
            require(modulePath)(app, controllers);
        });
};

module.exports = attachRouters;
