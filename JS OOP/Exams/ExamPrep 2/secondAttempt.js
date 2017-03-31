function solve() {

    const VALIDATOR = {
        VALIDATE_STRING(str) {
            if (typeof str !== 'string') {
                throw Error('');
            }
        },
        VALIDATE_STRING_RANGE(str, min, max) {
            if (str.length < min || str.length > max) {
                throw Error('');
            }
        },
        VALIDATE_NUMBER(num) {
            if (typeof num !== 'number' || Number.isNaN(num)) {
                throw Error('');
            }
        },
        VALIDATE_NUMBER_RANGE(num, min, max) {
            if (num < min || num > max) {
                throw Error('');
            }
        }
    }

    let getID = (function() {
        let counter = 0;

        return function() {
            return ++counter;
        }
    })();

    class Item {
        constructor(name, description) {
            this.id = getID();
            this.name = name;
            this.description = description;
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_STRING_RANGE(x, 2, 40);

            this._name = x;
        }

        get description() {
            return this._description;
        }
        set description(x) {
            VALIDATOR.VALIDATE_STRING(x);
            if (x.length <= 0) {
                throw Error('');
            }

            this._description = x;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }
        set isbn(x) {
            VALIDATOR.VALIDATE_STRING(x);
            if (!(x.length === 10 || x.length === 13)) {
                throw Error('');
            }
            if (!(/^[0-9]+$/g.test(x))) {
                throw Error('');
            }

            this._isbn = x;
        }

        get genre() {
            return this._genre;
        }
        set genre(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_STRING_RANGE(x, 2, 20);

            this._genre = x;
        }

    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);
            this.rating = rating;
            this.duration = duration;
        }

        get duration() {
            return this._duration;
        }
        set duration(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            if (x <= 0) {
                throw Error('');
            }

            this._duration = x;
        }

        get rating() {
            return this._rating;
        }
        set rating(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 1, 5);

            this._rating = x;
        }
    }

    class Catalog {
        constructor(name) {
            this.items = [];
            this.id = getID();
            this.name = name;
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_STRING_RANGE(x, 2, 40);

            this._name = x;
        }

        add(...items) {
            if (Array.isArray(items[0])) {
                items = items[0];
            }

            if (items.length === 0) {
                throw Error('');
            }

            items.forEach(x => {
                new Item(x.name, x.description);
            });

            this.items.push(...items);

            return this;
        }

        find(options) {
            if (typeof options === 'number') {
                return this._findByID(options);
            }

            if (typeof options === 'object') {
                return this._findByOptions(options);
            }

            throw Error('');
        }

        _findByID(id) {
            VALIDATOR.VALIDATE_NUMBER(id);
            let result;

            result = this.items.find(x => x.id === id);

            if (result === undefined) {
                return null;
            }
            return result;
        }

        _findByOptions(options) {
            return this.items.filter(item => {
                return Object.keys(options).every(prop => {
                    return options[prop] === item[prop];
                });
            });
        }

        search(pattern) {

            VALIDATOR.VALIDATE_STRING(pattern);
            if (pattern === undefined || pattern === null || pattern.length === 0) {
                throw Error('');
            }

            return this.items.filter(item => {
                return ['name', 'description'].some(prop => {
                    return item[prop].includes(pattern);
                })
            })
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (Array.isArray(books[0])) {
                books = books[0];
            }

            if (books.length === 0) {
                throw Error('');
            }

            books.forEach(x => {
                new Book(x.name, x.isbn, x.genre, x.description);
            })

            return super.add(...books);
        }

        find(options) {
            return super.find(options);
        }

        getGenres() {
            let genres = {};

            for (let item of this.items) {
                if (item.genre === undefined) {
                    continue;
                }

                genres[item.genre.toLowerCase()] = true;
            }

            return Object.keys(genres);
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...medias) {
            if (Array.isArray(medias[0])) {
                medias = medias[0];
            }

            if (medias.length === 0) {
                throw Error('');
            }

            medias.forEach(x => {
                new Media(x.name, x.rating, x.duration, x.description);
            });

            return super.add(...medias);
        }

        find(options) {
            return super.find(options);
        }

        getTop(count) {
            VALIDATOR.VALIDATE_NUMBER(count);
            if (count < 1) {
                throw Error('');
            }

            return this.items.filter(item => {
                    return ['rating', 'duration'].every(prop => {
                        return item[prop] !== undefined;
                    });
                })
                .sort((x, y) => {
                    return y.rating - x.rating;
                })
                .slice(0, count)
                .map(x => ({ id: x.id, name: x.name }));
        }

        getSortedByDuration() {
            return this.items.filter(item => {
                    return ['rating', 'duration'].every(prop => {
                        return item[prop] !== undefined;
                    });
                })
                .sort((x, y) => {
                    let result = y.duration - x.duration;

                    if (result === 0) {
                        return x.id - y.id;
                    }

                    return result;

                });
        }
    }


    return {
        getBook: function(name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function(name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function(name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function(name) {
            return new MediaCatalog(name);
        }
    };
}

module.exports = solve;