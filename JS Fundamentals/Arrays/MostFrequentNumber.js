function solve(args) {
    var dictionary = {},
        array = args.slice(1),
        maxValue = 0,
        output;

    for (let i = 0, length = +args[0]; i < length; i += 1) {
        if (!Contains(dictionary, array[i])) {
            dictionary[array[i]] = 1;
        } else {
            dictionary[array[i]] += 1;
        }
    }

    for (let key in dictionary) {
        if (+dictionary[key] > maxValue) {
            maxValue = +dictionary[key];
        }
    }

    output = IndexOf(dictionary, maxValue);
    output += ` (${dictionary[output]} times)`;
    console.log(output);


    function Contains(dict, value) {
        for (let key in dict) {
            if (key === value) {
                return true;
            }
        }
        return false;
    }

    function IndexOf(dict, value) {
        for (let key in dict) {
            if (+dict[key] === +value) {
                return key;
            }
        }
        return -1;
    }
}

solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);