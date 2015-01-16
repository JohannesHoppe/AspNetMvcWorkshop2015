var ChatViewModel = function () {

    var self = this;

    self.name = ko.observable();
    self.message = ko.observable();
    self.messages = ko.observableArray();
    self.chatOpen = ko.observable(false);

    self.toggleChat = function() {
        self.chatOpen(!self.chatOpen());
    }

    var chatHub = $.connection.chatHub;
    self.sendMessage = function() {
        
        chatHub.server.send(self.name(), self.message());
        self.message("");
    }

    chatHub.client.broadcastMessage = function (name, message) {

        self.messages.push({
            name: name,
            message: message
        });
    }
 
    $.connection.hub.start().done(function () {
        console.log("hubs gestartet!");
    });
};