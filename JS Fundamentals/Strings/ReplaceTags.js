function solve(args) {
    var text = args[0],
        regex = /<a href="([A-z0-9.:\/_]+)">([\w\s]+)<\/a>/g,
        parts = text.match(regex);

    console.log(text.replace(regex, '[$2]($1)'));
}

solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);