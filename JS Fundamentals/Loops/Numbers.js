function PrintNumbers(args) {
    let number = Math.floor(+args[0]),
        result = "";

    for (let i = 1; i <= number; i += 1) {
        result += i + " ";
    }
    console.log(result.trim());
}