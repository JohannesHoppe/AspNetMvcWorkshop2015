var CustomerViewModel = function() {

    var self = this;

    self.header = ko.observable("MVVM!");
    self.customers = ko.observableArray();
    self.hasError = ko.observable(false);
    self.isSyncing = ko.observable(false);

    self.loadData = function() {

        $.get('/odata/Customers2?$top=10')
            .success(function(data) {
                self.customers = ko.mapping.fromJS(data.value, {}, self.customers);
            })
            .error(function() {
                self.hasError(true);
            }).done(function() {
                self.isSyncing(false);
            });

        self.isSyncing(true);
    };

    self.deleteCustomer = function(customer) {

        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE'
        });
    }

    self.image = function(data) {

        return data && data.Id ?
            "http://www.gravatar.com/avatar/" + data.Id() + "?d=wavatar&f=y" :
            "http://www.gravatar.com/avatar/?d=mm&f=y";
    };

    var customerHub = $.connection.customerHub;
    customerHub.client.customerDeleted = function (id) {

        self.customers.remove(function(customer) {
            return customer.Id() == id;
        });
    }

    $.connection.hub.start().done(function () {
        console.log("hubs gestartet!");
    });
};