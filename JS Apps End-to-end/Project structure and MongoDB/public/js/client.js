/* globals $ */

$('document').ready(() => {
    $('body').on('click', (event) => {
        // eslint-disable-next-line
        const color = `rgb(${Math.random() * 255}, ${Math.random() * 255}, ${Math.random() * 255})`;
        $('#home').css('color', color);
    });
});
