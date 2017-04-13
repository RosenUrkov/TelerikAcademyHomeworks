SystemJS.config({
    transpiler: 'babel-plugin',
    map: {
        'babel-plugin': './node_modules/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': './node_modules/systemjs-plugin-babel/systemjs-babel-browser.js',

        'main': './scripts/main.js',
        'template': './scripts/template.handlebars',
        'loader': './scripts/template-loader.js',
        'builder': './scripts/builder.js',
        'router': './scripts/router.js',
    }
});

window.addEventListener('load', () => System.import('main'));