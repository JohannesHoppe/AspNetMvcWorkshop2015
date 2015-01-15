var CustomerViewModel = function() {
    var self = this;

    self.header = ko.observable("MVVM!");
    self.smilie = ko.observable(":-(");
    self.color = ko.observable("red");
    self.haseError = ko.observable("false");

    self.setColor = function () {
        self.color(self.color() == "green" ? "red" : "green");
    };

    self.changeText = function () {
        self.smilie(self.smilie() == ":-)" ? ":-(" : ":-)");
    };

    self.activeError = function () {
        self.hasError = true;
    };

    self.getCustomerImage = function (customer) {
        var str1 = "http://www.gravatar.com/avatar/";
        //var str2 = Math.floor((Math.random() * 100) + 1);
        var str2 = customer.Id();
        var str3 = "?d=wavatar&f=y";
        var path = str1.concat(str2.toString().concat(str3));
        //var path = "http://www.gravatar.com/avatar/1?d=wavatar&f=y";
        return path;
    };
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
            console.log(data.value);
        });
    };
};