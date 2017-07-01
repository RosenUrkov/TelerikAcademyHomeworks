/* globals __dirname process */

const gulp = require('gulp');
const nodemon = require('gulp-nodemon');
const plumber = require('gulp-plumber');
const livereload = require('gulp-livereload');


gulp.task('develop', () => {
    livereload.listen();
    nodemon({
        script: 'bin/www',
        ext: 'js jade coffee',
        stdout: false,
    }).on('readable', () => {
        this.stdout.on('data', (chunk) => {
            if (/^Express server listening on port/.test(chunk)) {
                livereload.changed(__dirname);
            }
        });
        this.stdout.pipe(process.stdout);
        this.stderr.pipe(process.stderr);
    });
});

gulp.task('default', [
    'develop',
]);
