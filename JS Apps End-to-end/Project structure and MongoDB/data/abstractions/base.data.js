class Data {
    constructor(db, ModelClass) {
        this.collectionName = ModelClass.name.toLowerCase() + 's';
        this.collection = db.collection(this.collectionName);
    }

    all() {
        return this.filter({});
    }

    filter(filterObject) {
        return this.collection.find(filterObject).toArray();
    }

    add(item) {
        return this.collection.insert(item);
    }
}

module.exports = Data;
