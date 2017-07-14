/* globals __dirname */

const path = require('path');
const fileSystem = require('fs');

const data = (db) => {
    const dataObject = {};

    fileSystem.readdirSync(__dirname)
        .filter((file) => file.includes('.data'))
        .forEach((file) => {
            const modulePath = path.join(__dirname, file);

            const dataName = file.replace('.d', 'D').replace('.js', '');
            const CurrentData = require(modulePath);
            dataObject[dataName] = new CurrentData(db);
        });

    return Promise.resolve(dataObject);
};

module.exports = data;
