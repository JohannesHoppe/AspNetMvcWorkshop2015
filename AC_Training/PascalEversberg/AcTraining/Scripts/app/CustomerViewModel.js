var CustomerViewModel = function() {
    var self = this;

    this.header = ko.observable("MVVM!"); // damit auf Eingaben sofort in der GUI reagiert wird
    this.color = ko.observable("red");
    this.hasError = ko.observable(false);

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
                self.customers = ko.mapping.fromJS(data.value, {}, self.customers); // auto data mapping
                console.log(data.value);
            })
        .error(function() {
            self.hasError(true);
        });
    };

    self.deleteCustomer = function (customer) { //Tag 5: Kunde löschen per Broadcast
        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE'
    });

    };

    self.getImage = function(customer) {
        return "http://www.gravatar.com/avatar/" + customer.Id() + "?d=wavatar&f=y";
    };

    this.setColor = function() {

        this.color("green");
    };

    var customerHub = $.connection.customerHub;

    customerHub.client.customerDeleted = function(id) {
        self.customers.remove(function(customer) {
            return customer.Id() == id;
        });
    }
};