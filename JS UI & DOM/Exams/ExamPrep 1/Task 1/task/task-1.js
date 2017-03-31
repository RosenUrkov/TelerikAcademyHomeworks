/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
        var element = document.querySelector(selector),
            suggestions = initialSuggestions || [],

            li = document.createElement('li'),
            a = document.createElement('a'),

            ul = element.getElementsByClassName('suggestions-list')[0],
            button = element.getElementsByClassName('btn-add')[0],
            input = element.getElementsByClassName('tb-pattern')[0];

        a.className = 'suggestion-link';
        li.className = 'suggestion';
        li.style.display = 'none';
        li.appendChild(a);

        suggestions.forEach(function(x) {
            if (suggestionExists(x)) {
                return;
            }

            var clone = li.cloneNode(true);
            clone.children[0].innerHTML = x;
            ul.appendChild(clone);
        });

        input.addEventListener('input', function() {
            [].forEach.call(ul.children, function(x) {
                if (input.value === '') {
                    x.style.display = 'none';
                } else if (x.children[0].innerHTML.toLowerCase()
                    .includes(input.value.toLowerCase())) {
                    x.style.display = '';
                } else {
                    x.style.display = 'none';
                }
            });
        });

        button.addEventListener('click', function() {
            var sugg = input.value,
                clone = li.cloneNode(true);

            if (suggestionExists(input.value)) {
                return;
            }

            clone.children[0].innerHTML = sugg;
            ul.appendChild(clone);

            input.value = '';
        });

        ul.addEventListener('click', function(event) {
            if (event.target.tagName === 'LI') {
                input.value = event.target.children[0].innerHTML;
            } else if (event.target.tagName === 'A') {
                input.value = event.target.innerHTML;
            }
        });

        function suggestionExists(suggestion) {
            var isExisting = false;

            [].forEach.call(ul.children, function(x) {
                if (x.children[0].innerHTML.toLowerCase() ===
                    suggestion.toLowerCase()) {
                    isExisting = true;
                }
            });

            return isExisting;
        }
    };
}

module.exports = solve;