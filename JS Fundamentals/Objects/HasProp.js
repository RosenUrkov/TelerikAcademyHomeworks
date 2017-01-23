function solve(args) {
    var obj1 = { name: 'dsad', age: 14, isMale: true };
    console.log(HasProperty(obj1, args));

    function HasProperty(obj, prop) {
        if (typeof obj[prop] === 'undefined') {
            return false;
        }
        return true;

    }
}

solve('age');