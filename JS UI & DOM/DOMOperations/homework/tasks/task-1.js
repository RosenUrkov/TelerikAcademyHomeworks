/* globals $ */

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

function solve() {
    return function(element, contents) {

        if (element === undefined || contents === undefined || !Array.isArray(contents) ||
            (typeof element !== 'string' && typeof element !== 'object')) {
            throw Error('');
        }

        for (var i = 0, length = contents.length; i < length; i += 1) {
            if (typeof contents[i] !== 'string' && typeof contents[i] !== 'number') {
                throw Error('');
            }
        }

        if (typeof element === 'string') {
            element = document.getElementById(element);
        }

        if (element === null) {
            throw Error('');
        }

        element.innerHTML = '';

        var fragment = document.createDocumentFragment();

        for (var i = 0, length = contents.length; i < length; i += 1) {
            var div = document.createElement('div');
            div.innerHTML = contents[i];
            fragment.appendChild(div);
        }

        element.appendChild(fragment);
    }
};

module.exports = solve;