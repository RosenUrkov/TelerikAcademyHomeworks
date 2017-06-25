require('./polyfills');
const fileSystem = require('fs');
const { stealAllTheData } = require('./core');

stealAllTheData()
    .then((data) => {
        fileSystem.writeFileSync('result.json', JSON.stringify(data));
    });
