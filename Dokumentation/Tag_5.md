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


<hr>

_&copy; 2015, Johannes Hoppe_
