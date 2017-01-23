function solve(args) {
    function stringFormat(formatString, ...params) {
        for (let i = 0, length = params.length; i < length; i += 1) {
            while (formatString.indexOf(`{${i}}`) !== -1) {
                formatString = formatString.replace(`{${i}}`, params[i]);
            }
        }
        return formatString;
    }

    var frmt = '{0}, {1}, {0} text {2}';
    var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
    console.log(str);
}
solve();