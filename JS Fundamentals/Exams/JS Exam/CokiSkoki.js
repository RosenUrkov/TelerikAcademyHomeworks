function solve(args) {
    var numbers = args.slice(1).map(Number),
        result = numbers[0],
        bridge = 1024;

    for (let i = (result % 2 === 1 ? 1 : 2), length = numbers.length; i < length; i += 1) {
        if (numbers[i] % 2 == 0) {
            result = (result + numbers[i]) % bridge;
            i += 1;
        } else {
            result = (result * numbers[i]) % bridge;
        }
    }

    console.log(result);
}

solve([
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9'
]);

solve([
    '10',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '0'
]);