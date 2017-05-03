SystemJS.config({
    transpiler: 'plugin-babel',

    map: {
        'plugin-babel': '../libraries/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': '../libraries/systemjs-plugin-babel/systemjs-babel-browser.js',

        'main': '../scripts/main.js',
        'requester': '../scripts/requester.js',
        'controller': '../scripts/controller.js',
        'data-service': "../scripts/data-service.js",

        'run-tests': "./run-tests.js",
        'requester-tests': "./requester-tests.js",
        'controller-tests': "./controller-tests.js",
        'data-service-tests': "./data-service-tests.js"
    }
});

System.import('run-tests');