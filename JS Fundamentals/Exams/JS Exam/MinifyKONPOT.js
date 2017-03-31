function solve(args) {
    var text = args.join(''),
        copy = text,
        str = '',
        counter = 0,
        subText = '',
        replacement,
        regex = /\w+/g,
        openBracketsCount = 0,
        closeBracketsCount = 0,
        stuffToRemove = 0,
        multiplier = 1;

    //cleaning
    text = text.replace(/\s+/g, '').replace(/;+/g, ';').replace(/;?{;?/g, '{').replace(/;?};?/g, '}')
        .replace(/{}/g, '');
    if (text[0] === ';') {
        text = text.replace(';', '');
    }
    // if (text[text.length - 1] === ';') {
    //     text = text.substring(0, text.length - 1);
    // }

    copy = text;
    str = regex.exec(copy);

    //compressing identifiers
    while (str !== null) {

        if (counter >= 64 * multiplier) {
            multiplier += 1;
        }
        replacement = GetMoreStuff(multiplier);
        counter += 1;

        text = text.replace(str[0], replacement);
        str = regex.exec(copy);
    }

    function GetMoreStuff(number) {
        var result = '';
        for (let i = 0, length = number; i < length; i += 1) {
            result += 'a';
        }
        return result;
    }

    for (let i = 0, length = text.length; i < length; i += 1) {
        if (text[i] === '{') {
            openBracketsCount += 1;
        }
        if (text[i] === '}') {
            closeBracketsCount += 1;
            if (closeBracketsCount > openBracketsCount) {
                stuffToRemove += 1;
            }
        }
    }

    if (openBracketsCount > closeBracketsCount) {
        stuffToRemove += openBracketsCount - closeBracketsCount;
    }

    console.log(text);
    console.log(text.length - stuffToRemove);

}



solve([
    '1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14;',
    '15; 16; 17; 18; 19; 20; 21; 22; 23; 24; 25; 26; 27; 28;',
    '29; 30; 31; 32; 33; 34; 35; 36; 37; 38; 39; 40; 41; 42;',
    '43; 44; 45; 46; 47; 48; 49; 50; 51; 52; 53; 54; 55; 56;',
    '57; 58; 59; 60; 61; 62; 63; 64; 65; 66; 67; 68; 69; 70;'
]);