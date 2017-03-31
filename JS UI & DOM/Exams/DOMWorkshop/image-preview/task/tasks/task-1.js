/* globals module */
function solve() {
    'use strict';
    return function(selector, items) {

        if (typeof selector !== 'string' ||
            items.some(x => !x.hasOwnProperty('title') || !x.hasOwnProperty('url'))) {
            throw Error();
        }

        const element = document.querySelector(selector);
        element.style.margin = '0px';
        element.style.padding = '0px';
        element.style.width = '545px';
        element.style.height = '380px';

        const filterDiv = document.createElement('div');
        filterDiv.style.float = 'right';
        filterDiv.style.width = '120px';
        filterDiv.style.overflow = 'hidden';

        const filterSpan = document.createElement('span');
        filterSpan.innerHTML = 'Filter';
        filterSpan.style.cssFloat = 'right';
        filterSpan.style.width = '115px';
        filterSpan.style.textAlign = 'center';

        const input = document.createElement('input');
        input.style.position = 'relative';
        input.style.width = '115px';
        input.type = 'text';
        input.addEventListener('keyup', onKeyUp);

        filterDiv.appendChild(filterSpan);
        filterDiv.appendChild(input);

        const mainDiv = document.createElement('div');
        mainDiv.className = 'image-preview';
        mainDiv.style.width = '380px';
        mainDiv.style.height = '380px';
        mainDiv.style.position = 'relative';
        mainDiv.style.cssFloat = 'left';

        const mainSpan = document.createElement('span');
        mainSpan.style.cssFloat = 'right';
        mainSpan.style.position = 'relative';
        mainSpan.style.top = '30px';
        mainSpan.style.fontSize = '32px';
        mainSpan.style.width = '380px';
        mainSpan.style.fontWeight = 'bold';
        mainSpan.style.verticalAlign = 'middle';
        mainSpan.style.textAlign = 'center';
        mainSpan.innerHTML = items[0].title;

        const mainImg = document.createElement('img');
        mainImg.style.cssFloat = 'right';
        mainImg.style.clear = 'right';
        mainImg.style.width = '350px';
        mainImg.style.height = '260px';
        mainImg.style.position = 'relative';
        mainImg.style.borderRadius = '10px';
        mainImg.style.top = '60px';
        mainImg.style.right = '20px';
        mainImg.src = items[0].url;

        mainDiv.appendChild(mainSpan);
        mainDiv.appendChild(mainImg);

        element.appendChild(mainDiv);

        const fragment = document.createDocumentFragment();

        items.forEach(x => {
            let div = document.createElement('div');
            div.className = 'image-container';
            div.style.position = 'relative';
            div.style.cssFloat = 'right';
            div.style.width = '130px';
            div.addEventListener('mouseover', onMouseOver);
            div.addEventListener('mouseout', onMouseOut);
            div.addEventListener('click', onClick);

            let span = document.createElement('span');
            span.style.cssFloat = 'right';
            span.style.width = '115px';
            span.style.fontWeight = 'bold';
            span.style.textAlign = 'center';
            span.innerHTML = x.title;

            let img = document.createElement('img');
            img.style.position = 'relative';
            img.style.left = '5px';
            img.style.width = '120px';
            img.style.height = '90px';
            img.style.borderRadius = '5px';
            img.src = x.url;

            div.appendChild(span);
            div.appendChild(img);

            fragment.appendChild(div);
        });

        function onMouseOver(event) {
            let element;

            if (event.target.tagName === 'DIV') {
                element = event.target;
            } else {
                element = event.target.parentNode;
            }

            element.style.backgroundColor = 'grey';
        }

        function onMouseOut(event) {
            let element;

            if (event.target.tagName === 'DIV') {
                element = event.target;
            } else {
                element = event.target.parentNode;
            }

            element.style.backgroundColor = 'white';
        }

        function onClick(event) {
            let element;

            if (event.target.tagName === 'DIV') {
                element = event.target;
            } else {
                element = event.target.parentNode;
            }

            const span = element.getElementsByTagName('span')[0];
            mainSpan.innerHTML = span.innerHTML;

            const img = element.getElementsByTagName('img')[0];
            mainImg.src = img.src;
        }

        function onKeyUp(event) {
            const divs = asideDiv.getElementsByClassName('image-container');

            Array.from(divs).forEach(div => {
                const span = div.getElementsByTagName('span')[0];

                if (!span.innerHTML.toLowerCase().includes(event.target.value.toLowerCase())) {
                    div.style.display = 'none';
                } else {
                    div.style.display = 'block';
                }
            })
        }

        const asideDiv = document.createElement('div');
        asideDiv.style.width = '155px';
        asideDiv.style.height = '380px';
        asideDiv.style.overflowY = 'scroll';

        asideDiv.appendChild(filterDiv);
        asideDiv.appendChild(fragment);

        element.appendChild(asideDiv);
    };
}

module.exports = solve;