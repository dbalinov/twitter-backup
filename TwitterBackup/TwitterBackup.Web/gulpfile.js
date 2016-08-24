var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('sass', function () {
    return gulp.src('./Content/Site.scss')
        .pipe(sass.sync().on('error', sass.logError))
        .pipe(gulp.dest('./Content/'));
});

gulp.task('sass:watch', function () {
    gulp.watch('./Content/Site.scss', ['sass']);
});

