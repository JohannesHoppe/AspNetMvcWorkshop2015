var ChatViewModel = function () {

    var self = this;  // this kann verändert werden, z.B. durch "call" - das wird in jQuery intensiv betrieben - so ist es sicherer !!!
    
    self.name = ko.observable();
    self.message = ko.observable();
    self.messages = ko.observableArray();
    
// :-)
    var chatHub = $.connection.chatHub;

    self.sendMessage = function() {
        chatHub.server.send(self.name(), self.message());
        self.message("");
    };

    chatHub.client.broadcastMessage = function (name, message) {
        //console.log(name, message);
        self.messages.push({
            name: name,
            message: message
        });
    };

    //chatHub.client.XXXBeliebigXXX = function (name, message) {
    //    console.log("XXX");
    //};

    $.connection.hub.start().done(function () {
        console.log("hubs gestartet!");
    });

}