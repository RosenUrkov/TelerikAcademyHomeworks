function Solve(args) {
    let aCoefficient = +args[0];
    let bCoefficient = +args[1];
    let cCoefficient = +args[2];

    let discriminant = bCoefficient * bCoefficient - 4 * (aCoefficient * cCoefficient);

    if (discriminant > 0) {
        let firstRoot = (-1 * bCoefficient + Math.sqrt(discriminant)) / (2 * aCoefficient);
        let secondRoot = (-1 * bCoefficient - Math.sqrt(discriminant)) / (2 * aCoefficient);
        if (firstRoot < secondRoot) {
            console.log("x1=" + firstRoot.toFixed(2) + "; x2=" + secondRoot.toFixed(2));
        } else {
            console.log("x1=" + secondRoot.toFixed(2) + "; x2=" + firstRoot.toFixed(2));
        }
    } else if (discriminant === 0) {
        let root = -1 * bCoefficient / (2 * aCoefficient);
        console.log("x1=x2=" + root.toFixed(2));
    } else {
        console.log("no real roots");
    }
}