function GetBiggestNumber(args) {
    let firstNumber = +args[0];
    let secondNumber = +args[1];
    let thirdNumber = +args[2];

    let biggest = 0;
    if (firstNumber > secondNumber) {
        if (firstNumber > thirdNumber) {
            biggest = firstNumber;
        } else {
            biggest = thirdNumber;
        }
    } else {
        if (secondNumber > thirdNumber) {
            biggest = secondNumber;
        } else {
            biggest = thirdNumber;
        }
    }

    return biggest;
}