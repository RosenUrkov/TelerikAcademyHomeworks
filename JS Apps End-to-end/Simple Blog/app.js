const server = require('./server');

// eslint-disable-next-line
const port = process.env.PORT || 1234;
server.listen(port, () => console.log(`Server running at ${port}...`));
