function solve(args) {
    var humans = [];
    humans.push(MakePerson('Ivan', 'Petrov', 15, false));
    humans.push(MakePerson('Kremena', 'Petkova', 18, true));
    humans.push(MakePerson('Undefined', 'NotEven', null, true));
    humans.push(MakePerson('Petko', 'Ivanov', 40, false));
    humans.push(MakePerson('Petrana', 'Koparanova', 10, false))

    function MakePerson(fName, lName, age, gender) {
        return {
            FirstName: fName,
            LastName: lName,
            Age: age,
            Gender: gender
        }
    }

    //humans.filter(x => x.Age < 18).forEach(x => console.log(x));
    let average = humans.filter(x => x.Gender === true).reduce((x, y) => x + y.Age, 0) / humans.length;
    let youngest = humans.filter(x => x.Gender === false).sort(x => x.Age).find(x => x.Age > 0);
    let groups = humans.sort(x => x.FirstName).filter((x, y) => x.FirstName[0])
    let grouped = humans.reduce(function(x, p) {
        if (x[p.FirstName[0]]) {
            x[p.FirstName[0]].push(p);
        } else {
            x[p.FirstName[0]] = [p];
        }

        return x;
    });

    console.log(grouped);

}

solve();