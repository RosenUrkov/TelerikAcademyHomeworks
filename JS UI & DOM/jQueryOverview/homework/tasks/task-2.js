/* globals $ */

/*
V Create a function that takes a selector and:
V * Finds all elements with class `button` or `content` within the provided element
V  * Change the content of all `.button` elements with "hide"
V * When a `.button` is clicked:
V  * Find the topmost `.content` element, that is before another `.button` and:
V    * If the `.content` is visible:
V      * Hide the `.content`
V      * Change the content of the `.button` to "show"       
V    * If the `.content` is hidden:
V      * Show the `.content`
V      * Change the content of the `.button` to "hide"
V    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
V * Throws if:
V  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
    return function(selector) {
        if (typeof selector !== 'string') {
            throw Error();
        }

        var $element = $(selector);

        if ($element.length === 0) {
            throw Error();
        }

        $element.find('.button').html('hide').on('click', onClickButton);

        function onClickButton(event) {

            var $this = $(this);
            var $content = $this.nextAll('.content').first();

            if ($content === undefined) {
                return;
            }

            if ($this.html() === 'show') {
                $content.css('display', '');
                $this.html('hide');
            } else {
                $content.css('display', 'none');
                $this.html('show');
            }
        }
    };
};

module.exports = solve;