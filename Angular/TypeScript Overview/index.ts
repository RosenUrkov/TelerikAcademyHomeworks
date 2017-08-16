interface IPerson{
    name: string,
    talk: ()=> string,
}

abstract class Person implements IPerson{
    constructor(public readonly name: string, protected readonly age: number) {}

    talk(){
        return `Hello! My name is ${this.name} and im ${this.age} years old! `;
    }
}

class Gosho extends Person implements IPerson{
    constructor(age: number) {
        super("Gosho", age);
    }

    talk(){
        return super.talk() + "Jorkataa!";
    }
}

class Pesho<T, R> extends Person implements IPerson{
    constructor(age: number, private readonly something: (T | R)){
        super("Pesho", age)
    }

    talk(){
        return super.talk() + "Peshakaa!";
    }
}

const persons: IPerson[] = [];
persons.push(new Gosho(20));
persons.push(new Pesho<string, number>(21, "generic"));

persons.forEach(x => console.log(x.talk()));