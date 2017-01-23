function solve(args) {
    var target = +args[0],
        array = [].slice.apply(args).slice(1).map(Number),
        condition = false;
    array.sort();

    console.log(HasSum(array.length - 1, target));

    function HasSum(lastIndex, value) {
        if (value === 0) {
            return true;
        }
        if (lastIndex < 0) {
            return false;
        }

        for (let i = lastIndex; i >= 0; i -= 1) {
            if (array[i] > value) {
                continue;
            }
            condition = HasSum(i - 1, value - array[i]);
            if (condition === false) {
                continue;
            } else {
                break;
            }
        }
        return condition;
    }
}

solve(['7', '3', '4', '9', '5']);