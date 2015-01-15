var CustomerViewModel = function() {

    this.header = ko.observable("MVVM!");
    this.hasError = ko.observable(false);

    this.activeError = function() {
        this.hasError(true);
    }
};