function solve(args) {
    var css = args,
        inSelector = false,
        selectorArr = [],
        selector = '',
        property = '',
        output = '';

    function MakeSelector(selector, content) {
        return {
            Selector: selector,
            Content: content
        }
    }

    for (let i = 0, length = css.length; i < length; i += 1) {
        var line = css[i].trim();
        if (!inSelector) {
            selector = '';
            if (line[line.length - 1] === '{') {
                inSelector = true;
                selector = line.replace(/\s+/g, '');
                selectorArr.push(selector);
                output += selector;
            }
        } else {
            if (line[0] === '}') {
                inSelector = false;
                output = output.substring(0, output.lastIndexOf(';'));
                output += line[0];
            } else {
                property = line.replace(/\s+/g, '');
                output += property;
            }
        }
    }

    console.log(output);
}

solve(['#the-big-b{',
    '  color: yellow;',
    '  size: big;',
    ' }',
    '.muppet{',
    '  powers: all;',
    '  skin: fluffy;',
    '}',
    '     .water-spirit         {',
    '  powers: water;',
    '             alignment    : not-good;',
    '				}',
    'all{',
    '  meant-for: nerdy-children;',
    '}',
    'muppet      {',
    '	powers: everything;',
    '}',
    'all            .muppet {',
    '	alignment             :             good                             ;',
    '}',
    '   .muppet+             .water-spirit{',
    '   power: everything-a-muppet-can-do-and-water;',
    '}'
])