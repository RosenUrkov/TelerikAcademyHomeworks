function ExchangeIfGreater(args) {
    let firstNumber = +args[0];
    let secondNumber = +args[1];

    if (firstNumber > secondNumber) {
        let temp = firstNumber;
        firstNumber = secondNumber;
        secondNumber = temp;
    }

    let output = firstNumber + " " + secondNumber;
    return output;
}