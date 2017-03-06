function solve() {

    const VALIDATOR = {
        VALIDATE_STRING(input) {
            if (typeof input !== 'string') {
                throw Error('input was not of type string!');
            }
        },
        VALIDATE_EMPTY_STRING(input) {
            if (input === '') {
                throw Error('input cannot be an empty string!');
            }
        },
        VALIDATE_STRING_LENGTH(input, minLength, maxLength) {
            if (input.length < minLength || input.length > maxLength) {
                throw Error('input string length was outside the given range!');
            }
        },
        VALIDATE_NUMBER(input) {
            if (typeof input !== 'number' || Number.isNaN(input)) {
                throw Error('input was not of type number or was NaN!');
            }
        },
        VALIDATE_NUMBER_RANGE(value, min, max) {
            if (value < min || value > max) {
                throw Error('passed value was outside the given range!');
            }
        },
        VALIDATE_NUMBER_LESS_THAN(value, min) {
            if (value < min) {
                throw Error('value was less than the given minimum!');
            }
        },
        VALIDATE_NUMBER_BIGGER_THAN(value, max) {
            if (value > max) {
                throw Error('value was greate than the given maximum!');
            }
        }
    };

    let getID = (function() {
        let counter = 0;

        return function() {
            return ++counter;
        }
    })();

    class App {
        constructor(name, description, version, rating) {
            this.name = name;
            this.description = description;
            this.version = version;
            this.rating = rating;
            this.id = getID();
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_STRING_LENGTH(x, 1, 24);
            if (!/^[A-Za-z0-9 ]+$/g.test(x)) {
                throw Error('');
            }

            this._name = x;
        }

        get description() {
            return this._description;
        }
        set description(x) {
            VALIDATOR.VALIDATE_STRING(x);

            this._description = x;
        }

        get version() {
            return this._version;
        }
        set version(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_NUMBER_LESS_THAN(x, 1);

            this._version = x;
        }

        get rating() {
            return this._rating;
        }
        set rating(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 1, 10);

            this._rating = x;
        }

        release(options) {
            if (typeof options === 'number') {
                return this._releaseVersion(options);
            }

            if (typeof options === 'object') {
                return this._releaseOptions(options);
            }

            throw Error('');
        }

        _releaseVersion(options) {
            if (options <= this.version) {
                throw Error('');
            }

            this.version = options;
            this.id = getID();

            return this;
        }

        _releaseOptions(options) {
            if (!options.hasOwnProperty('version')) {
                throw Error('');
            }
            this._releaseVersion(options);


            if (options.hasOwnProperty('description')) {
                this.description = options.description;
            }

            if (options.hasOwnProperty('rating')) {
                this.rating = options.rating;
            }

            return this;
        }
    }

    class Store extends App {
        constructor(name, description, version, rating) {
            super(name, description, version, rating);
            this.apps = [];
        }

        uploadApp(app) {
            if (!(app instanceof App)) {
                throw Error('');
            }

            let x = this.apps.find(x => x.name === app.name);

            if (x === undefined) {
                let { name, description, version, rating } = app;
                this.apps.push(new App(name, description, version, rating));

                return this;
            }

            x.release(app);

            return this;
        }

        takedownApp(name) {
            let index = this.apps.findIndex(x => x.name === name);

            if (index === -1) {
                throw Error('');
            }

            this.apps.splice(index, 1);

            return this;
        }

        search(pattern) {
            return this.apps.filter(x => x.name.toLowerCase().includes(pattern.toLowerCase()))
                .sort((x, y) => {
                    return x.name.localeCompare(y.name);
                });
        }

        listMostRecentApps(count) {
            count = count || 10;

            return this.apps
                .slice()
                .sort((x, y) => y.id - x.id)
                .splice(0, count);
        }

        listMostPopularApps(count) {
            count = count || 10;

            return this.apps
                .slice()
                .sort((x, y) => {
                    let result = y.rating - x.rating;

                    if (result === 0) {
                        return y.id - x.id;
                    }

                    return result;
                })
                .splice(0, count);
        }
    }

    class Device {
        constructor(hostname, apps) {
            this.hostname = hostname;
            this.apps = apps;
        }

        get hostname() {
            return this._hostname;
        }
        set hostname(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_STRING_LENGTH(x, 1, 32);

            this._hostname = x;
        }

        get apps() {
            return this._apps;
        }
        set apps(x) {
            if (!Array.isArray(x)) {
                throw Error('');
            }

            if (x.some(y => !(y instanceof App))) {
                throw Error('');
            }

            x.forEach(y => y.id = getID());

            this._apps = x;
        }

        search(pattern) {
            let result = [];

            this.apps
                .filter(app => app.hasOwnProperty('apps'))
                .forEach(store => result.push(...(store.search(pattern))));

            let copy = result.slice();

            result = result.filter(app => {
                return !copy.some(annApp =>
                    annApp.name === app.name &&
                    annApp.version > app.version);
            });

            return result.sort((x, y) => {
                return x.name.localeCompare(y.name);
            });
        }

        listInstalled() {
            return this.apps.slice()
                .sort((x, y) => x.name.localeCompare(y.name));
        }

        install(name) {
            let result = [],
                app;

            //result.push(...(this.apps.filter(x => x.name === name)));

            this.apps
                .filter(x => x.hasOwnProperty('apps'))
                .forEach(x => result.push(...(x.apps.filter(y => y.name === name))));

            if (result.length === 0) {
                throw Error('');
            }

            app = result.sort((x, y) => y.version - x.version)[0];

            if (this.apps.some(x => x === app)) {
                return this;
            }

            app.id = getID();
            this.apps.push(app);
            return this;
        }

        uninstall(name) {
            let index = this.apps.findIndex(x => x.name === name);

            if (index === -1) {
                throw Error('');
            }

            this.apps.splice(index, 1);

            return this;
        }

        update() {
            let newApp;

            this.apps.map(app => {
                let res = this.apps
                    .filter(x => x.hasOwnProperty('apps'))
                    .some(z => {
                        newApp = z.apps
                            .sort((x, y => y.version - x.version))
                            .find(y => y.name === app.name &&
                                y.version > app.version);

                        return !!newApp;
                    });

                if (res) {
                    app.release(newApp);
                }
            });

            return this;
        }
    }

    return {
        createApp(name, description, version, rating) {
            return new App(name, description, version, rating);
        },
        createStore(name, description, version, rating) {
            return new Store(name, description, version, rating);
        },
        createDevice(hostname, apps) {
            return new Device(hostname, apps);
        }
    };
}

// Submit the code above this line in bgcoder.com
//module.exports = solve;