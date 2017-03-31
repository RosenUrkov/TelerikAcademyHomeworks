function solve() {

    let genID = (function() {
        let counter = 0;
        return function() {
            return ++counter;
        }
    })();

    const VALIDATOR = {
        VALIDATE_STRING(str) {
            if (typeof str !== 'string') {
                throw Error();
            }
        },
        VALIDATE_NUMBER(num) {
            if (typeof num !== 'number' || Number.isNaN(num)) {
                throw Error();
            }
        },
        VALIDATE_NUMBER_RANGE(num, min, max) {
            if (num < min || num > max) {
                throw Error();
            }
        },
        VALIDATE_POSITIVE_NUMBER(num) {
            if (num <= 0) {
                throw Error();
            }

        }
    }

    class Product {
        constructor(manufacturer, model, price) {
            this.id = genID();
            this.manufacturer = manufacturer;
            this.model = model;
            this.price = price;
        }

        get manufacturer() {
            return this._manufacturer;
        }
        set manufacturer(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x.length, 1, 20);

            this._manufacturer = x;
        }

        get model() {
            return this._model;
        }
        set model(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x.length, 1, 20);

            this._model = x;
        }

        get price() {
            return this._price;
        }
        set price(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_POSITIVE_NUMBER(x);

            this._price = x;
        }

        getLabel() {
            return this.constructor.name + ' - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';
        }
    }

    class SmartPhone extends Product {
        constructor(manufacturer, model, price, screenSize, operatingSystem) {
            super(manufacturer, model, price);
            this.screenSize = screenSize;
            this.operatingSystem = operatingSystem;
        }

        get screenSize() {
            return this._screenSize;
        }
        set screenSize(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_POSITIVE_NUMBER(x);

            this._screenSize = x;
        }

        get operatingSystem() {
            return this._operatingSystem;
        }
        set operatingSystem(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x.length, 1, 10);

            this._operatingSystem = x;
        }
    }

    class Charger extends Product {
        constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
            super(manufacturer, model, price);
            this.outputVoltage = outputVoltage;
            this.outputCurrent = outputCurrent;
        }

        get outputVoltage() {
            return this._outputVoltage;
        }
        set outputVoltage(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 5, 20);

            this._outputVoltage = x;
        }

        get outputCurrent() {
            return this._outputCurrent;
        }
        set outputCurrent(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 100, 3000);

            this._outputCurrent = x;
        }
    }

    class Router extends Product {
        constructor(manufacturer, model, price, wifiRange, lanPorts) {
            super(manufacturer, model, price);
            this.wifiRange = wifiRange;
            this.lanPorts = lanPorts;
        }

        get wifiRange() {
            return this._wifiRange;
        }
        set wifiRange(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_POSITIVE_NUMBER(x);

            this._wifiRange = x;
        }

        get lanPorts() {
            return this._lanPorts;
        }
        set lanPorts(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            VALIDATOR.VALIDATE_POSITIVE_NUMBER(x);
            if (x !== (x | 0)) {
                throw Error();
            }

            this._lanPorts = x;
        }
    }

    class Headphones extends Product {
        constructor(manufacturer, model, price, quality, hasMicrophone) {
            super(manufacturer, model, price);
            this.quality = quality;
            this.hasMicrophone = hasMicrophone;
        }

        get quality() {
            return this._quality;
        }
        set quality(x) {
            VALIDATOR.VALIDATE_STRING(x);
            if (!['high', 'mid', 'low'].some(y => y === x)) {
                throw Error();
            }

            this._quality = x;
        }

        get hasMicrophone() {
            return this._hasMicrophone;
        }
        set hasMicrophone(x) {
            this._hasMicrophone = !!x;
        }
    }

    class HardwareStore {
        constructor(name) {
            this.name = name;
            this._products = [];
            this.money = 0;
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x.length, 1, 20);

            this._name = x;
        }

        get products() {
            return this._products.map(x => x.product);
        }

        set products(x) {
            if (!Array.isArray(x) || x.some(y => !y instanceof Product)) {
                throw Error();
            }

            let result = {};

            x.forEach(y => {
                if (result[y.id] === undefined) {
                    result[y.id] = { product: y, quantity: 1 };
                } else {
                    result[y.id].quantity += 1;
                }
            });

            this._products = Object.keys(result).map(x => result[x]);
        }

        stock(product, quantity) {
            if (!product instanceof Product) {
                throw Error();
            }

            VALIDATOR.VALIDATE_NUMBER(quantity);
            VALIDATOR.VALIDATE_POSITIVE_NUMBER(quantity);
            if (quantity !== (quantity | 0)) {
                throw Error();
            }

            let result = { product, quantity };
            let prod = this._products.find(y => y.product.id === result.product.id);

            if (prod === undefined) {
                this._products.push(result);
            } else {
                prod.quantity += result.quantity;
            }

            return this;
        }

        sell(productId, quantity) {
            VALIDATOR.VALIDATE_NUMBER(productId);

            VALIDATOR.VALIDATE_NUMBER(quantity);
            VALIDATOR.VALIDATE_POSITIVE_NUMBER(quantity);
            if (quantity !== (quantity | 0)) {
                throw Error();
            }

            let productsForSale = this._products.find(x => x.product.id === productId);

            if (productsForSale === undefined) {
                throw Error();
            }

            if (productsForSale.quantity < quantity) {
                throw Error();
            }

            productsForSale.quantity -= quantity;

            if (productsForSale.quantity === 0) {
                this._products.splice(this._products.findIndex(x => x === productsForSale), 1);
            }

            this.money += productsForSale.product.price * quantity;

            return this;
        }

        getSold() {
            return this.money;
        }

        search(options) {
            if (typeof options === 'string') {
                return this._searchByPattern(options);
            }

            if (typeof options === 'object') {
                return this._searchByOptions(options);
            }

            throw Error();
        }

        _searchByPattern(pattern) {
            return this._products.filter(prod => {
                return prod.product.manufacturer.toLowerCase().includes(pattern.toLowerCase()) ||
                    prod.product.model.toLowerCase().includes(pattern.toLowerCase());
            });
        }

        _searchByOptions(options) {
            let result = this._products.slice();

            if (options.hasOwnProperty('manufacturerPattern')) {
                result = result.filter(x => x.product.manufacturer.includes(options['manufacturerPattern']));
            }
            if (options.hasOwnProperty('modelPattern')) {
                result = result.filter(x => x.product.model.includes(options['modelPattern']));
            }
            if (options.hasOwnProperty('type')) {
                result = result.filter(x => x.product.constructor.name === options['type']);
            }
            if (options.hasOwnProperty('minPrice')) {
                result = result.filter(x => x.product.price >= options['minPrice']);
            }
            if (options.hasOwnProperty('maxPrice')) {
                result = result.filter(x => x.product.price < options['maxPrice']);
            }

            return result;
        }
    }

    return {
        getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
            return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
        },
        getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
            return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
        },
        getRouter(manufacturer, model, price, wifiRange, lanPorts) {
            return new Router(manufacturer, model, price, wifiRange, lanPorts);
        },
        getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
            return new Headphones(manufacturer, model, price, quality, hasMicrophone);
        },
        getHardwareStore(name) {
            return new HardwareStore(name);
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve; // DO NOT SUBMIT THIS LINE