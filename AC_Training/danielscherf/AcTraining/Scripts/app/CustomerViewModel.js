var CustomerViewModel = function () {

    //this.header = ko.observable("MVVM!");
    //this.color = ko.observable("red");
    this.hasError = ko.observable(false);


    var self = this;

    //self.header = ko.observable("MVVM!");
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
            })
        .error(function () {
            self.hasError(true);
        });
    };

    self.getImageData = function (customer) {
        var path = "http://www.gravatar.com/avatar/";
        var path2 = "?d=wavatar&f=y";
        var id = customer.Id();
        var url = path + id + path2;
        return url;
    }

    this.activeError = function () {
        this.hasError(true);
    }
}