function solve() {
    return function(selector, isCaseSensitive) {
        var element = document.querySelector(selector),

            addControls = document.createElement('div'),
            searchControls = document.createElement('div'),
            resultControls = document.createElement('div'),

            addLabel = document.createElement('label'),
            searchLabel = document.createElement('label'),

            addInput = document.createElement('input'),
            addButton = document.createElement('button'),

            searchInput = document.createElement('input'),
            searchButton = document.createElement('button'),

            ul = document.createElement('ul'),
            li = document.createElement('li');

        addLabel.innerHTML = 'Enter text';
        searchLabel.innerHTML = 'Search:';

        searchButton.className = 'button';
        searchButton.innerHTML = 'X';

        li.className = 'list-item';
        li.appendChild(searchButton);

        ul.className = 'items-list';
        ul.addEventListener('click', function(event) {
            if (event.target.className !== 'button') {
                return;
            }

            var item = event.target.parentElement;
            item.parentElement.removeChild(item);
        });

        searchInput.addEventListener('input', function(event) {
            var text = searchInput.value,
                content;
            if (!isCaseSensitive) {
                text = text.toLowerCase();
            }

            [].forEach.call(ul.children, function(x) {
                content = x.lastChild.innerHTML;
                if (!isCaseSensitive) {
                    content = content.toLowerCase();
                }

                if (content.includes(text)) {
                    x.style.display = '';
                } else {
                    x.style.display = 'none';
                }
            });
        });

        addButton.className = 'button';
        addButton.innerHTML = 'Add';
        addButton.addEventListener('click', function(event) {
            var clone = li.cloneNode(true),
                strong = document.createElement('strong');

            strong.innerHTML = addInput.value;
            clone.appendChild(strong);
            ul.appendChild(clone);

            addInput.value = '';
        });

        addControls.className = 'add-controls';
        addControls.appendChild(addLabel);
        addControls.appendChild(addInput);
        addControls.appendChild(addButton);

        searchControls.className = 'search-controls';
        searchControls.appendChild(searchLabel);
        searchControls.appendChild(searchInput);

        resultControls.className = 'result-controls';
        resultControls.appendChild(ul);

        element.className = 'items-control';
        element.appendChild(addControls);
        element.appendChild(searchControls);
        element.appendChild(resultControls);
    };
}

module.exports = solve;