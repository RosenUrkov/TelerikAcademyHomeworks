function solve(args) {
    var firstHalf = args.substr(0, (args.length / 2 | 0)),
        secondHalf = args.substring(((args.length / 2 + 0.5) | 0), args.length),
        isPalindrome = true;

    if (firstHalf.length !== secondHalf.length) {
        isPalindrome = false;
        console.log(isPalindrome);
        return;
    }

    firstHalf = firstHalf.split('').reverse().join('');

    for (let i = 0, length = firstHalf.length; i < length; i += 1) {
        if (firstHalf[i] !== secondHalf[i]) {
            isPalindrome = false;
            console.log(isPalindrome);
            return;
        }
    }
    console.log(isPalindrome);
    return;
}
solve('abbbdfsa');