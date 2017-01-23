function MMSA(args) {
    let min = +args[0],
        max = +args[0],
        sum = +args[0],
        average;

    for (let i = 1; i < args.length; i += 1) {
        let currentNumber = +args[i];
        if (min > currentNumber) {
            min = currentNumber;
        }
        if (max < currentNumber) {
            max = currentNumber;
        }
        sum += currentNumber;
    }

    average = sum / args.length;

    console.log(`min=${min.toFixed(2)}`);
    console.log(`max=${max.toFixed(2)}`);
    console.log(`sum=${sum.toFixed(2)}`);
    console.log(`avg=${average.toFixed(2)}`);


}