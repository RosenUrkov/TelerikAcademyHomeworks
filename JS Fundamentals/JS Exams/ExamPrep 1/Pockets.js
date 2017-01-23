function solve(args) {
    var heights = args[0].split(' ').map(Number);

    function GetValley(heights) {
        var pocketSum = 0;

        for (let i = 2, length = heights.length - 2; i < length; i += 1) {
            if (heights[i] < heights[i - 1] && heights[i] < heights[i + 1]) {
                if ((heights[i - 1] > heights[i - 2]) && (heights[i + 1] > heights[i + 2])) {
                    pocketSum += heights[i];
                    i += 1;
                }
            }
        }
        return pocketSum;
    }
    console.log(GetValley(heights));
}

solve([
    "53 20 1 30 2 40 3 10 1"
]);