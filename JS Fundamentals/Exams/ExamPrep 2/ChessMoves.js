function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        board = [],
        move;

    function MakePosition(row, col) {
        return {
            Row: row,
            Col: col
        }
    }

    //fill board
    for (let i = 0, length = rows; i < length; i += 1) {
        board.push([]);
        for (let j = 0, length = cols; j < length; j += 1) {
            board[i][j] = params[i + 2][j];
        }
    }

    for (let i = 0; i < tests; i++) {

        move = params[rows + 3 + i].split(' ');
        let initialPosition = move[0];
        let futurePosition = move[1];

        let decodedMove = DecodePosition(initialPosition).split(' ').map(Number);
        let figurePosition = MakePosition(decodedMove[1], decodedMove[0]);
        let figure = board[figurePosition.Row][figurePosition.Col];

        decodedMove = DecodePosition(futurePosition).split(' ').map(Number);
        futurePosition = MakePosition(decodedMove[1], decodedMove[0]);

        console.log(HandleFigure(figure, figurePosition, futurePosition));
    }

    function DecodePosition(position) {
        var decoded = position[0].charCodeAt() - 'a'.charCodeAt();
        decoded = decoded + ' ' + (rows - (+position[1]));
        return decoded;
    }

    function CheckSafePosition(position) {
        if (position !== '-') {
            return false;
        }
        return true;
    }

    function HandleFigure(figure, figurePosition, futurePosition) {
        switch (figure) {
            case 'R':
                return HandleRook(figurePosition, futurePosition);
            case 'Q':
                return HandleQueen(figurePosition, futurePosition);
            case 'B':
                return HandleBishop(figurePosition, futurePosition);
            default:
                return 'no';
        }

        function HandleRook(position, futurePosition) {
            if (((position.Row !== futurePosition.Row) && (position.Col !== futurePosition.Col)) ||
                (position.Row === futurePosition.Row) && (position.Col === futurePosition.Col)) {
                return 'no';
            }

            let stepRow = 0;
            let stepCol = 0;

            if (position.Col === futurePosition.Col) {
                stepRow = position.Row > futurePosition.Row ? -1 : 1;
            } else {
                stepCol = position.Col > futurePosition.Col ? -1 : 1;
            }

            while ((position.Row !== futurePosition.Row) || (position.Col !== futurePosition.Col)) {
                position.Row += stepRow;
                position.Col += stepCol;
                if (!CheckSafePosition(board[position.Row][position.Col])) {
                    return 'no';
                }
            }
            return 'yes';
        }

        function HandleBishop(position, futurePosition) {
            if ((futurePosition.Row === position.Row) || (futurePosition.Col === position.Col)) {
                return 'no';
            }

            let stepRow = 0;
            let stepCol = 0;

            if (futurePosition.Row > position.Row) {
                stepRow = 1;
            } else {
                stepRow = -1;
            }

            if (futurePosition.Col > position.Col) {
                stepCol = 1;
            } else {
                stepCol = -1;
            }


            while (position.Row !== futurePosition.Row && position.Col !== futurePosition.Col) {
                position.Row += stepRow;
                position.Col += stepCol;
                if (!CheckSafePosition(board[position.Row][position.Col])) {
                    return 'no';
                }
            }
            return 'yes';
        }

        function HandleQueen(position, futurePosition) {
            var pos = MakePosition(position.Row, position.Col);
            var futPos = MakePosition(futurePosition.Row, futurePosition.Col);
            if (HandleRook(pos, futPos) === 'yes' || HandleBishop(position, futurePosition) === 'yes') {
                return 'yes';
            }
            return 'no';
        }
    }
}

solve(['3', '4',
    '--R-',
    'B--B',
    'Q--Q',
    '1',
    'd1 d3'
]);