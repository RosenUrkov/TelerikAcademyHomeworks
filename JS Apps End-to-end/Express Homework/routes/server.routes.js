const { Router } = require('express');

const attach = (server) => {
    const router = new Router();

    router
        .get('/', (req, res) => {
            res.status(200)
                .send({
                    id: 1,
                    name: 'user',
                });
        })
        .post('/', (req, res) => {
            const body = req.body;
            console.log(body);
            res.send(body);
        })
        .get('/html', (req, res) => {
            res.status(500)
                .render('common');
        });

    server.use('/common', router);
};

module.exports = attach;
