function solve(args) {
    var temp;
    for (let i = 1, length = args[0]; i <= length; i += 1) {
        for (let j = i + 1; j <= length; j += 1) {
            if (+args[i] > +args[j]) {
                temp = args[i];
                args[i] = args[j];
                args[j] = temp;
            }
        }
        console.log(args[i]);
    }
}