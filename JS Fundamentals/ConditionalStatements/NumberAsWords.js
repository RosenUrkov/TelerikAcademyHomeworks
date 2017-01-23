function GetNumberAsWords(args) {
    let number = Math.floor(+args[0]),
        ones = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'],
        uniques = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'],
        tens = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'],
        result = "";

    if (number < 10) {
        result = ones[number];
    } else if (number >= 10 && number < 20) {
        result = uniques[number - 10];
    } else if (number >= 20 && number < 100) {
        let numberOnes = Math.floor(number % 10);
        number /= 10;
        let numberTens = Math.floor(number % 10);
        result = tens[numberTens - 2];
        if (numberOnes !== 0) {
            result += " " + ones[numberOnes];
        }

    } else {
        let numberOnes = Math.floor(number % 10);
        console.log(numberOnes);
        number /= 10;
        let numberTens = Math.floor(number % 10);
        console.log(numberTens);
        number /= 10;
        let numberHundreds = Math.floor(number % 10);
        console.log(numberHundreds);
        result = ones[numberHundreds] + ' hundred';

        let lastTwoDigits = +args[0].substring(1);
        console.log(lastTwoDigits);
        if (lastTwoDigits === 0) {
            return result[0].toUpperCase() + result.substring(1);
        }
        result += " and";
        if (lastTwoDigits >= 10 && lastTwoDigits < 20) {
            result += ` ${uniques[lastTwoDigits-10]}`;
        } else {

            if (numberTens !== 0) {
                result += ` ${tens[numberTens-2]}`;
            }
            if (numberOnes !== 0) {
                result += ` ${ones[numberOnes]}`;
            }

        }
    }

    result = result[0].toUpperCase() + result.substring(1);
    return result;

}

// let input = ['900'];
// console.log(GetNumberAsWords(input));