/* globals module */

"use strict";

function solve() {

    class Product {
        constructor(productType, name, price) {
                this.productType = productType;
                this.name = name;
                this.price = price;
            }
            // validate ?        
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }

        add(product) {
            this.products.push(product);

            return this;
        }

        remove(product) {
            let index = this.products.findIndex(x =>
                x.name === product.name &&
                x.productType === product.productType &&
                x.price === product.price);

            if (index <= -1) {
                throw Error('');
            }

            this.products.splice(index, 1);
        }

        showCost() {
            return this.products.reduce((x, y) => x + y.price, 0);
        }

        showProductTypes() {
            let types = {};

            this.products.forEach(x => types[x.productType] = true);

            return Object.keys(types).sort();
        }

        getInfo() {
            function products() {
                let result = {};

                this.products.forEach(x => {
                    if (result[x.name] === undefined) {
                        result[x.name] = { name: x.name, totalCost: x.price, quantity: 1 };
                    } else {
                        result[x.name].totalCost += x.price;
                        result[x.name].quantity += 1;
                    }
                });

                return Object.keys(result).map(x => result[x]);
            }


            return {
                products: products.bind(this)(),
                totalPrice: this.showCost()
            }
        }

    }


    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;