function solve(args) {
    var prime,
        number = +args;

    for (let i = number; i >= 2; i -= 1) {
        prime = true;
        for (let j = 2, length = Math.sqrt(i); j <= length; j += 1) {
            if (i % j === 0) {
                prime = false;
                break;
            }
        }
        if (prime) {
            //console.log(i);
            return i;
        }
    }
}

//solve('27');