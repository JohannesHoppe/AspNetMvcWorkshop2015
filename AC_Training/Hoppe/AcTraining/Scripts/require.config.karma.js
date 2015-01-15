requirejs.config({
    
    baseUrl: '/base', // !!!
    
    paths: {
        'jquery': 'jquery-1.10.2',
        'kendo': 'kendo/kendo.all.min'
    },
    shim: {
        kendo: {
            deps: ['jquery']
        }
    },
    deps: (function() {

        var allTestFiles = [];

        Object.keys(window.__karma__.files).forEach(function(file) {
          if (/Spec\.js$/.test(file)) {
            allTestFiles.push(file.replace(/^\/base\//, '').replace(/\.js$/, ''));
          }
        });
            
        return allTestFiles;
    })(),
    callback: window.__karma__.start
});

