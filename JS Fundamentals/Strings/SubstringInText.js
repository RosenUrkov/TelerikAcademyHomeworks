function solve(args) {
    var target = args[0].toLowerCase(),
        text = args[1].toLowerCase(),
        counter = -1,
        index = 0,
        startIndex = 0;

    while (index !== -1) {
        counter++;
        index = text.indexOf(target, startIndex)
        startIndex = index + target.length;
    }

    console.log(counter);

}