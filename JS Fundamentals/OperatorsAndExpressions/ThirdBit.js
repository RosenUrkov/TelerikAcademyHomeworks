function solve(args) {
    var number = (args >> 3).toString(2);
    //console.log(number);
    //number = number / 100;
    var digit = number % 10;
    console.log(digit);
}

//solve(['15']);