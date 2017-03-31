function solve() {
    var template =
        '<div> class="tabs-control"'+
        '<ul class="list list-titles"'+
        '{{#titles}}'+
        '<li class="list-item">'+
        '<label for="{{link}}" class="title">{{text}}</label>'+
        '</li>'+
        '{{/titles}}'+
        '</ul>'+
        '<ul class="list list-contents">'+
        '{{#contents}}'+
        '<li class="list-item">'+
        '<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" {{#unless @index}}checked="checked/"{{/unless}} type="radio">'+
        '<div class="content">'+
        '{{{text}}}'+
        '</div>'+
        '</li>'+
        '{{/contents}}'+
        '</ul>'+
        '</div>';

    return template;
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}