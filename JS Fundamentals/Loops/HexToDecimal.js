function HexToDecimal(args) {
    let hexvalue = args[0],
        currentBase = 16,
        decimalValue = Math.floor(0),
        charCodeZero = "0".charCodeAt(),
        charCodeNine = "9".charCodeAt(),
        charCodeA = "A".charCodeAt(),
        charCodeZ = "Z".charAt();

    for (let i = 0; i < hexvalue.length; i += 1) {
        let currentDigit = hexvalue[i];
        let charCodeDigit = currentDigit.charCodeAt();

        if (charCodeDigit >= charCodeZero && charCodeDigit <= charCodeNine) {
            decimalValue = decimalValue * currentBase + (charCodeDigit - charCodeZero);
        } else {
            decimalValue = decimalValue * currentBase + (charCodeDigit - charCodeA + 10);
        }
    }

    return decimalValue;
}