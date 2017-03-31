function solve(args) {
    return function(selector) {
        let element;

        if (typeof selector !== 'string' && !selector instanceof HTMLElement) {
            throw Error();
        }

        if (typeof selector === 'string') {
            element = document.getElementById(selector);

            if (element === null) {
                throw Error();
            }
        } else {
            element = selector;
        }

        const buttonsAndContent = Array.from(element.querySelectorAll('.button,.content'));

        const buttons = buttonsAndContent.filter(x => x.className === 'button');
        buttons.forEach(x => {
            x.innerHTML = 'hide';
            x.addEventListener('click', onClickButton);
        });

        function onClickButton(event) {
            const content = buttonsAndContent
                .slice(buttonsAndContent.findIndex(x => x === event.target))
                .find((x, i, arr) => x.className === 'content' && arr[i + 1].className === 'button');

            if (content === undefined) {
                return;
            }

            if (content.style.display === '') {
                content.style.display = 'none';
                event.target.innerHTML = 'show';
            } else {
                content.style.display = '';
                event.target.innerHTML = 'hide';
            }
        }

    };
}

module.exports = solve;