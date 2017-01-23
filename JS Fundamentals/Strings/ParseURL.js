function solve(args) {
    var URL = args[0],
        parts = [],
        protocol = '',
        server = '',
        resource = '',
        regex = /((https?):\/\/)?([A-z0-9.]+)(\/.*)?/;

    parts = URL.match(regex);
    protocol = parts[2];
    server = parts[3];
    resource = parts[4];

    console.log(`protocol: ${protocol}`);
    console.log(`server: ${server}`);
    console.log(`resource: ${resource}`);
}