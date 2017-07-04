const gulp = require('gulp');
const gulpsync = require('gulp-sync')(gulp);
const nodemon = require('gulp-nodemon');
const babel = require('gulp-babel');
const express = require('gulp-express');
const eslint = require('gulp-eslint');
const clean = require('gulp-clean');

gulp.task('compile:transpile', () => {
    return gulp.src(['**/*.js', '!node_modules/**', '!gulpfile.js'])
        .pipe(babel({
            presets: ['es2015'],
        }))
        .pipe(gulp.dest('./es2015'));
});

gulp.task('compile:move', () => {
    return gulp.src(['**/*.pug', '**/database/db.json'])
        .pipe(gulp.dest('./es2015'));
});

gulp.task('compile:lint', () => {
    return gulp.src(['**/*.js', '!node_modules/**'])
        .pipe(eslint())
        .pipe(eslint.format())
        .pipe(eslint.failAfterError());
});

gulp.task('compile:clean', () => {
    return gulp.src('./es2015', { read: false })
        .pipe(clean());
});

gulp.task('compile', gulpsync.sync([
    'compile:clean',
    'compile:lint',
    'compile:transpile',
    'compile:move',
]));

gulp.task('server', ['compile'], () => {
    return express.run(['./es2015/app.js']);
});

gulp.task('dev', () => {
    return nodemon({
        ext: 'js',
        script: 'app.js',
    });
});
