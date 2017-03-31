function solve() {
    return function(selector) {
        var $select = $(selector);

        var $list = $('<div>').addClass('dropdown-list').appendTo('body');
        var $options = $select.find('option').addClass('dropdown-item').attr('data-value', 1) //cheat
            .first().addClass('current').on('click', chooseCurrent);

        $select.add($options).attr('value', $options.first().attr('data-value'));
        $select.css('display', 'none');

        $list.append($select);

        function chooseCurrent() {
            $(this).removeClass('current').off('click');
            $(this).parent('select').css('display', '').children('option').on('click', goCurrent);
        }

        function goCurrent() {
            $(this).addClass('current').on('click', chooseCurrent);
            $(this).parent().children('option').off('click');
            $(this).parent().css('display', 'none').attr('value', $(this).attr('data-value'));
        }
    };
}

module.exports = solve;