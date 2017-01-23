function solve(args) {
    var currentLength = 1,
        maximalLength = 1,
        currentNumber = 0,
        isFirst = true;

    function CheckForBetterSequence(currSequence) {
        if (currSequence > maximalLength) {
            maximalLength = currSequence;
        }
    }

    for (let i = 1, length = +args[0]; i < length; i += 1) {
        if (isFirst) {
            isFirst = false;
            currentNumber = +args[i];
        } else {
            if (+args[i] <= currentNumber) {
                CheckForBetterSequence(currentLength);
                currentNumber = +args[i];
                currentLength = 1;
            } else {
                currentLength++;
                currentNumber = +args[i];
            }
        }
    }

    CheckForBetterSequence(currentLength);

    console.log(maximalLength);
}

//solve(['8', '0', '1', '2', '5', '6', '7', '8', '1']);