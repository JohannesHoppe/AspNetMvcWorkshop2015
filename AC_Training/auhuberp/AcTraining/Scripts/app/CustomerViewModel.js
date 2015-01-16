var CustomerViewModel = function() {
    this.header = ko.observable("MVVM!");
    

    this.color = ko.observable("red");
    this.setColor = function() {
        this.color("green");
    };
        
    var self = this;
    
    self.customers = ko.observableArray([
    {
        Id: ko.observable(0),
        FirstName: ko.observable("Daten laden..."),
        LastName: ko.observable("werden geladen..."),
        DateOfBirth: ko.observable(new Date())
    }]);

    self.getImage = function(data) {
        return "http://www.gravatar.com/avatar/"+data.Id()+"?d=wavatar&f=y";
    };
    
    self.deleteCustomer = function(customer) {
        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE'
        });
    };
    
    self.loadData = function () {
        $.get('/odata/Customers2?$top=10')
        .success(function (data) {
            self.customers = ko.mapping.fromJS(data.value, {}, self.customers);
            console.log(data.value);
        });
    };

    var customerHub = $.connection.customerHub;
    
    customerHub.client.customerDeleted = function(id) {
        self.customers.remove(function(customer) {
            return customer.Id() == id;
        });
    };

    $.connection.hub.start().done(function () {
        console.log("hubs gestartet!");
    });
    

}