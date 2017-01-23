function solve(args) {
    var number = args;
    number = (number / 100) | 0;
    var digit = number % 10;
    if (digit === 7) {
        console.log('true');
    } else {
        console.log('false ' + digit);
    }
}

//solve(['777']);