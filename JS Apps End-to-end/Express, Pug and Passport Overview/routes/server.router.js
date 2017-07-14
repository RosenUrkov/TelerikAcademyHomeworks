const passport = require('passport');
const database = require('../database');
const { Router } = require('express');

const attach = (server) => {
    const router = new Router();

    router
        .get('/', (req, res) => {
            res.redirect('/home');
        })
        .get('/home', (req, res) => {
            res.status(200)
                .render('home');
        })
        .get('/posts', (req, res) => {
            res.status(200)
                .render('posts');
        })
        .post('/posts', (req, res) => {
            const post = req.body;
            console.log(post);

            res.redirect('/404');
        })
        .get('/register', (req, res) => {
            res.status(200)
                .render('register');
        })
        .post('/register', (req, res) => {
            database.addUser(req.body);

            res.status(201)
                .redirect('/login');
        })
        .get('/login', (req, res) => {
            res.status(200)
                .render('login');
        })
        .post('/login', passport.authenticate('local', {
            successRedirect: '/',
            failureRedirect: '/login',
            failureFlash: true,
        }))
        .get('/404', (req, res) => {
            res.status(500)
                .send('not implemented');
        });

    server.use('/', router);
};

module.exports = attach;
