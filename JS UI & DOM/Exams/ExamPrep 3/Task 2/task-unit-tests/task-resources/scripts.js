/* globals $ */

function solve() {
    return function() {
        $.fn.gallery = function(colCount) {
            colCount = colCount || 4;

            const $this = $(this),
                $images = $this
                .addClass('gallery')
                .find('.selected')
                .hide()
                .prev('.gallery-list')
                .children()
                .addClass('clearfix')
                .on('click', function() {
                    let dataInfo = $(this).attr('data-info'),
                        prev = (((dataInfo + 12) % 12) - 1) || 12,
                        next = ((dataInfo + 12) % 12) + 1;

                    $this
                        .find('.gallery-list')
                        .addClass('blurred')
                        .addClass('disabled-background')
                        .next('.selected')
                        .show()
                        .find('#current-image')
                        .attr('src', $(this).find('img').attr('src'))
                        .prev('#previous-image')
                        .attr('src', $(`img[data-info="${prev}"]`).first().attr('src'))

                }),
                imagesCount = $images.length,
                $table = $('<table>')
                .addClass('gallery-list');

            for (let i = 0, length = Math.ceil(imagesCount / colCount); i < length; i += 1) {
                let $row = $table.append($('<tr>')).find('tr').eq(i);
                for (let j = 0, length = colCount; j < length; j += 1) {
                    if ((i * colCount + j) > imagesCount) {
                        break;
                    }
                    $row.append($('<td>').append($images.eq(i * colCount + j)));
                }
            }

            $this.find('.gallery-list').replaceWith($table);
        };
    }
}

module.exports = solve;