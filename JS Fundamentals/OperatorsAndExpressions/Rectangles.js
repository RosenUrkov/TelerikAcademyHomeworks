function solve(args) {
    var a = +args[0],
        b = +args[1],
        area = a * b,
        perimeter = 2 * a + 2 * b;

    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}