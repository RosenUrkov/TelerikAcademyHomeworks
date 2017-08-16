var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Person = (function () {
    function Person(name, age) {
        this.name = name;
        this.age = age;
    }
    Person.prototype.talk = function () {
        return "Hello! My name is " + this.name + " and im " + this.age + " years old! ";
    };
    return Person;
}());
var Gosho = (function (_super) {
    __extends(Gosho, _super);
    function Gosho(age) {
        return _super.call(this, "Gosho", age) || this;
    }
    Gosho.prototype.talk = function () {
        return _super.prototype.talk.call(this) + "Jorkataa!";
    };
    return Gosho;
}(Person));
var Pesho = (function (_super) {
    __extends(Pesho, _super);
    function Pesho(age, something) {
        var _this = _super.call(this, "Pesho", age) || this;
        _this.something = something;
        return _this;
    }
    Pesho.prototype.talk = function () {
        return _super.prototype.talk.call(this) + "Peshakaa!";
    };
    return Pesho;
}(Person));
var persons = [];
persons.push(new Gosho(20));
persons.push(new Pesho(21, "generic"));
persons.forEach(function (x) { return console.log(x.talk()); });
