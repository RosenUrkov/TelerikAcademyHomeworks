function GetBiggestOfFive(args) {
    //let numbers = [];
    numbers = args;
    let maxNumber = +numbers[0];
    for (let i = 1; i < numbers.length; i += 1) {
        let currentNumber = +numbers[i];
        //console.log(typeof(currentNumber));
        if (currentNumber > maxNumber) {
            maxNumber = currentNumber;
        }
    }

    console.log(maxNumber);
}