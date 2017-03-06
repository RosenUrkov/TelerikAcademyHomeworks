function solve() {
    // Your classes
    let genID = (function() {
        let counter = 0;
        return function() {
            return counter++;
        }
    })();

    function copyApp(app) {
        const { name, description, version, rating } = app;
        return new App(name, description, version, rating);
    }

    const VALIDATOR = {
        VALIDATE_STRING(str) {
            if (typeof str !== 'string') {
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

    class App {
        constructor(name, description, version, rating) {
            this.name = name;
            this.description = description;
            this.version = version;
            this.rating = rating;
            this.id = genID();
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x.length, 1, 24);
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
            if (x <= 0) {
                throw Error('');
            }

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
            if (typeof options === 'number' && !Number.isNaN(options)) {
                return this._releaseVersion(options);
            }

            if (typeof options === 'object') {
                return this._releaseOptions(options);
            }

            throw Error('');
        }

        _releaseVersion(version) {
            if (version <= this.version) {
                throw Error('');
            }

            this.version = version;
            this.id = genID();

            return this;
        }

        _releaseOptions(options) {
            if (options.version === undefined) {
                throw Error('');
            }
            VALIDATOR.VALIDATE_NUMBER(options.version);
            this._releaseVersion(options.version);

            if (options.description !== undefined) {
                this.description = options.description;
            }
            if (options.rating !== undefined) {
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

            const foundApp = this.apps.find(x => x.name === app.name);

            if (foundApp === undefined) {
                this.apps.push(copyApp(app));
            } else {
                foundApp._releaseOptions(app);
            }

            return this;
        }

        takedownApp(name) {
            const index = this.apps.findIndex(x => x.name === name);

            if (index < 0) {
                throw Error('');
            }

            this.apps.splice(index, 1);

            return this;
        }

        search(pattern) {
            return this.apps.filter(app => {
                    return app.name.toLowerCase().includes(pattern.toLowerCase());
                })
                .sort((x, y) => {
                    return x.name.localeCompare(y.name);
                });
        }

        listMostRecentApps(count) {
            count = count || 10;

            return this.apps
                .slice()
                .sort((x, y) => {
                    return y.id - x.id;
                })
                .slice(0, count);
        }

        listMostPopularApps(count) {
            count = count || 10;

            return this.apps
                .slice()
                .sort((x, y) => y.rating - x.rating === 0 ? y.id - x.id : y.rating - x.rating)
                .slice(0, count);
        }
    }

    class Device {
        constructor(hostname, apps) {
            this.stores = [];
            this.hostname = hostname;
            this.apps = apps;
        }

        get hostname() {
            return this._hostname;
        }
        set hostname(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x.length, 1, 32);

            this._hostname = x;
        }

        get apps() {
            return this._apps;
        }
        set apps(x) {
            if (!Array.isArray(x)) {
                throw Error('');
            }

            if (x.some(x => !x instanceof App)) {
                throw Error('');
            }

            x = x.map(y => {
                if (y instanceof Store) {
                    this.stores.push(y);
                    return y;
                } else {
                    return copyApp(y);
                }

            });

            this._apps = x;
        }

        search(pattern) {
            let result = [];

            this.stores.forEach(x => {
                result.push(...(x.search(pattern)));
            });

            result = result.filter(x => !result.some(y => x.name === y.name && x.version < y.version));

            return result.sort((x, y) => x.name.localeCompare(y.name));
        }

        install(name) {
            if (this.apps.some(x => x.name === name)) {
                return this;
            }

            let result = [];

            this.stores.forEach(x => {
                result.push(...(x.apps.filter(y => y.name === name)));
            });

            if (result.length === 0) {
                throw Error('');
            }

            const app = result.slice().sort((x, y) => y.version - x.version)[0];

            if (app === undefined) {
                throw Error('');
            }

            this.apps.push(copyApp(app));

            return this;
        }

        uninstall(name) {
            let index = this.apps.findIndex(x => x.name === name);

            if (index < 0) {
                throw Error('');
            }

            this.apps.splice(index, 1);

            return this;
        }

        listInstalled() {
            return this.apps.slice().sort((x, y) => x.name.localeCompare(y.name));
        }

        update() {
            this.apps = this.apps.map(app => {
                let versions = [];

                this.stores.forEach(x => {
                    versions.push(...(x.apps.filter(y => y.name === app.name && y.version > app.version)));
                });

                if (versions.length === 0) {
                    return app;
                }

                return versions.sort((x, y) => y.version - x.version)[0];
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

;
// Submit the code above this line in bgcoder.com
module.exports = solve;