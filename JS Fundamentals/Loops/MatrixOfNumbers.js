function GenerateMatrix(args) {
    let sizeMatrix = Math.floor(+args[0]);

    for (let i = 0; i < sizeMatrix; i += 1) {
        let currentRow = "";
        let numberToFill = i + 1;
        for (let j = 0; j < sizeMatrix; j += 1) {
            currentRow += `${numberToFill} `;
            numberToFill++;
        }
        console.log(currentRow.trim());
    }

}