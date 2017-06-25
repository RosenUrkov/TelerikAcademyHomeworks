mocha.setup('bdd');

Promise.all([
        System.import('requester-tests'),
        System.import('controller-tests'),
        System.import('data-service-tests')
    ])
    .then(() => mocha.run());