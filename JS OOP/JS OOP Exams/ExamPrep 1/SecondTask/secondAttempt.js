function solve() {
    'use strict';

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
        VALIDATE_STRING(str, msg) {
            if (typeof str !== 'string') {
                throw Error(msg);
            }
        },
        VALIDATE_STRING_RANGE(str, min, max, msg) {
            if (str.length < min || str.length > max) {
                throw Error(msg);
            }
        },
        VALIDATE_NUMBER(num, msg) {
            if (typeof num !== 'number' || Number.isNaN(num)) {
                throw Error(msg);
            }
        },
        VALIDATE_NUMBER_RANGE(num, min, max, msg) {
            if (num < min || num > max) {
                throw Error(msg);
            }
        },
    }

    let getID = (function() {
        let counter = 0;

        return function() {
            return ++counter;
        }
    })();

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
            VALIDATOR.VALIDATE_STRING(x, ERROR_MESSAGES.INVALID_NAME_TYPE);
            VALIDATOR.VALIDATE_STRING_RANGE(x, 2, 20, ERROR_MESSAGES.INVALID_NAME_LENGTH);
            if (!(/^[A-Za-z ]+$/.test(x))) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }

            this._name = x;
        }

        get manaCost() {
            return this._manaCost;
        }
        set manaCost(x) {
            VALIDATOR.VALIDATE_NUMBER(x, ERROR_MESSAGES.INVALID_MANA);
            if (x <= 0) {
                throw Error(ERROR_MESSAGES.INVALID_MANA);
            }

            this._manaCost = x;
        }

        get effect() {
            return this._effect;
        }
        set effect(x) {
            if (typeof x !== 'function' || x.length !== 1) {
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
            VALIDATOR.VALIDATE_STRING(x, ERROR_MESSAGES.INVALID_NAME_TYPE);
            VALIDATOR.VALIDATE_STRING_RANGE(x, 2, 20, ERROR_MESSAGES.INVALID_NAME_LENGTH);
            if (!(/^[A-Za-z ]+$/.test(x))) {
                throw Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }

            this._name = x;
        }

        get alignment() {
            return this._alignment;
        }
        set alignment(x) {
            if (!['good', 'neutral', 'evil'].some(y => y === x)) {
                throw Error("Alignment must be good, neutral or evil!");
            }

            this._alignment = x;
        }
    }

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
            VALIDATOR.VALIDATE_NUMBER(x, ERROR_MESSAGES.INVALID_DAMAGE);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 1, 100, ERROR_MESSAGES.INVALID_DAMAGE);

            this._damage = x;
        }

        get health() {
            return this._health;
        }
        set health(x) {
            VALIDATOR.VALIDATE_NUMBER(x, ERROR_MESSAGES.INVALID_HEALTH);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 1, 200, ERROR_MESSAGES.INVALID_HEALTH);

            this._health = x;
        }

        get count() {
            return this._count;
        }
        set count(x) {
            VALIDATOR.VALIDATE_NUMBER(x, ERROR_MESSAGES.INVALID_COUNT);
            if (x < 0) {
                throw Error(ERROR_MESSAGES.INVALID_COUNT);
            }

            this._count = x;
        }

        get speed() {
            return this._speed;
        }
        set speed(x) {
            VALIDATOR.VALIDATE_NUMBER(x, ERROR_MESSAGES.INVALID_SPEED);
            VALIDATOR.VALIDATE_NUMBER_RANGE(x, 1, 100, ERROR_MESSAGES.INVALID_SPEED);

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
            VALIDATOR.VALIDATE_NUMBER(x, ERROR_MESSAGES.INVALID_MANA);
            if (x < 0) {
                throw Error(ERROR_MESSAGES.INVALID_MANA);
            }

            this._mana = x;
        }
    }

    const battlemanager = (function() {
        let commanders = [];

        function getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana);
        }

        function getArmyUnit(options) {
            const { name, alignment, speed, count, damage, health } = options;

            return new ArmyUnit(name, alignment, damage, health, count, speed);
        }

        function getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        }

        function addCommanders(...args) {
            commanders.push(...args);

            return this;
        }

        function addArmyUnitTo(commanderName, armyUnit) {
            let commander = commanders.find(x => x.name === commanderName);

            commander.army.push(armyUnit);

            return this;
        }

        function addSpellsTo(commanderName, ...spells) {
            let commander = commanders.find(x => x.name === commanderName);

            spells.forEach(x => {
                ['name', 'manaCost', 'effect'].forEach(y => {
                    if (x[y] === undefined) {
                        throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                    }
                })

                VALIDATOR.VALIDATE_STRING(x.name, ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                VALIDATOR.VALIDATE_STRING_RANGE(x.name, 2, 20, ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                if (!(/^[A-Za-z ]+$/.test(x.name))) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }

                VALIDATOR.VALIDATE_NUMBER(x.manaCost, ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                if (x.manaCost <= 0) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }


                if (typeof x.effect !== 'function' || x.effect.length !== 1) {
                    throw Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }
            });

            commander.spellbook.push(...spells);

            return this;
        }

        function findCommanders(query) {

            return commanders.filter(x => {
                    return Object.keys(query)
                        .every(y => query[y] === x[y])
                })
                .sort((x, y) => x.name.localeCompare(y.name));
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
            let result = [];

            commanders.forEach(commander => {
                result.push(...(commander.army.filter(unit => {
                    return Object.keys(query).every(prop => {
                        return query[prop] === unit[prop];
                    });
                })));
            });

            return result.sort((x, y) => {
                let res = y.speed - x.speed;

                if (res === 0) {
                    return x.name.localeCompare(y.name);
                }

                return res;
            });
        }

        function spellcast(casterName, spellName, targetUnitId) {
            let commander = commanders.find(x => x.name === casterName);

            if (commander === undefined) {
                throw Error(`Can't cast with non-existant commander ${casterName}!`)
            }

            let spell = commander.spellbook.find(x => x.name === spellName);

            if (spell === undefined) {
                throw Error(`${casterName} doesn't know ${spellName}`)
            }

            if (spell.manaCost > commander.mana) {
                throw Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
            }

            let unit = findArmyUnitById(targetUnitId);

            if (unit === undefined) {
                throw Error(ERROR_MESSAGES.TARGET_NOT_FOUND);
            }

            spell.effect(unit);

            commander.mana -= spell.manaCost;

            return this;
        }

        function battle(attacker, defender) {
            [attacker, defender].forEach(x => {

                ['health', 'damage', 'count'].forEach(y => {
                    if (x[y] === undefined) {
                        throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                    }
                });

                VALIDATOR.VALIDATE_NUMBER(x.damage, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                VALIDATOR.VALIDATE_NUMBER_RANGE(x.damage, 1, 100, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);

                VALIDATOR.VALIDATE_NUMBER(x.health, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                VALIDATOR.VALIDATE_NUMBER_RANGE(x.health, 1, 200, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);

                VALIDATOR.VALIDATE_NUMBER(x.count, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                if (x.count < 0) {
                    throw Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                }
            });

            let totalDamage = attacker.damage * attacker.count;
            let totalHealth = defender.health * defender.count;
            totalHealth -= totalDamage;

            let result = Math.ceil(totalHealth / defender.health);
            result = result < 0 ? 0 : result;

            defender.count = result;

            return this;
        }


        return {
            commanders,
            getCommander,
            getArmyUnit,
            getSpell,
            addCommanders,
            addArmyUnitTo,
            addSpellsTo,
            findCommanders,
            findArmyUnitById,
            findArmyUnits,
            spellcast,
            battle
        }
    })();

    return battlemanager;
}

module.exports = solve;