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
    
    self.loadData = function () {
        $.get('/odata/Customers?$top=10')
        .success(function (data) {
            self.customers = ko.mapping.fromJS(data.value, {}, self.customers);
            console.log(data.value);
        });
    };

}