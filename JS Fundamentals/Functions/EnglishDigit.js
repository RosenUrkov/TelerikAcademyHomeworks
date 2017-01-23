function solve(args) {
    var numbers = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];

    console.log(GetDigit(+args[0]));

    function GetDigit(number) {
        let digit = number % 10;
        return numbers[digit];
    }
}

//solve(['40']);