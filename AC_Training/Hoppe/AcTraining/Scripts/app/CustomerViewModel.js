var CustomerViewModel = function() {

    var self = this;

    self.header = ko.observable("MVVM!");
    self.customers = ko.observableArray();
    self.hasError = ko.observable(false);

    self.loadData = function() {

        $.get('/odata/Customers2?$top=10')
            .success(function(data) {
                self.customers = ko.mapping.fromJS(data.value, {}, self.customers);
            })
            .error(function() {
                self.hasError(true);
            });
    };

    self.image = function (data) {

        return data && data.Id ?
            "http://www.gravatar.com/avatar/" + data.Id() + "?d=wavatar&f=y" :
            "http://www.gravatar.com/avatar/?d=mm&f=y";
    };

    self.deleteCustomer = function(customer) {

        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE',
        });
    }

    var customerHub = jQuery.connection.customerHub;

    customerHub.client.customerDeleted = function (customerId) {

        self.customers.remove(function(customer) {
            return customer.Id() == customerId;
        });
    };

    $.connection.hub.start().done(function () {
        console.log("customer connection started!");
    });

};