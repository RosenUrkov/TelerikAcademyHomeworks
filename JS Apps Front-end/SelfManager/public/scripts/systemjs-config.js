SystemJS.config({
    'transpiler': 'plugin-babel',

    'map': {
        'plugin-babel': 'libs/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': 'libs/systemjs-plugin-babel/systemjs-babel-browser.js',

        'main': '../scripts/main.js',
        'requester': '../scripts/requester.js',

        'template-data-service': '../scripts/template-data-service.js',
        'user-data-service': '../scripts/user-data-service.js',

        'template-controller': '../scripts/template-controller.js',
        'user-controller': '../scripts/user-controller.js'
    }
});

window.addEventListener('load', () => System.import('main'));