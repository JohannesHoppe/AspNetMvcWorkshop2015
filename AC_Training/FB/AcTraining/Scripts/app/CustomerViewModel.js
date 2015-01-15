var CustomerViewModel = function () {

    this.header = ko.observable("--- MVVM ---");
    this.hasError = ko.observable(false);
    this.color = ko.observable("red");

    this.setColor = function () {
        if (this.color() != "red") {
            this.color("red");
        } else {
            this.color("green");
        }
    };

    var self = this;
    self.header = ko.observable("MVVM!");
    self.customers = ko.observableArray([
    {
        Id: ko.observable(0),
        FirstName: ko.observable("Daten laden..."),
        LastName: ko.observable("werden geladen..."),
        DateOfBirth: ko.observable(new Date())
    }]);

    self.loadData = function () {
        $.get('/odata/Customers?$top=10')
        .success(function (data) {
            self.customers = ko.mapping.fromJS(data.value, {}, self.customers);
        });
    };

    self.getImage = function (customer) {
        return "http://www.gravatar.com/avatar/" + customer.Id() +"?d=wavatar&f=y";
    };
}