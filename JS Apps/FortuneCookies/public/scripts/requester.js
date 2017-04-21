export class Requester {
    getJSON(url, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url,
                headers,
                type: 'GET',
                dataType: 'application/json',
                success: (data) => resolve(data),
                error: (data) => reject(data)
            })
        });
    }

    postJSON(url, data, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url,
                    headers,
                    type: "POST",
                    contentType: 'application/json',
                    data: JSON.stringify(data)
                })
                .then(resolve)
                .fail(reject);
        });
    }

    putJSON(url, data, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url,
                    headers,
                    type: "PUT",
                    contentType: 'application/json',
                    data: JSON.stringify(data)
                })
                .then(resolve)
                .fail(reject);
        });
    }

    getTemplate(name) {
        return new Promise((resolve, reject) => {
            $.ajax({
                    url: `../templates/${name}.handlebars`,
                    type: 'GET',
                })
                .then(resolve)
                .fail(reject);
        });
    }
}