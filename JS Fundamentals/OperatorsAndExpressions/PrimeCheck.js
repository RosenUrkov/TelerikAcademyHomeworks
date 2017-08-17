function solve(args) {
    var isPrime = true,
        number = +args[0];

    if (number < 2) {
        isPrime = false;
    } else {
        for (var i = 2; i <= Math.sqrt(number); i++) {
            if (number % i === 0) {
                isPrime = false;
            }
        }
    }

    console.log(isPrime);

}
solve(['1000000007']);
