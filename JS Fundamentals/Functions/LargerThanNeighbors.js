function solve(args) {
    var array = args[1].split(' ').map(Number);

    console.log(BiggerThanNeighbours(array));

    function BiggerThanNeighbours(array) {
        let count = 0;
        for (let i = 1, length = array.length - 1; i < length; i += 1) {
            if (array[i] > array[i - 1] && array[i] > array[i + 1]) {
                count++;
            }
        }
        return count;
    }
}