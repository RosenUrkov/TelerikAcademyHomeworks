function solve(args) {
    var equation = args[0],
        brackets = [],
        result = 'Correct';

    for (let i = 0, length = equation.length; i < length; i += 1) {
        if (equation[i] === '(') {
            brackets.push(equation[i]);
        } else if (equation[i] === ')') {
            if (brackets.length === 0) {
                result = 'Incorrect';
                break;
            }
            brackets.pop();
        }
    }

    if (result === 'Correct') {
        if (brackets.length !== 0) {
            result = 'Incorrect';
        }
    }

    console.log(result);
}