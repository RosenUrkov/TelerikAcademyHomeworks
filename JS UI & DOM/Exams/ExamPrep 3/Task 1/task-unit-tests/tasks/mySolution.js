function solve() {
    return function(selector, items) {
        const element = document.querySelector(selector),
            preview = document.createElement('div'),
            container = document.createElement('ul'),
            imgContainer = document.createElement('li'),
            img = document.createElement('img'),
            label = document.createElement('label'),
            search = document.createElement('div'),
            input = document.createElement('input');

        imgContainer.appendChild(label);
        imgContainer.appendChild(img);
        imgContainer.className = 'image-container';

        preview.className = 'image-preview';
        const previewImage = imgContainer.cloneNode(true);
        previewImage.className = '';
        previewImage.children[0].innerHTML = items[0].title;
        previewImage.children[1].src = items[0].url;
        preview.appendChild(previewImage);

        container.addEventListener('click', function(event) {
            let target = event.target;

            if (target.className !== 'image-container' &&
                target.parentElement.className !== 'image-container') {
                return;
            }

            if (event.target.parentElement.className === 'image-container') {
                target = event.target.parentElement;
            }

            previewImage.children[0].innerHTML = target.children[0].innerHTML;
            previewImage.children[1].src = target.children[1].src;
        });

        const clonedLabel = label.cloneNode(true);
        clonedLabel.innerHTML = 'Filter';

        input.addEventListener('input', () => {
            Array.from(container.children).forEach(x => {
                if (x.firstChild.innerHTML.toLowerCase().includes(input.value.toLowerCase())) {
                    x.style.display = '';
                } else {
                    x.style.display = 'none';
                }
            })
        });

        search.appendChild(clonedLabel);
        search.appendChild(input);

        items.forEach(x => {
            const clone = imgContainer.cloneNode(true);
            clone.children[0].innerHTML = x.title;
            clone.children[1].src = x.url;

            container.appendChild(clone);
        });

        element.appendChild(search);
        element.appendChild(preview);
        element.appendChild(container);
    }
}

module.exports = solve;