const config = require('./config');

Promise.resolve()
    .then(() => require('./db')(config.CLOUD_CONNECTION_STRING))
    .then((db) => require('./data')(db))
    .then((data) => require('./server')(data))
    .then((server) => server.listen(config.PORT, () => {
        console.log(`Magic started at ${config.PORT}..`);
    }));
