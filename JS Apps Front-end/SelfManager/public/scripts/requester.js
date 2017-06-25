class Requester {
    getJSON(url, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url,
                    headers,
                    type: 'GET'
                })
                .done(resolve)
                .fail(reject);
        });
    }

    postJSON(url, data, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url,
                    headers,
                    type: 'POST',
                    data: JSON.stringify(data),
                    contentType: 'application/json'
                })
                .done(resolve)
                .fail(reject);
        });
    }

    putJSON(url, data, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url,
                    type: 'PUT',
                    headers,
                    data: JSON.stringify(data),
                    contentType: 'application/json'
                })
                .done(resolve)
                .fail(reject);
        });
    }

    getTemplate(name) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url: `../templates/${name}.html`,
                    type: 'GET'
                })
                .done(resolve)
                .fail(reject);
        });
    }
}

const requester = new Requester();
export { requester };