/*
Create a function that takes an id or DOM element and an array of contents

V * if an id is provided, select the element
V * Add divs to the element
V   * Each div's content must be one of the items from the contents array
V * The function must remove all previous content from the DOM element provided
* Throws if:
V  * The provided first parameter is neither string or existing DOM element
V  * The provided id does not select anything (there is no element that has such an id)
V  * Any of the function params is missing
V  * Any of the function params is not as described
V  * Any of the contents is neight `string` or `number`
V    * In that case, the content of the element **must not be** changed   
*/

function solve(args) {
    return function(element, contents) {

        if ((typeof element !== 'string' && !(element instanceof HTMLElement)) ||
            !Array.isArray(contents) ||
            contents.some(x => typeof x !== 'string' && typeof x !== 'number')) {

            throw Error();
        }

        if (typeof element === 'string') {
            element = document.getElementById(element);

            if (!element) {
                throw Error();
            }
        }

        const fragment = document.createDocumentFragment();
        const div = document.createElement('div');
        contents.forEach(x => {
            const tempDiv = div.cloneNode(true);
            tempDiv.innerHTML = x;
            fragment.appendChild(tempDiv);
        });

        element.innerHTML = '';
        element.appendChild(fragment);
    }
}

module.exports = solve;