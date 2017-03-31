/* globals $ */

function solve() {

    return function(selector) {
        var template =
            '<table class="items-table">' +
            '<thead>' +
            '<tr>' +
            '<th>' +
            '#' +
            '</th>' +
            '{{#this.headers}}' +
            '<th>' +
            '{{this}}' +
            '</th>' +
            '{{/this.headers}}' +
            '</tr>' +
            '</thead>' +

            '<tbody>' +
            '{{#this.items}}' +
            '<tr>' +
            '<td>' +
            '{{@index}}' +
            '</td>' +
            '<td>' +
            '{{col1}}' +
            '</td>' +
            '<td>' +
            '{{col2}}' +
            '</td>' +
            '<td>' +
            '{{col3}}' +
            '</td>' +
            '</tr>' +
            '{{/this.items}}' +
            '</tbody>' +
            '</table>';

        $(selector).html(template);
    };
};

module.exports = solve;