const gulp = require('gulp');
const express = require('gulp-express');
const nodemon = require('gulp-nodemon');
const eslint = require('gulp-eslint');

gulp.task('lint', () => {
    return gulp.src(['**/*.js', '!node_modules/**'])
        .pipe(eslint())
        .pipe(eslint.format())
        .pipe(eslint.failAfterError());
});

gulp.task('server', ['lint'], () => {
    return express.run('app.js');
});

gulp.task('dev', () => {
    return nodemon({
        ext: 'js',
        script: 'app.js',
    });
});
