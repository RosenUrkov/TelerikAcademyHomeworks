function solve(args) {
    var target = +args[0],
        array = [].slice.apply(args).slice(1).map(Number),
        condition = false,
        result = [];
    array.sort();

    HasSum(array.length - 1, target);
    console.log(result);

    function HasSum(lastIndex, value) {
        if (value === 0) {
            return true;
        }
        if (lastIndex < 0) {
            result = [];
            return false;
        }

        for (let i = lastIndex; i >= 0; i -= 1) {
            if (array[i] > value) {
                continue;
            }
            result.unshift(array[i]);
            condition = HasSum(i - 1, value - array[i]);
            if (condition === false) {
                result.shift();
                continue;
            } else {
                break;
            }
        }
        return condition;
    }
}

solve(['21', '3', '4', '9', '5']);