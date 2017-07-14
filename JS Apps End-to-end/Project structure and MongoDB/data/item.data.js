const Data = require('./abstractions');
const Item = require('../models/Item');

class ItemsData extends Data {
    constructor(db) {
        super(db, Item);
    }
}

module.exports = ItemsData;
