SystemJS.config({
    transpiler: 'plugin-babel',

    map: {
        'plugin-babel': '../bower_components/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': '../bower_components/systemjs-plugin-babel/systemjs-babel-browser.js',

        'jquery': './bower_components/jquery/dist/jquery.min.js',
        'handlebars': '../bower_components/handlebars/handlebars.min.js',
        'sammy': '../bower_components/sammy/lib/sammy.js',

        'main': './scripts/main.js',
        'requester': './scripts/requester.js',
        'controller': './scripts/controller.js',
        'data-service': "./scripts/data-service.js"
    }
});

window.addEventListener('load', () => SystemJS.import('main'));