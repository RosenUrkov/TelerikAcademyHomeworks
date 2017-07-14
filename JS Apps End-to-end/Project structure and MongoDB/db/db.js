const { MongoClient } = require('mongodb');

const db = (connectionString) => {
    return MongoClient.connect(connectionString);
};

module.exports = db;
