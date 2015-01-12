# Fragen zur Vorbereitung

1. MVC Pattern – Was ist ein Model? Was ist ein View? Was ist ein Controller? Was ist ein ViewModel?
2. Was ist die Razor-Engine?
3. Was ist Knockout.js?
4. Was ist Routing?

# Agenda


# Tag 1 - ASP.NET Web API & C# Unit Testing
1. Anlegen von DTOs / POCOs (Geschäftsobjekte)
2. IoC, Dependency Injection
3. Einrichten von Entity Framework, Code First – Besprechung: Mockbarer Context (DbContext)
4. Repository (CRUD) – Tests (State Driven Tests)
5. Web API Controllers 
6. REST & Hypermedia (kurz angerissen)

    Technologien: ASP.NET WebApi, Autofac, MSpec, Moq, EF, Web API


## Tag 2 - ASP.NET MVC
1. ASP.NET MVC Routing Bundling, ggf. mit Transformation
2. Render Section
3. ActionFilter
4. OData (IQueryable)
5. Daten anzeigen per Grid und Chart

    Technologien: ASP.NET MVC, OData, ggf. Kendo UI 


## Tag 3 - JavaScript

1. Best Practices – häufige Fehler vermeiden, bewährtes verwenden a. Vermeiden von globals, eval
2. Modularer Code
2. Patterns: MVVM, MVC
3. Daten holen per Ajax (REST)
4. Require.js (kurz angerissen)


## Tag 4 - Knockout.js

1. Bindings, ViewModel, Mapping
2. Logik integrieren
3. Integrations-Probleme jQuery / jQUery UI und Knockout
    Lösungansätze:
    a) ohne $(document).ready arbeiten
    b) Knockout plugins

    --> Ziel: grid integrieren

Beispiel:
```
    $(#button).hide(); // Prozedual
    <button data-bind="visible: !data.length">:-)</button> // Bindings (MVVM)
```

## Tag 5 - SignalR & JavaScript Unit Testing

1. SignalR
2. JavaScript Unit-Tests (Behaviour Driven Tests)

    Technologien: node.js /npm, Karma Testrunner, Jasmine





## Tools

* Eigener Laptop                              
* Visual Studio 2012 Update 4
* Resharper 8 (ggf. Trial)
* GitExtensions https://code.google.com/p/gitextensions/


## Online

https://github.com/JohannesHoppe/AspNetMvcWorkshop2015