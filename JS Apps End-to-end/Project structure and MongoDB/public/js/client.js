/* globals $ io */

$('document').ready(() => {
    $('body').on('click', (event) => {
        // eslint-disable-next-line
        const color = `rgb(${Math.random() * 255}, ${Math.random() * 255}, ${Math.random() * 255})`;
        $('#home').css('color', color);
    });

    // trying out
    const socket = io.connect('http://localhost:1234');
    socket.emit('server', { message: 'Hello to you to!' });
    socket.on('client', (data) => {
        console.log(data);
    });
    socket.on('all', console.log);

    // chat
    $('#chat').submit((event) => {
        socket.emit('chat message', $('#message').val());
        $('#message').val('');

        event.preventDefault();
    });

    socket.on('chat message', (message) => {
        $('#messages').append($('<li>').text(message));
    });

    $('#message').on('focusin', () => {
        socket.emit('typing message', 'typing...');
    });

    $('#message').on('focusout', () => {
        socket.emit('stop typing');
    });

    socket.on('typing message', (typingMessage) => {
        $('#messages').append($('<li>').addClass('typing').text(typingMessage));
    });

    socket.on('stop typing', () => {
        $('.typing').remove();
    });
});
