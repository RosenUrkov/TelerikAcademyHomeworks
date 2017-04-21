SystemJS.config({
    transpiler: 'plugin-babel',

    map: {
        'plugin-babel': '../systemjs/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': '../systemjs/systemjs-plugin-babel/systemjs-babel-browser.js',

        'main': './scripts/main.js',
        'requester': './scripts/requester.js',
        'controller': './scripts/controller.js',
        'data-service': './scripts/data-service.js',
    }
});

window.addEventListener('load', () => System.import('main'));