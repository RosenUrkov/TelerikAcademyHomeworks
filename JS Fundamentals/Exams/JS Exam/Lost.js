function solve(args) {
    var rowsAndCols = args[0].split(' ').map(Number),
        rows = rowsAndCols[0],
        cols = rowsAndCols[1],
        mazeNumbers = args.slice(1),
        position = MakePosition(((rows / 2) | 0), ((cols / 2) | 0)),
        maze = [],
        boolMatrix = [];

    //fill matrix
    for (let i = 0, length = rows; i < length; i += 1) {
        maze.push([]);
        boolMatrix.push([]);
        let colNumbers = mazeNumbers[i].split(' ').map(Number);

        for (let j = 0, length = cols; j < length; j += 1) {
            //maze[i].push([]);
            maze[i][j] = colNumbers[j];
            //boolMatrix[i].push([]);
            boolMatrix[i][j] = false;
        }
    }

    while (true) {
        var step = 0;
        boolMatrix[position.Row][position.Col] = true;
        let number = maze[position.Row][position.Col];
        if ((number & 1) === 1) {
            step = -1;
            if (!HandleUp()) {
                //careful here
                console.log(`No rakiya, only JavaScript ${position.Row} ${position.Col}`);
                return;
            }
            if (!boolMatrix[position.Row + step][position.Col]) {
                position.Row += step;
                continue;
            }
        }

        if ((number & 2) === 2) {
            step = 1;
            if (!HandleRight()) {
                //careful here
                console.log(`No rakiya, only JavaScript ${position.Row} ${position.Col}`);
                return;
            }
            if (!boolMatrix[position.Row][position.Col + step]) {
                position.Col += step;
                continue;
            }
        }

        if ((number & 4) === 4) {
            step = 1;
            if (!HandleDown()) {
                //careful here
                console.log(`No rakiya, only JavaScript ${position.Row} ${position.Col}`);
                return;
            }
            if (!boolMatrix[position.Row + step][position.Col]) {
                position.Row += step;
                continue;
            }
        }

        if ((number & 8) === 8) {
            step = -1;
            if (!HandleLeft()) {
                //careful here
                console.log(`No rakiya, only JavaScript ${position.Row} ${position.Col}`);
                return;
            }
            if (!boolMatrix[position.Row][position.Col + step]) {
                position.Col += step;
                continue;
            }
        }

        console.log(`No JavaScript, only rakiya ${position.Row} ${position.Col}`);
        return;
    }

    function HandleUp() {
        if (position.Row !== 0) {
            return true;
        }
        return false;
    }

    function HandleRight() {
        if (position.Col !== cols - 1) {
            return true;
        }
        return false;
    }

    function HandleDown() {
        if (position.Row !== rows - 1) {
            return true;
        }
        return false;
    }

    function HandleLeft() {
        if (position.Col !== 0) {
            return true;
        }
        return false;
    }

    function MakePosition(row, col) {
        return {
            Row: row,
            Col: col
        }
    }
}

solve([
    '5 7',
    '9 5 3 11 9 5 3',
    '10 11 10 12 4 3 10',
    '10 10 12 7 13 6 10',
    '12 4 3 9 5 5 2',
    '13 5 4 6 13 5 6'
]);