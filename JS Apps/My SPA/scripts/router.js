import { templateAndAppend, getPrevData } from 'builder';

const wrapper = $('#wrapper')[0],
    router = new Sammy(function() {
        this.get('#/animals/:id/info', function(animal) {
            new Promise(function(resolve, reject) {
                    $.get(`/scripts/animals/${animal.params.id}.js`)
                        .done(resolve)
                        .fail(reject);
                })
                .then(() => templateAndAppend(info, wrapper))
                .catch(console.log);
        });
        this.get('#/animals/:id/picture', function(animal) {
            wrapper.innerHTML = `<img class='img-animal' src='../images/${animal.params.id}.jpg'\>`;
        });
        this.get('#/animals/:id', function(animal) {
            wrapper.innerHTML = `<span>${animal.params.id.toUpperCase()}</span>`;
        });
    });

export { router };