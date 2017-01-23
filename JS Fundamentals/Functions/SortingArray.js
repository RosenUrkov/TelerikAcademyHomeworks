function solve(args) {
    var array = args[1].split(' ').map(Number);

    console.log(Sort(array).reverse().join(' '));

    function GetMax(array) {
        let maxElement = Number.MIN_SAFE_INTEGER;
        for (let i = 0, length = array.length; i < length; i += 1) {
            maxElement = maxElement > array[i] ? maxElement : array[i];
        }
        return maxElement;
    }

    function Sort(array) {
        for (let i = 0, length = array.length; i < length; i += 1) {
            let len = array.length - i;
            array.push(GetMax(array.slice(0, len)));
            array.splice(array.indexOf(array[array.length - 1]), 1);
        }

        return array;
    }
}

//solve(['6', '9 19 59 89 3 1 3 9 2 -12 -11 6 8 9']);