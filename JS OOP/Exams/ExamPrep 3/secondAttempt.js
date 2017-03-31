function solve(args) {

    function validateString(str) {
        if (str.length < 3 || str.length > 25) {
            throw Error('');
        }
    }

    let getID = (function() {
        let counter = 0;

        return function() {
            return ++counter;
        }
    })();

    class Playable {
        constructor(title, author) {
            this.id = getID();
            this.title = title;
            this.author = author;
        }

        get title() {
            return this._title;
        }
        set title(x) {
            validateString(x);

            this._title = x;
        }

        get author() {
            return this._author;
        }
        set author(x) {
            validateString(x);

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
            if (typeof x !== 'number' || Number.isNaN(x) || x <= 0) {
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
            if (typeof x !== 'number' || Number.isNaN(x) || x < 1 || x > 5) {
                throw Error('');
            }

            this._imdbRating = x;
        }

        play() {
            return super.play() + ` - [${this.imdbRating}]`;
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
            validateString(x);

            this._name = x;
        }

        addPlayable(playable) {
            this.list.push(playable);

            return this;
        }

        getPlayableById(id) {
            let result = this.list.find(x => x.id === id);

            if (result === undefined) {
                return null;
            }

            return result;
        }

        removePlayable(playable) {
            if (typeof playable === 'object') {
                playable = playable.id;
            }

            let index = this.list.findIndex(x => x.id === playable);

            if (index <= -1) {
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
                    let result = x.title.localeCompare(y.title);

                    if (result === 0) {
                        return x.id - y.id;
                    }

                    return result;
                })
                .slice(page * size, page * size + size);
        }
    }

    class Player {
        constructor(name) {
            this.name = name;
            this.id = getID();
            this.playlists = [];
        }

        get name() {
            return this._name;
        }
        set name(x) {
            validateString(x);

            this._name = x;
        }

        addPlaylist(playlist) {
            if (!(playlist instanceof Playlist)) {
                throw Error('');
            }

            this.list.push(playlist);

            return this;
        }

        getPlaylistById(id) {
            let result = this.playlists.find(x => x.id === id);

            if (result === undefined) {
                return null;
            }

            return result;
        }

        removePlaylist(playlist) {
            if (typeof playable === 'object') {
                playlist = playlist.id;
            }

            let index = this.list.findIndex(x => x.id === playlist);

            if (index <= -1) {
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
                    let result = x.name.localeCompare(y.name);

                    if (result === 0) {
                        return x.id - y.id;
                    }

                    return result;
                })
                .slice(page * size, size);
        }

        contains(playable, playlist) {
            let plist = this.playlists.find(x => x === playlist);

            return plist.list.some(x => x === playable);
        }

        search(pattern) {
            return this.playlists.filter(x => {
                return x.list.some(y =>
                    y.title.toLowerCase()
                    .includes(pattern.toLowerCase()));
            });
        }
    }

    var module = {
        getPlayer: function(name) {
            return new Player(name);
        },
        getPlaylist: function(name) {
            return new Playlist(name);
        },
        getAudio: function(title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function(title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };

    return module;
}

module.exports = solve;