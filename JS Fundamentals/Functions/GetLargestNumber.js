function solve(args) {
    var numbers = args[0].split(' ').map(Number),
        max = Number.MIN_SAFE_INTEGER;
    for (let i = 0, length = numbers.length; i < length; i += 1) {
        max = GetMax(max, numbers[i])
    }

    console.log(max);

    function GetMax(first, second) {
        return first > second ? first : second;
    }
}

//solve(['7 19 19']);