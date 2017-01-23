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

    for (let i = 0, length = args.length; i < length; i += 1) {
        if (isFirst) {
            isFirst = false;
            currentNumber = args[i];
        } else {
            if (args[i] != currentNumber) {
                CheckForBetterSequence(currentLength);
                currentNumber = args[i];
                currentLength = 1;
            } else {
                currentLength++;
            }
        }
    }

    CheckForBetterSequence(currentLength);

    console.log(maximalLength);
}

//solve(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);