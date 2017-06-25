const { initDomParser } = require('./parsers/dom.parser');
const { gatherGenresData } = require('./parsers/genre.model.parser');
const { constants } = require('../constants');

const stealAllTheData = () => {
    return fetch(constants.GENRES_URL)
        .then((response) => response.text())
        .then((html) => initDomParser(html))
        .then(($) => Array.from($(constants.GENRE_ID_SELECTOR).find('a')))
        .then((genres) => {
            return gatherGenresData(genres, 0)
                .then(() => genres);
        });
};

module.exports = { stealAllTheData };
