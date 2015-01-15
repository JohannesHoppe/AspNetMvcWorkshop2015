var CustomerViewModel = function() {

    this.header = ko.observable("MVVM!"); // damit auf Eingaben sofort in der GUI reagiert wird
    this.color = ko.observable("red");
    this.hasError = ko.observable(false);

    var self = this;

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
                self.customers = ko.mapping.fromJS(data.value, {}, self.customers); // auto data mapping
                console.log(data.value);
            })
        .error(function() {
            self.hasError(true);
        });
    };

    self.getImage = function(customer) {
        return "http://www.gravatar.com/avatar/" + customer.Id() + "?d=wavatar&f=y";
    };

    this.setColor = function() {

        this.color("green");
    };
};