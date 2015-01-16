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
        $.get('/odata/Customers2?$top=10')
        .success(function (data) {
            self.customers = ko.mapping.fromJS(data.value, {}, self.customers);
        });
    };

    self.deleteCustomer = function (customer) {
        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE'
        });
    };

    self.getImage = function (customer) {
        return "http://www.gravatar.com/avatar/" + customer.Id() + "?d=wavatar&f=y";
    };
    
    $.connection.hub.start().done(function () {
        console.log("customer hub started!");
    });
    
    var customerHub = $.connection.customerHub;
    customerHub.client.customerDeleted = function (id) {
        self.customers.remove(function (customer) {
            return customer.Id() == id;
        });
    };
}