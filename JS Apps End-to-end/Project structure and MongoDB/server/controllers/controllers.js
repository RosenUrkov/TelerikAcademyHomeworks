/* globals __dirname */
const path = require('path');
const fileSystem = require('fs');

const attach = (data) => {
    const controllers = {};

    fileSystem.readdirSync(__dirname)
        .filter((file) => file.includes('.controller'))
        .forEach((file) => {
            const modulePath = path.join(__dirname, file);

            const controllerName = file.replace('.c', 'C').replace('.js', '');
            controllers[controllerName] = require(modulePath)(data);
        });

    return controllers;
};

module.exports = attach;
