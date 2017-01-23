function solve(args) {
    var count = +args[0],
        target = +args[args.length - 1],
        array = args.slice(1, args.length - 1).map(Number),
        startIndex = 0,
        endIndex = array.length - 1,
        resultIndex = -1;


    while (!(startIndex > endIndex)) {
        let index = (endIndex + startIndex / 2) | 0;

        if (array[index] === target) {
            // console.log(FirstOccureance(array, target, index));
            resultIndex = FirstOccureance(array, target, index);
            break;
        } else if (array[index] < target) {
            startIndex = index + 1;
        } else {
            endIndex = index - 1;
        }
    }
    console.log(resultIndex);
    // return -1;

    function FirstOccureance(array, target, index) {
        for (let i = index, length = 0; i >= 0; i -= 1) {
            if (array[i] !== target) {
                return i + 1;
            }
        }
        return 0;
    }

}

solve(['1', '16']);