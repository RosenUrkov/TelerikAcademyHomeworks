function solve() {
    return function(selector, isCaseSensitive) {

        if (typeof selector !== 'string') {
            throw Error();
        }

        const element = document.querySelector(selector);

        if (!element || !(element instanceof HTMLElement)) {
            throw new Error("Invalid HTML element or selector");
        }

        isCaseSensitive = !!isCaseSensitive;
        element.className = 'items-control';

        const EVENTS = {
            adding(event) {
                let clone = li.cloneNode(true);

                clone.getElementsByTagName('strong')[0].innerHTML = addingInput.value;
                addingInput.value = '';

                resultUL.appendChild(clone);
            },

            removing(event) {
                const target = event.target;

                if (!target.className.includes('button-del')) {
                    return;
                }

                target.parentNode.outerHTML = '';
            },

            searching(event) {
                let value = searchInput.value;

                if (!isCaseSensitive) {
                    value = value.toLowerCase();
                }

                Array.from(resultUL.getElementsByTagName('strong'))
                    .forEach(el => {
                        let text = el.innerHTML;

                        if (!isCaseSensitive) {
                            text = text.toLowerCase();
                        }

                        if (!text.includes(value)) {
                            el.parentElement.style.display = 'none';
                        } else {
                            el.parentElement.style.display = '';
                        }
                    });
            }
        }

        const addingForm = document.createElement('div');
        addingForm.className = 'add-controls';

        const addingLabel = document.createElement('label');
        addingLabel.innerHTML = 'Enter text';

        const addingInput = document.createElement('input');
        addingInput.type = 'text';

        const addingButton = document.createElement('button');
        addingButton.type = 'button';
        addingButton.className = 'button';
        addingButton.innerHTML = 'Add';
        addingButton.addEventListener('click', EVENTS.adding);

        addingForm.appendChild(addingLabel);
        addingForm.appendChild(addingInput);
        addingForm.appendChild(addingButton);


        const searchDiv = document.createElement('div');
        searchDiv.className = 'search-controls';

        const searchLabel = document.createElement('label');
        searchLabel.htmlFor = 'searching';
        searchLabel.innerHTML = 'Search:';

        const searchInput = document.createElement('input');
        searchInput.type = 'text';
        searchInput.addEventListener('keyup', EVENTS.searching);

        searchDiv.appendChild(searchLabel);
        searchDiv.appendChild(searchInput);


        const resultDiv = document.createElement('div');
        resultDiv.className = 'result-controls';

        const resultUL = document.createElement('ul');
        resultUL.className = 'items-list';
        resultUL.addEventListener('click', EVENTS.removing);

        resultDiv.appendChild(resultUL);


        const li = document.createElement('li');
        li.className = 'list-item';
        li.style.listStyle = 'none';

        const strong = document.createElement('strong');

        const button = document.createElement('button');
        button.className = 'button button-del';
        button.innerHTML = 'X';

        li.appendChild(button);
        li.appendChild(strong);


        element.appendChild(addingForm);
        element.appendChild(searchDiv);
        element.appendChild(resultDiv);
    };
}

module.exports = solve;