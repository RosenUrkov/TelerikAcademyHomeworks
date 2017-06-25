const { Genre } = require('../../models/genre.model');
const { constants } = require('../../constants');

const parseGenre = (url) => {
    return fetch(url)
        .then((response) => response.text())
        .then((html) => Genre.fromHtml(html));
};

const gatherGenresData = (genres, index) => {
    if (index >= genres.length) {
        return Promise.resolve();
    }

    const url = constants.DOMAIN + genres[index].getAttribute('href');
    return parseGenre(url)
        .then((genre) => (genres[index] = genre))
        .then(() => gatherGenresData(genres, index + 1));
};

module.exports = { parseGenre, gatherGenresData };
