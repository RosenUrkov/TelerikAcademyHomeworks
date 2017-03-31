function solve() {
    return function() {
        $.fn.listview = function(data) {
            var $this = $(this);

            //var template = $('script[type="text/handlebars-template"]').first().html();
            var $templateID = $this.attr('data-template');
            var template = $('#' + $templateID).html();

            var hbTemplate = handlebars.compile(template);
            var fragment = $('<div>');

            //data.forEach(x => fragment.append(hbTemplate(x)));
            for (var i = 0, length = data.length; i < length; i += 1) {
                fragment.append(hbTemplate(data[i]));
            }

            $this.html('');
            $this.append(fragment.html());
        };
    };
}

module.exports = solve;