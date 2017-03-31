function solve(args) {
    var transformations = +args[0].split(' ')[args.length - 1],
        array = args[1].split(' ').map(Number),
        newArray = [],
        left,
        right,
        sum = 0;

    for (let i = 0, length = transformations; i < length; i += 1) {
        newArray = [];
        for (let j = 0, length = array.length; j < length; j += 1) {

            left = j === 0 ? array[length - 1] : array[j - 1];
            right = j === length - 1 ? array[0] : array[j + 1];

            if (array[j] === 0) {
                newArray[j] = Math.abs(left - right);
            } else if (array[j] === 1) {
                newArray[j] = left + right;
            } else if ((array[j] % 2) === 0) {
                newArray[j] = Math.max(left, right);
            } else {
                newArray[j] = Math.min(left, right);
            }

        }
        array = newArray.slice(0);
    }
    sum = newArray.reduce((x, y) => x + y);
    console.log(sum);
}

solve(['10 3', '1 9 1 9 1 9 1 9 1 9']);