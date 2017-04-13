export function loadTemplate(data) {
    return new Promise(function(resolve, reject) {
            $.get('/scripts/template.handlebars')
                .done(resolve)
                .fail(reject);
        })
        .then(template => Handlebars.compile(template))
        .then(compiled => compiled(data))
        .catch('Error');
}