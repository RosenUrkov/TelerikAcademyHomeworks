const gets = require('readline-sync').question;
const print = console.log;
const quit = () => {}

const results = [];
results[0] = +gets();
results[1] = +gets();
results[2] = +gets();
results[3] = +gets();

const rows = +gets();
const cols = +gets();

for (let i = 4; i < rows * cols; i++) {
    results[i] = results[i - 4] + results[i - 3] + results[i - 2] + results[i - 1];
}

for (let row = 0; row < rows; row++) {
    let currentRow = results.slice(row * cols, row * cols + cols);
    print(currentRow.join(' '));
}

quit();
