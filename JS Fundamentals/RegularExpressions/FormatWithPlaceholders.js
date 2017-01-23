function solve(args) {
    var obj = JSON.parse(args[0]),
        temp = args[1];

    String.prototype.stringFormat = function(params) {
        var arr = this;
        for (var prop in params) {
            var regex = new RegExp('#{' + prop + '}', 'g');
            arr = arr.replace(regex, params[prop]);
        }
        return arr;
    }

    console.log(temp.stringFormat(obj));
}

// solve([
//     '{ "name": "John", "age": 13 }',
//     "My name is #{name} and I am #{age}-years-old"
// ]);