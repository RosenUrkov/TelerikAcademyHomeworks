function solve(args) {
    var x = Math.abs(args[0]),
        y = Math.abs(args[1]);
    var psn = x * x + y * y;
    if (psn > 4) {
        console.log('no ' + Math.sqrt(psn).toFixed(2));
    } else {
        console.log('yes ' + Math.sqrt(psn).toFixed(2));
    }
}