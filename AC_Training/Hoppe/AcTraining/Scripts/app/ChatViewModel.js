var ChatViewModel = function () {

    var self = this;
    var chat = $.connection.chat;
    
    self.name = ko.observable();
    self.message = ko.observable();
    self.messages = ko.observableArray();

    self.sendMessage = function() {
        chat.server.send(self.name(), self.message());
        self.message("");
    }

    chat.client.broadcastMessage = function (name, message) {

        self.messages.push({
            name: name,
            message: message
        });
    };

    $.connection.hub.start().done(function() {
        console.log("chat started!");
    });
};