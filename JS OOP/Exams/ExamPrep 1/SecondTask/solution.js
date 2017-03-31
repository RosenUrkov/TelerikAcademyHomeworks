'use strict';

function solve() {

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    const VALIDATOR = {
        VALID_STRING: function(str, msg) {
            if (typeof str !== 'string') {
                throw Error(msg);
            }
        },
        STRING_IN_RANGE: function(str, min, max, msg) {
            if (str.length < min || str.length > max) {
                throw Error(msg);
            }
        },
        VALID_NUMBER: function(num, msg) {
            if (typeof num !== 'number' || Number.isNaN(num)) {
                throw Error(msg);
            }
        }
    };

    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALID_STRING(x, ERROR_MESSAGES.INVALID_NAME_TYPE)
            VALIDATOR.STRING_IN_RANGE(x, 2, 20, ERROR_MESSAGES.INVALID_NAME_LENGTH);

            if (!/^[A-Za-z ]+$/.test(x)) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }

            this._name = x;
        }

        get manaCost() {
            return this._manaCost;
        }
        set manaCost(x) {
            VALIDATOR.VALID_NUMBER(x, ERROR_MESSAGES.INVALID_MANA);
            if (x <= 0) {
                throw Error(ERROR_MESSAGES.INVALID_MANA);
            }

            this._manaCost = x;
        }

        get effect() {
            return this._effect;
        }
        set effect(x) {
            if (typeof x !== 'function' && x.length !== 1) {
                throw Error(ERROR_MESSAGES.INVALID_EFFECT);
            }

            this._effect = x;
        }

    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALID_STRING(x, ERROR_MESSAGES.INVALID_NAME_TYPE)
            VALIDATOR.STRING_IN_RANGE(x, 2, 20, ERROR_MESSAGES.INVALID_NAME_LENGTH);

            if (!/^[A-Za-z ]+$/.test(x)) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }

            this._name = x;
        }

        get alignment() {
            return this._alignment;
        }
        set alignment(x) {
            if (!(['good', 'neutral', 'evil'].some(y => x === y))) {
                throw Error('Alignment must be good, neutral or evil!');
            }

            this._alignment = x;
        }
    }

    var getID = (function() {
        let id = 0;
        return function() {
            id += 1;
            return id;
        };
    })();

    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);

            this.id = getID();
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get damage() {
            return this._damage;
        }
        set damage(x) {
            VALIDATOR.VALID_NUMBER(x, ERROR_MESSAGES.INVALID_DAMAGE);
            if (x <= 0 || x > 100) {
                throw Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }

            this._damage = x;
        }

        get health() {
            return this._health;
        }
        set health(x) {
            VALIDATOR.VALID_NUMBER(x, ERROR_MESSAGES.INVALID_HEALTH);
            if (x <= 0 || x >= 200) {
                throw Error(ERROR_MESSAGES.INVALID_HEALTH);
            }

            this._health = x;
        }

        get count() {
            return this._count;
        }
        set count(x) {
            VALIDATOR.VALID_NUMBER(x, ERROR_MESSAGES.INVALID_COUNT);
            if (x < 0) {
                throw Error(ERROR_MESSAGES.INVALID_COUNT);
            }

            this._count = x;
        }

        get speed() {
            return this._speed;
        }
        set speed(x) {
            VALIDATOR.VALID_NUMBER(x, ERROR_MESSAGES.INVALID_SPEED);
            if (x <= 0 || x > 100) {
                throw Error(ERROR_MESSAGES.INVALID_SPEED);
            }

            this._speed = x;
        }
    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);

            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana() {
            return this._mana;
        }
        set mana(x) {
            VALIDATOR.VALID_NUMBER(x, ERROR_MESSAGES.INVALID_MANA);
            if (x <= 0) {
                throw Error(ERROR_MESSAGES.INVALID_MANA);
            }
            this._mana = x;
        }
    }


    const battlemanager = (function() {
        var commanders = [];

        function addCommanders(...comm) {
            commanders.push(...comm);

            return this;
        }

        function addArmyUnitTo(commanderName, armyUint) {
            let commander = commanders.find(x => x.name === commanderName);

            commander.army.push(armyUint);

            return this;
        }

        function addSpellsTo(commanderName, ...spells) {
            let commander = commanders.find(x => x.name === commanderName);

            spells.forEach(x => {
                if (typeof x !== 'object' || x === null) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }

                ['name', 'manaCost', 'effect'].forEach(y => {
                    if (x[y] === undefined || x[y] === null) {
                        throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                    }
                });

                VALIDATOR.VALID_STRING(x.name, ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                VALIDATOR.STRING_IN_RANGE(x.name, 2, 20, ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                if (!/^[A-Za-z ]+$/.test(x.name)) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }

                VALIDATOR.VALID_NUMBER(x.manaCost, ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                if (x.manaCost <= 0) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }

                if (typeof x.effect !== 'function' && x.effect.length !== 1) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }

            });

            commander.spellbook.push(...spells);
            return this;
        }

        function findCommanders(query) {
            var props = Object.keys(query);

            return commanders.filter(commander => {
                return props.every(prop => {
                    return query[prop] === commander[prop];
                });
            }).sort();
        }

        function findArmyUnitById(id) {
            for (let commander of commanders) {
                let unit = commander.army.find(x => x.id === id);

                if (unit !== undefined) {
                    return unit;
                }
            }

            return undefined;
        }

        function findArmyUnits(query) {
            var props = Object.keys(query),
                result = [];

            commanders.forEach(commander => {
                result.push(...(commander.army.filter(unit => {
                    return props.every(prop => {
                        return query[prop] === unit[prop];
                    });
                })));
            });

            return result.sort((x, y) => {
                if (x.speed === y.speed) {
                    return x.name.localeCompare(y.name)
                }

                return y.speed - x.speed;
            });
        }

        function spellcast(casterName, spellName, targetUnitId) {
            let commander = commanders.find(x => x.name === casterName);

            if (commander === undefined) {
                throw Error(`Can't cast with non-existant commander ${casterName}!`);
            }

            let spell = commander.spellbook.find(x => x.name === spellName);

            if (spell === undefined) {
                throw Error(`${casterName} doesn't know ${spellName}`);
            }

            let unit = findArmyUnitById(targetUnitId);

            if (unit === undefined) {
                throw Error(ERROR_MESSAGES.TARGET_NOT_FOUND);
            }

            if (commander.mana < spell.manaCost) {
                throw Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
            }

            let effect = spell.effect;

            effect(unit);
            commander.mana -= spell.manaCost;

            return this;
        }

        function battle(attacker, defender) {
            [attacker, defender].forEach(x => {
                if (typeof x !== 'object' || x === null) {
                    throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                }

                ['health', 'damage', 'count'].forEach(y => {
                    if (x[y] === undefined) {
                        throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                    }
                });

                VALIDATOR.VALID_NUMBER(x.damage, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                if (x.damage <= 0 || x.damage > 100) {
                    throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                }

                VALIDATOR.VALID_NUMBER(x.health, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                if (x.health <= 0 || x.health >= 200) {
                    throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                }

                VALIDATOR.VALID_NUMBER(x.count, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                if (x.count < 0) {
                    throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                }
            });

            let totalDamage = attacker.damage * attacker.count;
            let totalHealth = defender.health * defender.count;
            totalHealth -= totalDamage;

            let aftermath = Math.ceil(totalHealth / defender.health);
            aftermath = aftermath < 0 ? 0 : aftermath;

            defender.count = aftermath;

            return this;
        }

        return {
            getCommander: function(name, alignment, mana) {
                return new Commander(name, alignment, mana);
            },

            getArmyUnit: function(options) {

                return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
            },

            getSpell: function(name, manaCost, effect) {
                return new Spell(name, manaCost, effect);
            },

            addCommanders: addCommanders,
            addArmyUnitTo: addArmyUnitTo,
            addSpellsTo: addSpellsTo,
            findCommanders: findCommanders,
            findArmyUnitById: findArmyUnitById,
            findArmyUnits: findArmyUnits,
            spellcast: spellcast,
            battle: battle
        }
    })();

    return battlemanager;
}

module.exports = solve;