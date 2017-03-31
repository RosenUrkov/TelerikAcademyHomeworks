/* globals $ */

function solve() {
    return function(selector) {
        var element;

        if (typeof selector === HTMLElement) {
            element = selector;
        } else if (typeof selector === 'string') {
            element = document.getElementById(selector);
            if (element === null) {
                throw Error('');
            }
        } else {
            throw Error('');
        }

        var targetElementsList = [].slice.apply(element.querySelectorAll('.button,.content'));

        var buttons = [];

        for (var i = 0, length = targetElementsList.length; i < length; i += 1) {
            if (targetElementsList[i].className === 'button') {
                buttons.push(targetElementsList[i]);
            }
        }

        for (var i = 0, length = buttons.length; i < length; i += 1) {
            buttons[i].innerHTML = 'hide'
            buttons[i].addEventListener('click', onButtonClick);
        };

        function onButtonClick(event) {
            var contentItem = [],
                temp,
                contentItem;

            for (var i = 0, length = targetElementsList.length; i < length; i += 1) {
                if (targetElementsList[i] === event.target) {
                    temp = targetElementsList.slice(i);
                    break;
                }
            }

            for (var i = 0, length = temp.length; i < length; i += 1) {
                if (temp[i].className === 'content' && temp[i + 1].className === 'button') {
                    contentItem = temp[i];
                    break;
                }
            }

            if (contentItem === undefined) {
                return;
            }

            if (contentItem.style.display === '') {
                contentItem.style.display = 'none';
                event.target.innerHTML = 'show';
            } else if (contentItem.style.display === 'none') {
                contentItem.style.display = '';
                event.target.innerHTML = 'hide';
            }
        }

    };
};

module.exports = solve;