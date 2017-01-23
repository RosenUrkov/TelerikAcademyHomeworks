function solve(args) {
    var str = args[0];

    function Reverse(str) {
        var result = '';
        for (var i = str.length - 1; i >= 0; i -= 1) {
            result = result + str[i];
        }
        return result;
    };

    console.log(Reverse(str));
}

//solve(['asd123saf'])