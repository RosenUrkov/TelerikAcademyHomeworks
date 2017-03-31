/* globals $ */

/* 

V Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
V  * The UL must have a class `items-list`
V  * Each of the LIs must:
V    * have a class `list-item`
V    * content "List item #INDEX"
V      * The indices are zero-based
V  * If the provided selector does not selects anything, do nothing
V  * Throws if
V    * COUNT is a `Number`, but is less than 1
V    * COUNT is **missing**, or **not convertible** to `Number`
V      * _Example:_
V        * Valid COUNT values:
V          * 1, 2, 3, '1', '4', '1123'
V        * Invalid COUNT values:
V          * '123px' 'John', {}, [] 
*/

function solve() {
    return function(selector, count) {
        if (Number.isNaN(Number(count)) || Number(count) < 1 || typeof selector !== 'string') {
            throw Error();
        }

        var $element = $(selector);

        if ($element.length === 0) {
            return;
        }

        var $ul = $('<ul>').addClass('items-list');

        for (var i = 0, length = count; i < length; i += 1) {
            $ul.append($('<li>').html(`List item #${i}`).addClass('list-item'));
        }

        $element.append($ul);
    };
};

module.exports = solve;