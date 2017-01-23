function solve(args) {
    var result = '';

    for (var i = 0, length = args.length; i < length; i += 1) {
        args[i] = args[i].trim();
        var openTag = args[i].indexOf('<', 0),
            closeTag = args[i].indexOf('>', 0);

        if (openTag === -1) {
            result += args[i].trim();
        } else if ((openTag === 0) && (args[i].indexOf('<', closeTag + 1) !== -1)) {
            result += args[i].substring(closeTag + 1, args[i].indexOf('<', closeTag + 1)).trim();
        } else if (openTag === 0) {
            if (closeTag === (args[i].length - 1)) {
                continue;
            }
            result += args[i].substring(closeTag + 1).trim();
        } else if (openTag > 0) {
            result += args[i].substring(0, openTag).trim();
        }

    }
    console.log(result);

}
// solve([
//     '<html>',
//     '  <head>',
//     '    <title>Sample site</title>',
//     '  </head>',
//     '  <body>',
//     '    <div>text',
//     '      <div>more text</div>',
//     '      and more...',
//     '    </div>',
//     '    in body',
//     '  </body>',
//     '</html>'
// ]);