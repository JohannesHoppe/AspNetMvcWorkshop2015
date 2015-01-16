var ChatViewModel = function () {

    var self = this;

    self.name = ko.observable();
    self.message = ko.observable();
    self.messages = ko.observableArray();

    var chatHub = $.connection.chatHub; //bezieht sich trotz Kleinschreibung (js!) auf die Klasse ChatHub
                                        //$.connection kommt aus dem generierten Proxy
    self.sendMessage = function() {
        chatHub.server.send(self.name(), self.message());
        self.message("");
    }

    chatHub.client.broadcastMessage = function(name, message) {
        self.messages.push({
            name: name,
            message: message
        });
    }

    $.connection.hub.start().done(function () { //startet SignalR
        console.log("hubs gestartet!");
    });
};