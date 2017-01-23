function solve(args) {
    var people = [],
        human = {},
        smallestAge = 10000;

    for (let i = 0, length = args.length; i < length; i += 3) {
        human = {};
        human.fName = args[i];
        human.lName = args[i + 1];
        human.age = +args[i + 2];
        people.push(human);
    }


    for (let i = 0, length = people.length; i < length; i += 1) {
        if (people[i].age < smallestAge) {
            smallestAge = people[i].age;
            human = people[i];
        }
    }

    console.log(human.fName + ' ' + human.lName);
}

// solve([
//     'Gosho', 'Petrov', '32',
//     'Bay', 'Ivan', '81',
//     'John', 'Doe', '42'
// ]);