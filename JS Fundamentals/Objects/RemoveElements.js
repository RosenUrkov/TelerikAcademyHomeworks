function solve(args) {
    var arr = args.slice(1, args.length);

    Array.prototype.remove = function(element) {
        var array = [];
        for (var i = 0, length = this.length; i < length; i += 1) {
            if (this[i] !== element) {
                array.push(this[i]);
            }
        }
        return array;
    }

    console.log(arr.remove(args[0]).join('\n'));
}

//solve(['1', '2', '3', '2', '1', '2', '3', '2']);