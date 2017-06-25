const { initDomParser } = require('../core/parsers/dom.parser');
const { constants } = require('../constants');

class Movie {
    constructor(name, description, pictureUrl) {
        this.name = name;
        this.description = description;
        this.pictureUrl = pictureUrl;
    }

    static fromHtml(html) {
        return initDomParser(html)
            .then(($) => {
                const name = $(constants.MOVIE_TITLE_SELECTOR)
                    .text().trim();
                const description = $(constants.MOVIE_DESCRIPTION_SELECTOR)
                    .text().trim();
                const pictureUrl = $(constants.MOVIE_PICTURE_SELECTOR)
                    .attr('src');

                return new Movie(name, description, pictureUrl);
            });
    }
}

module.exports = { Movie };
