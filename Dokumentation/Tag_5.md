# Fünftägiger ASP.NET MVC Workshop
Ihr Trainer: [Johannes Hoppe](http://www.haushoppe-its.de) von der [conplement AG](http://www.conplement.de/)

## Tag 5 - Agenda

1. [SignalR](#signalr)
    1. [Installation und Beispielanwendung](#installation)
    2. [SignalR Chat](#chat)
    3. [Kunde löschen mit Broadcast](#customer)
2. JavaScript Unit-Tests


<a name="signalr"></a>
## 1. SignalR

SignalR ist ein Framework, welche eine bidirektionale Kommunikation zwischen Client und Server ermöglicht. Je nachdem, welche Technologien vorhanden sind, verwendet SignalR Long Polling, Server-Sent Events oder Websockets. Welche Technologie verwendet wird, verhandeln Server und Client beim Verbindungsaufbau. Weiterhin überwacht das Framework den Verbindungsstatus und baut bei Abbruch eine Verbindung erneut auf. Das Framework enthält einen **Messaging Bus**, der Nachrichten zwischen Server und mehreren Clients sicher übermittelt.

<a name="installation"></a>
### 1.1 Installation und Beispielanwendung

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



<a name="chat"></a>
### SignalR Chat

Am einfachsten kann man SignalR verwendet, wenn man von "Hubs" implementiert. Die Grundlage bildet eine C#-Klasse, die von "Hub" erbt. Auf Client-Seite kann dann eine automatisch generiertes JavaScript verwendet werden, welches unter der Adresse **"/signalr/hubs"** zu finden ist.   

```
public class ChatHub : Hub
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
    var chatHub = $.connection.chatHub;
    
    self.name = ko.observable();
    self.message = ko.observable();
    self.messages = ko.observableArray();

    self.sendMessage = function() {
        chatHub.server.send(self.name(), self.message());
        self.message("");
    }

    chatHub.client.broadcastMessage = function (name, message) {

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



<a name="customer"></a>
### Kunde löschen mit Broadcast

Im Hauptverzeichnis des Projektes befindet sich ein vorbereiteter OData-Controller ``Customers2Controller`.
Dieser implementiert alle CRUD Operationen der entsprechend der URL Konventionen. Es ist z.B. mit folgenden Befehl möglich, einen Datensatz zu löschen:

```
    self.deleteCustomer = function(customer) {
    
        $.ajax({
            url: '/odata/Customers2(' + customer.Id() + ')',
            type: 'DELETE',
        });
    }

```

Wenn nur Daten vom Server zu Client gesendet werden sollen, muss kein Code im Hub implementiert werden:

```
public class CustomerHub : Hub
{
}
````

Es können beliebige JavaScript Befehle mittels des "dynamic" Datentyps aufgerufen werden:

```
public class Customers2Controller : ODataController
{
    // DELETE: odata/Customers2(5)
    public IHttpActionResult Delete([FromODataUri] int key)
    {
        /* [...] */

        var context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
        context.Clients.All.customerDeleted(key);

        /* [...] */
    }
}

```

Auch auf dieses Event kann man sich registrieren:
```
var customerHub = jQuery.connection.customerHub;

customerHub.client.customerDeleted = function (customerId) {

    self.customers.remove(function(customer) {
        return customer.Id() == customerId;
    });
};

$.connection.hub.start().done(function () {
    console.log("customer connection started!");
});
```

### Aufgabe: Implementiere eine Oberfläche, welche bei Klick auf dem Löschen-Button den Datensatz entfernt. Der Eintrag soll auf allen verbundenen Clients sofort entfernt werden.

![SignalR Chat](Images/signalr_customer.png)


Mehr Informationen zu SignalR finden sich in der Dokumentation auf [http://www.asp.net/signalr](http://www.asp.net/signalr).


<hr>

_&copy; 2015, Johannes Hoppe_
