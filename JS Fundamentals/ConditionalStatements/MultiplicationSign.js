function GetMultiplicationSign(args) {

    let arr = [];
    arr = args;

    let numberOfMinuses = 0;
    let zerosCount = 0;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === "0") {
            zerosCount++;
        }
        if (arr[i][0] === '-') {
            numberOfMinuses += 1;
        }
    }

    if (zerosCount > 0) {
        return "0";
    }

    if (numberOfMinuses === 1) {
        return "-";
    } else if (numberOfMinuses === 3) {
        return "-";
    } else if (numberOfMinuses === 2) {
        return "+";
    } else {
        return "+";
    }

}