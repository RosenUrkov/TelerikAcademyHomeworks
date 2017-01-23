function solve(args) {
    var x = +args[0],
        y = +args[1],
        inCircle = false,
        inRectangle = false;

    if (x <= 5 && x >= -1 && y >= -1 && y <= 1) {
        inRectangle = true;
    }

    x -= 1;
    y -= 1;
    point = x * x + y * y;
    if (point <= 1.5 * 1.5) {
        inCircle = true;
    }

    var result;
    if (inCircle) {
        result = 'inside circle ';
    } else {
        result = 'outside circle ';
    }
    if (inRectangle) {
        result += 'inside rectangle';
    } else {
        result += 'outside rectangle';
    }
    console.log(result);

}

//solve(['2.5', '1']);