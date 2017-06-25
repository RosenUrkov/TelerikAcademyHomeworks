const { Movie } = require('../../models/movie.model');
const { constants } = require('../../constants');

let movieCounter = 1;

const parseMovie = (url) => {
    return fetch(url)
        .then((response) => {
            console.log(movieCounter + ' ' + response.ok + ' ' + url);
            movieCounter++;

            return response.text();
        })
        .then((html) => Movie.fromHtml(html));
};

const gatherMoviesData = (movies, index) => {
    if (index >= movies.length) {
        return Promise.resolve();
    }

    const url = constants.DOMAIN + movies[index].getAttribute('href');
    return parseMovie(url)
        .then((movie) => (movies[index] = movie))
        .then(() => gatherMoviesData(movies, index + 1));
};

module.exports = { parseMovie, gatherMoviesData };
