# Fünftägiger ASP.NET MVC Workshop
Ihr Trainer: [Johannes Hoppe](http://www.haushoppe-its.de) von der [conplement AG](http://www.conplement.de/)

## Tag 5 - Agenda

1. [SignalR](#signalr)


<a name="signalr"></a>
## 1. SignalR

SignalR ist ein Framework, welche eine bidirektionale Kommunikation zwischen Client und Server ermöglicht. Je nachdem, welche Technologien vorhanden sind, verwendet SignalR Long Polling, Server-Sent Events oder Websockets. Welche Technologie verwendet wird, verhandeln Server und Client beim Verbindungsaufbau. Weiterhin überwacht das Framework den Verbindungsstatus und baut bei Abbruch eine Verbindung erneut auf. Das Framework enthält einen **Messaging Bus**, der Nachrichten zwischen Server und mehreren Clients sicher übermittelt.

### Installation

    Install-Package Microsoft.Owin -Version 3.0.0
    Install-Package Microsoft.Owin.Security -Version 3.0.0
    Install-Package Microsoft.AspNet.SignalR -Version 2.2.0
    

SignalR Beispielanwendung

    Install-Package Microsoft.AspNet.SignalR.Sample -Version 2.2.0

Jede OWIN Anwendung benötigt eine "Startup Class". In Visual Studio existiert ein entsprechendes Template:

![Owin Startup](Images/owin_startup.png)

Um SignalR zu konfigurieren, muss der Inhalt dieser Datei wie folgt lauten:

```
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AcTraining.Startup))]
namespace AcTraining
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
```

Danach kann das Beispiel unter
    /SignalR.Sample/StockTicker.html
betrachtet werden.


![SignalR Example](Images/signalr_example.png)


### Eigenes Beispiel (Chat)

Am einfachsten kann man SignalR verwendet, wenn man von "Hubs" implementiert. Die Grundlage bildet eine C#-Klasse, die von "Hub" erbt. Auf Client-Seite kann dann eine automatisch generiertes JavaScript verwendet werden, welches unter der Adresse **"/signalr/hubs"** zu finden ist.   

```
public class Chat : Hub
{
    public void Send(string name, string message)
    {
        Clients.All.broadcastMessage(name, message);
    }
}
```

Die BundleConfig muss erneut angepasst werden:

```
bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery.signalR-{version}.js" // NEU
            // ... weitere
            );

```

Die Adresse **"/signalr/hubs"** muss leider manuell hinzugefügt werden:

```
@Scripts.Render("~/bundles/jquery")
<script src="~/signalr/hubs"></script>

```

Anschließend steht die Methode `send` im Client zur Verfügung:

```
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
```

### Aufgabe: Implementiere eine Oberfläche für dieses View-Model, Beispiel:

![SignalR Chat](Images/signalr_chat.png)


<hr>

_&copy; 2015, Johannes Hoppe_
