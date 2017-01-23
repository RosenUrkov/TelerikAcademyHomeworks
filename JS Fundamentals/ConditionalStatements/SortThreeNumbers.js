function SortThreeNumbers(args) {
    let firstNumber = +args[0];
    let secondNumber = +args[1];
    let thirdNumber = +args[2];

    let maxNumber = firstNumber;
    let minNumber = secondNumber;
    let middleNumber = thirdNumber;

    if (firstNumber > secondNumber) {
        if (firstNumber > thirdNumber) {
            maxNumber = firstNumber;

            if (secondNumber > thirdNumber) {
                middleNumber = secondNumber;
                minNumber = thirdNumber;
            } else {
                middleNumber = thirdNumber;
                minNumber = secondNumber;
            }
        } else {
            maxNumber = thirdNumber;
            middleNumber = firstNumber;
            minNumber = secondNumber;
        }
    } else {
        if (secondNumber > thirdNumber) {
            maxNumber = secondNumber;
            if (firstNumber > thirdNumber) {
                middleNumber = firstNumber;
                minNumber = thirdNumber;
            } else {
                middleNumber = thirdNumber;
                minNumber = firstNumber;
            }
        } else {
            maxNumber = thirdNumber;
            middleNumber = secondNumber;
            minNumber = firstNumber;
        }
    }

    return maxNumber + " " + middleNumber + " " + minNumber;
}