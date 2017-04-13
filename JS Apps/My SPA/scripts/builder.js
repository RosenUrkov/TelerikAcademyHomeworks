import { loadTemplate as template } from 'loader';

let prevData;

function templateAndAppend(data, element) {
    prevData = data;
    template(data).then(result => element.innerHTML = result);
}

function getPrevData() {
    return JSON.parse(JSON.stringify(prevData));
}

export { templateAndAppend, getPrevData };