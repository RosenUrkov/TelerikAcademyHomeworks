const init = (database) => {
    const Data = require('./users.data');
    return Promise.resolve(new Data(database));
};

module.exports = init;
