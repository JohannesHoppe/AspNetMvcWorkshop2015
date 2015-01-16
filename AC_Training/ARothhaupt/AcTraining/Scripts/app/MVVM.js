var CustomerViewModel = function () {

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

    self.deleteCustomer = function() {

        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE'
        });
    }

    self.getCustomerImage = function(customer) {
        var str1 = "http://www.gravatar.com/avatar/";
        var str2 = customer.Id();
        var str3 = "?d=wavatar&f=y";
        var path = str1.concat(str2.toString().concat(str3));
        //var path = "http://www.gravatar.com/avatar/1?d=wavatar&f=y";
        return path;
    };

    self.image = function (data) {

        return data && data.Id ?
            "http://www.gravatar.com/avatar/" + data.Id() + "?d=wavatar&f=y" :
            "http://www.gravatar.com/avatar/?d=mm&f=y";
    };
};