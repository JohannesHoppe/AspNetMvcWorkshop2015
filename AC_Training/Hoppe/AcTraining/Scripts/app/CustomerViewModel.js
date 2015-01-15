var CustomerViewModel = function() {

    this.header = ko.observable("MVVM!");
    this.color = ko.observable("red");
    this.hasError = ko.observable(false);

    this.activeError = function() {
        this.hasError(true);
    }

    this.setColor = function () {
        this.color(this.color() == "green" ? "red" : "green");
    };
};