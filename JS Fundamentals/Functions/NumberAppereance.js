function solve(args) {
    var count = +args[0],
        array = args[1].split(' ').map(Number),
        target = +args[2];

    console.log(GetAppereance(target, array));

    function GetAppereance(target, array) {
        let count = 0;
        for (let i = 0, length = array.length; i < length; i += 1) {
            if (array[i] === target) {
                count++;
            }
        }
        return count;
    }
}

//solve([])