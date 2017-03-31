function solve() {

    let getID = (function() {
        let counter = 0;

        return function() {
            return ++counter;
        };
    })();

    const VALIDATOR = {
        VALIDATE_STRING(str) {
            if (str.length < 3 || str.length > 25) {
                throw Error('');
            }
        },
        VALIDATE_NUMBER(num) {
            if (typeof num !== 'number' || Number.isNaN(num)) {
                throw Error('');
            }
        }
    }

    class Player {
        constructor(name) {
            this.name = name;
            this.playlists = [];
            this.id = getID();
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            this._name = x;
        }

        addPlaylist(playlist) {
            if (!(typeof playlist === 'object')) {
                throw Error('');
            }

            this.playlists.push(playlist);
            return this;
        }

        getPlaylistById(id) {
            let playlist = this.playlists.find(x => x.id === id);

            if (playlist === undefined) {
                return null;
            }

            return playlist;
        }

        removePlaylist(playlist) {
            let id;

            if (playlist instanceof Playlist) {
                id = playlist.id;
            } else {
                id = playlist;
            }

            let index = this.playlists.findIndex(x => x.id === id);

            if (index === -1) {
                throw Error('');
            }

            this.playlists.splice(index, 1);

            return this;
        }

        listPlaylists(page, size) {
            if (page * size > this.playlists.length || page < 0 || size <= 0) {
                throw Error('');
            }

            return this.playlists
                .slice()
                .sort((x, y) => {
                    let sorted = x.name.localeCompare(y.name);

                    if (sorted === 0) {
                        return x.id - y.id;
                    }

                    return sorted;
                })
                .splice(page * size, size);
        }

        contains(playable, playlist) {
            let pList = this.playlists.find(x => x === playlist);

            return pList.list.some(x => x === playable);
        }

        search(pattern) {
            return this.playlists
                .filter(x => {
                    return x.list.some(y => y.title.toLowerCase() === pattern.toLowerCase());
                })
                .map(x => ({ name: x.name, id: x.id }));
        }
    }

    class Playlist {
        constructor(name) {
            this.name = name;
            this.id = getID();
            this.list = [];
        }

        get name() {
            return this._name;
        }
        set name(x) {
            VALIDATOR.VALIDATE_STRING(x);
            this._name = x;
        }

        addPlayable(playable) {
            this.list.push(playable);

            return this;
        }

        getPlayableById(id) {
            let playable = this.list.find(x => x.id === id);

            if (playable === undefined) {
                return null;
            }

            return playable;
        }

        removePlayable(playable) {
            let id;

            if (typeof playable === 'object') {
                id = playable.id;
            } else {
                id = playable;
            }

            let index = this.list.findIndex(x => x.id === id);

            if (index === -1) {
                throw Error('');
            }

            this.list.splice(index, 1);

            return this;
        }

        listPlayables(page, size) {
            if (page * size > this.list.length || page < 0 || size <= 0) {
                throw Error('');
            }

            return this.list
                .slice()
                .sort((x, y) => {
                    let sorted = x.title.localeCompare(y.title);

                    if (sorted === 0) {
                        return x.id - y.id;
                    }

                    return sorted;
                })
                .splice(page * size, size);
        }
    }

    class Playable {
        constructor(title, author) {
            this.title = title;
            this.author = author;
            this.id = getID();
        }

        get title() {
            return this._title;
        }
        set title(x) {
            VALIDATOR.VALIDATE_STRING(x);
            this._title = x;
        }

        get author() {
            return this._author;
        }
        set author(x) {
            VALIDATOR.VALIDATE_STRING(x);
            this._author = x;
        }

        play() {
            return `[${this.id}]. [${this.title}] - [${this.author}]`;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }

        get length() {
            return this._length;
        }
        set length(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            if (x <= 0) {
                throw Error('');
            }
            this._length = x;
        }

        play() {
            return super.play() + ` - [${this.length}]`;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating() {
            return this._imdbRating;
        }
        set imdbRating(x) {
            VALIDATOR.VALIDATE_NUMBER(x);
            if (x < 1 || x > 5) {
                throw Error('');
            }
            this._imdbRating = x;
        }

        play() {
            return super.play() + ` - [${this.imdbRating}]`;
        }
    }




    var module = {
        getPlayer(name) {
            return new Player(name);
        },
        getPlaylist(name) {
            return new Playlist(name);
        },
        getAudio(title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo(title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };

    return module;
}

module.exports = solve;