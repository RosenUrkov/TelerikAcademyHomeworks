const passport = require('passport');
const { Strategy } = require('passport-local');
const cookieParser = require('cookie-parser');
const session = require('express-session');

const configAuth = (server, database) => {
    passport.use(new Strategy(
        (username, password, done) => {
            return database.findUserByUsername(username)
                .then((user) => done(null, user))
                .catch((error) => done(error));
        }
    ));

    server.use(cookieParser());
    server.use(session({ secret: 'yolo' }));
    server.use(passport.initialize());
    server.use(passport.session());

    passport.serializeUser((user, done) => {
        return done(null, user);
    });

    passport.deserializeUser((id, done) => {
        return database.findUserById(+id)
            .then((user) => done(null, user))
            .catch((error) => done(error));
    });
};

module.exports = configAuth;
