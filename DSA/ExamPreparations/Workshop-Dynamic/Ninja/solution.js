const gets = require('readline-sync').question;
const print = console.log;
const quit = () => {};

const n = +gets();

const rows = [];
for (let i = 0; i < n; i++) {
    rows.push(gets().split(' ').join(''));
}

const getTime = (pervRow, pervCol, currRow, currCol) => {
    pervRow = pervRow - 1;
    pervCol = pervCol - 1;

    currRow = currRow - 1;
    currCol = currCol - 1;

    if (pervRow < 0 || pervCol < 0 || rows[pervRow][pervCol] !== rows[currRow][currCol]) {
        return 1;
    } else {
        return 2;
    }
}

let matrix = [];
matrix.push(new Array(n).fill(Number.MAX_SAFE_INTEGER));
matrix.push(new Array(n).fill(Number.MAX_SAFE_INTEGER));

matrix[0][1] = 0;

for (let row = 1; row <= n; row++) {
    for (let col = 1; col <= n; col++) {
        var up = matrix[(row + 1) % 2][col] + getTime(row - 1, col, row, col);
        var left = matrix[row % 2][col - 1] + getTime(row, col - 1, row, col);

        matrix[row % 2][col] = up < left ? up : left;
    }
}

print(matrix[n % 2][n]);

quit();
