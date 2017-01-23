function solve(args) {
    var triangle = [],
        array = args;

    function MakePoint(x, y) {
        return {
            X: +x,
            Y: +y
        }
    }

    function MakeLine(startX, startY, endX, endY) {
        this.start = MakePoint(startX, startY),
            this.end = MakePoint(endX, endY);

        return {
            startPoint: this.start,
            endPoint: this.end,
            lineLength: Math.sqrt((this.end.X - this.start.X) * (this.end.X - this.start.X) +
                (this.end.Y - this.start.Y) * (this.end.Y - this.start.Y)).toFixed(2)
        }
    }

    function IsMore(line1, line2, line3) {
        return (line1 + line2) >= line3;
    }

    for (var i = 0, length = 3; i < length; i += 1) {
        triangle.push(MakeLine(+array[i + i * 3], +array[i + 1 + i * 3], +array[i + 2 + i * 3], +array[i + 3 + i * 3]));
        console.log(triangle[i].lineLength);
    }

    for (i = 0, length = 3; i < length; i += 1) {
        if (!IsMore(triangle[i % 3].lineLength, triangle[(i + 1) % 3].lineLength, triangle[(i + 2) % 3].lineLength)) {
            // console.log('asd');
            return 'Triangle can not be built';
        }
    }
    return 'Triangle can be built';
}


solve([
    '5', '6', '7', '8',
    '1', '2', '3', '4',
    '9', '10', '11', '12'
]);

function Solve(args) {
    //var coordinateValues = args.map(Number);
    firstPoint = MakePoint(+args[0], +args[1]), //(coordinateValues[0], coordinateValues[1]),
        secondPoint = MakePoint(+args[2], +args[3]), //(coordinateValues[2], coordinateValues[3]),
        thirdPoint = MakePoint(+args[4], +args[5]), //(coordinateValues[4], coordinateValues[5]),
        fourhtPoint = MakePoint(+args[6], +args[7]), //(coordinateValues[6], coordinateValues[7]),
        fifthPoint = MakePoint(+args[8], +args[9]), //(coordinateValues[8], coordinateValues[9]),
        sixthPoint = MakePoint(+args[10], +args[11]); //(coordinateValues[10], coordinateValues[11]);


    var firstLine = MakeLine(firstPoint, secondPoint),
        secondLine = MakeLine(thirdPoint, fourhtPoint),
        thirdLine = MakeLine(fifthPoint, sixthPoint);

    CalculateDistance(firstLine);
    CalculateDistance(secondLine);
    CalculateDistance(thirdLine);

    console.log(firstLine.totalLength.toFixed(2));
    console.log(secondLine.totalLength.toFixed(2));
    console.log(thirdLine.totalLength.toFixed(2));

    if (TriangleExists(firstLine, secondLine, thirdLine)) {
        console.log("Triangle can be built");
    } else {
        console.log("Triangle can not be built");
    }

    function MakePoint(x, y) {
        var point = { x: x, y: y };
        return point;
    }

    function MakeLine(firstPoint, secondPoint) {
        var line = { firstPoint: firstPoint, secondPoint: secondPoint };
        return line;
    }

    function CalculateDistance(line) {
        var xDifference = Math.abs(line.firstPoint.x - line.secondPoint.x),
            yDifference = Math.abs(line.firstPoint.y - line.secondPoint.y),
            lineLength = Math.sqrt(xDifference * xDifference + yDifference * yDifference);

        line.totalLength = lineLength;
    }

    function TriangleExists(firstLine, secondLine, thirdLine) {
        var exists = firstLine.totalLength + secondLine.totalLength >= thirdLine.totalLength &&
            firstLine.totalLength + thirdLine.totalLength >= secondLine.totalLength &&
            secondLine.totalLength + thirdLine.totalLength >= firstLine.totalLength;

        return exists;
    }
}