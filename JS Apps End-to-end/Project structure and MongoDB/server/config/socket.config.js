const config = (app) => {
    // eslint-disable-next-line
    const server = require('http').Server(app);
    const io = require('socket.io')(server);

    io.on('connection', (socket) => {
        // trying out
        socket.emit('client', { message: 'hello' });
        socket.on('server', (data) => {
            console.log(data);
        });

        io.emit('all', { message: 'Big Brother' });

        // chat
        socket.broadcast.emit('chat message', 'connected!');

        socket.on('chat message', (message) => {
            io.emit('chat message', message);
        });

        socket.on('typing message', (typingMessage) => {
            io.emit('typing message', typingMessage);
        });

        socket.on('stop typing', () => {
            io.emit('stop typing');
        });

        socket.on('disconnect', () => {
            socket.broadcast.emit('chat message', 'disconnected!');
        });
    });

    return server;
};

module.exports = config;
