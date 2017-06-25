const { initDomParser } = require('../core/parsers/dom.parser');
const { gatherMoviesData } = require('../core/parsers/movie.model.parser');
const { constants } = require('../constants');

class Genre {
    constructor(name) {
        this.name = name;
        this.movies = [];
    }

    static fromHtml(html) {
        return initDomParser(html)
            .then(($) => {
                const name = $(constants.GENRE_TITLE_SELECTOR).first()
                    .text().trim().substring('Genre: '.length);

                const genre = new Genre(name);
                genre.movies = Array.from($(constants.MOVIE_ID_SELECTOR).children('a'));

                return genre;
            })
            .then((genre) => {
                return gatherMoviesData(genre.movies, 0)
                    .then(() => genre);
            });
    }
}

module.exports = { Genre };
