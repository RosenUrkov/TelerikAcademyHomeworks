const { Router } = require('express');
const jwt = require('jsonwebtoken');
const config = require('../../config');

const attachRouter = (data) => {
    const response = {
        status: 200,
        data: [],
        message: null,
    };

    const sendError = (err, res) => {
        response.status = 501;
        response.message = typeof err === 'object' ? err.message : err;
        res.status(501).json(response);
    };

    const router = new Router();
    router
        .get('/users', (req, res) => {
            data.getAll()
                .then((users) => res.send(users));
        })
        .post('/login', (req, res) => {
            const user = req.body;

            Promise.resolve()
                .then(() => {
                    const jwtObject = {
                        _id: user._id,
                        username: user.username,
                    };

                    const token = jwt.sign(jwtObject, config.APP_SECRET, {
                        expiresIn: 1440,
                    });

                    return res.send({ success: true, message: 'login success!', token });
                })
                .catch(() => {
                    res.send(({ success: false, message: 'Invalid Credentials' }));
                });
        });

    return router;
};

module.exports = attachRouter;
