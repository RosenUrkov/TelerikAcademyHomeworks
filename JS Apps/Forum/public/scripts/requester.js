export class Requester {
    getJSON(url) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url,
                type: 'GET',
                dataType: 'application/json',
                success: data => resolve(data),
                error: data => reject(data)
            })
        });
    }

    postJSON(url, data, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url,
                data: JSON.stringify(data),
                headers,
                type: 'POST',
                contentType: 'application/json',
                dataType: 'application/json',
                success: data => resolve(data),
                error: data => reject(data)
            })
        });
    }

    putJSON(url, data) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url,
                data: JSON.stringify(data),
                type: 'PUT',
                contentType: 'application/json',
                dataType: 'application/json',
                success: data => resolve(data),
                error: data => reject(data)
            })
        });
    }

    getTemplate(name) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: `../templates/${name}.html`,
                type: 'GET',
                success: data => resolve(data),
                error: data => reject(data)
            })
        });
    }
}