function solve() {
    return function(fileContentsByName) {
        var $explorer = $('.file-explorer'),
            $preview = $('.file-preview'),
            $input = $('input'),

            $li = $('<li>')
            .addClass('file-item item')
            .append($('<a>').addClass('item-name'))
            .append(($('<a>').addClass('del-btn')));

        $explorer.on('click', function(event) {
            var $target = $(event.target);

            if ($target.hasClass('del-btn')) {
                $target.parent().remove();
            } else if ($target.parent().hasClass('dir-item')) {
                $target.parent().toggleClass('collapsed');
            } else if ($target.hasClass('item-name')) {
                $preview.find('p').text(fileContentsByName[$target.html()] || '');
            } else if ($target.hasClass('add-btn')) {
                $target.toggleClass('visible').next().toggleClass('visible');
            }
        });

        $input.on('keydown', function(event) {
            if (event.which !== 13) {
                return;
            }

            var path = $input.val().split('/'),
                text = path[1] || path[0],
                $parent = $explorer.find('.items').first();

            if (path.length > 1) {
                $parent = $('.dir-item')
                    .filter(function(_, x) {
                        return $(x)
                            .find('.item-name')
                            .html() === path[0];
                    })
                    .find('.items');

                if ($parent.length === 0) {
                    return;
                }
            }

            $parent.append(
                $li
                .clone()
                .find('.item-name')
                .text(text)
                .parent()
            );

            $input
                .val('')
                .toggleClass('visible')
                .prev()
                .toggleClass('visible');

        });
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}