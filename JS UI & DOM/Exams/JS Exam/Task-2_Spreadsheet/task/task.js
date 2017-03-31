function solve() {

    return function(selector, rows, columns) {
        var $element = $(selector),
            $table =
            $('<table>')
            .addClass('spreadsheet-table')
            .appendTo($element),
            $headerCell = $('<th>')
            .addClass('spreadsheet-item')
            .addClass('spreadsheet-header'),
            $cell = $('<td>')
            .addClass('spreadsheet-item')
            .addClass('spreadsheet-cell')
            .append($('<span>'))
            .append($('<input>'));

        for (var i = 0, length = rows + 1; i < length; i += 1) {
            var $row = $table.append($('<tr>')).children('tr').eq(i);
            for (var j = 0, length2 = columns + 1; j < length2; j += 1) {
                if (i === 0 && j === 0) {
                    $row.append($headerCell.clone());
                    continue;
                }

                if (i === 0) {
                    $row.append($headerCell.clone().html(String.fromCharCode(64 + j)));
                } else if (j === 0) {
                    $row.append($headerCell.clone().html(i));
                } else {
                    $row.append($cell.clone());
                }
            }
        }

        $table
            .on('mousedown', '.spreadsheet-item', function() {
                $('.selected').removeClass('selected');
                var $this = $(this),
                    $currRow = $this.parent('tr'),
                    isMouseUp = false;

                if ($this.hasClass('spreadsheet-header')) {
                    if ($currRow.children('th').index($this) === 0 &&
                        $currRow.parent('table').children('tr').index($currRow) === 0) {
                        $('.spreadsheet-item').addClass('selected');
                    } else if ($currRow.children('th').index($this) === 0) {
                        $currRow.children().addClass('selected');
                    } else if ($currRow.children('th').index($this) > 0) {
                        $currRow.parent('table')
                            .children('tr')
                            .each(function(_, item) {
                                $(item)
                                    .children()
                                    .eq($currRow.children('th').index($this))
                                    .addClass('selected');
                            });
                    }
                } else {
                    var cellNumber =
                        $this
                        .addClass('selected')
                        .parent('tr')
                        .children('th')
                        .addClass('selected')
                        .parent('tr')
                        .children()
                        .index($this);

                    $table
                        .children('tr')
                        .first()
                        .children('th')
                        .eq(cellNumber)
                        .addClass('selected');
                }

                $table
                    .on('mouseup', function() {
                        isMouseUp = true;
                        return;
                    })
                    .on('mousemove', '.spreadsheet-item', function() {
                        if (isMouseUp) {
                            return;
                        }

                        $(this).addClass('selected');

                        var indexes = [];
                        $('.selected')
                            .each(function(_, selected) {
                                indexes.push(
                                    $(selected)
                                    .parent()
                                    .children()
                                    .index($(selected))
                                );
                            })
                            .parent('tr')
                            .each(function(_, selected) {
                                indexes.forEach(function(x) {
                                    $(selected)
                                        .children()
                                        .eq(x)
                                        .addClass('selected');
                                });
                            })

                    });
            })
            .on('dblclick', '.spreadsheet-cell', function() {
                var $this = $(this).addClass('editing'),
                    text;

                text = $this.find('span').html();
                $this.find('input').val(text).focus();

                $this.find('input')
                    .on('blur', function() {
                        $this.removeClass('editing');

                        text = $this.find('input').val();
                        $this.find('span').html(text);
                    })
                    .on('keypress', function(event) {
                        if (event.which !== 13) {
                            return;
                        }

                        $this.removeClass('editing');

                        text = $this.find('input').val();
                        $this.find('span').html(text);
                    });
            })
    };
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
    module.exports = solve;
}