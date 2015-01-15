module.exports = function(config) {
    config.set({

        basePath: 'AC_Training/Hoppe/AcTraining/Scripts',
        frameworks: ['jasmine', 'requirejs'],
        files: [
            'require.config.karma.js',
            { pattern: '**/*.js', included: false }
        ],
        browsers: ['Chrome']
    });
};
