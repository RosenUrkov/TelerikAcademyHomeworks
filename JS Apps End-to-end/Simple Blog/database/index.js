/* globals __dirname */

const fileStream = require('fs');
const path = require('path');
const filepath = path.join(__dirname, './db.json');

const getUsers = (predicate) => {
    return JSON.parse(
            fileStream.readFileSync(filepath, { encoding: 'utf-8' }))
        .users
        .map((x) => predicate(x));
};

const addUser = (user) => {
    const data = JSON.parse(
        fileStream.readFileSync(filepath, { encoding: 'utf-8' }));

    user.id = data.users.length + 1;
    data.users.push(user);

    fileStream.writeFileSync(
        filepath, JSON.stringify(data), { encoding: 'utf-8' });
};

const findUserByUsername = (username) => {
    const user =
        getUsers((x) => x.username.toLowerCase() === username.toLowerCase())[0];
    return new Promise((resolve, reject) => {
        return user ? resolve(user) : reject('No such user!');
    });
};

const findUserById = (id) => {
    const user = getUsers((x) => x.id === +id)[0];
    return new Promise((resolve, reject) => {
        return user ? resolve(user) : reject('No such user!');
    });
};

const repository = {
    getUsers,
    addUser,
    findUserByUsername,
    findUserById,
};

module.exports = repository;
