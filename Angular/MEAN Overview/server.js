const config = require('./server/config');
const { MongoClient } = require('mongodb');

MongoClient.connect(config.DB_LOCAL_CONNECTION_STRING)
    .then((database) => require('./server/data')(database))
    .then((data) => require('./server/app')(data))
    .then((app) => {
        // eslint-disable-next-line
        app.listen(config.PORT, () => console.log(`Server running on port ${config.PORT}..`));
    });
