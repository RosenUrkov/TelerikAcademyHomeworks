function solve() {

    return function(selector, defaultLeft, defaultRight) {
        var element = document.querySelector(selector),
            left = defaultLeft || [],
            right = defaultRight || [],

            container = document.createElement('div'),

            col = document.createElement('div'),

            radio = document.createElement('input'),
            radioContainer = document.createElement('div'),

            olLeft = document.createElement('ol'),
            olRight = document.createElement('ol'),

            li = document.createElement('li'),
            img = document.createElement('img'),

            input = document.createElement('input'),
            button = document.createElement('button');

        radio.type = 'radio';
        radio.name = 'column-select';
        radioContainer.className = 'select';
        radioContainer.appendChild(radio.cloneNode(true));

        img.className = 'delete';
        img.src = 'imgs/Remove-icon.png';

        li.className = 'entry';
        li.appendChild(img);

        left.forEach(function(x) {
            var cloneLi = li.cloneNode(true);
            cloneLi.innerHTML = x + cloneLi.innerHTML;

            olLeft.appendChild(cloneLi);
        });

        right.forEach(function(x) {
            var cloneLi = li.cloneNode(true);
            cloneLi.innerHTML = x + cloneLi.innerHTML;

            olRight.appendChild(cloneLi);
        });

        col.className = 'column';
        col.appendChild(radioContainer.cloneNode(true));

        var leftCol = col.cloneNode(true),
            rightCol = col.cloneNode(true);

        leftCol.appendChild(olLeft);
        leftCol.getElementsByTagName('input')[0].checked = true;

        rightCol.appendChild(olRight);

        container.className = 'column-container';
        container.appendChild(leftCol);
        container.appendChild(rightCol);

        button.innerHTML = 'Add';
        button.addEventListener('click', function(event) {
            var text = input.value.trim(),
                cloneLi = li.cloneNode(true);

            input.value = '';
            if (text === '') {
                return;
            }

            cloneLi.innerHTML = text + cloneLi.innerHTML;
            if (rightCol.getElementsByTagName('input')[0].checked === true) {

                olRight.appendChild(cloneLi);
            } else if (leftCol.getElementsByTagName('input')[0].checked === true) {

                olLeft.appendChild(cloneLi);
            } else {
                return;
            }

        });

        container.addEventListener('click', function(event) {
            console.log(event.target.className);
            if (event.target.className !== 'delete') {
                return;
            }

            event.target.parentElement.parentElement
                .removeChild(event.target.parentElement);

            input.value = event.target.parentElement.innerHTML.substring(0, event.target.parentElement.innerHTML.indexOf('<'));
        });

        element.appendChild(container);
        element.appendChild(input);
        element.appendChild(button);
    };
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
    module.exports = solve;
}