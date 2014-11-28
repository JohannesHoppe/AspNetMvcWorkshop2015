# Fragen zur Vorbereitung

MVC Pattern – Was ist ein Model? Was ist ein View? Was ist ein Controller? Was ist ein ViewModel?
Was ist die Razor-Engine?
Was ist Routing?

# Agenda


# Tag 1 - ASP.NET Web API
1. Anlegen von DTOs / POCOs (Geschäftsobjekte)
2. IoC, Dependency Injection
3. Einrichten von Entity Framework, Code First – Besprechung: Mockbarer Context (DbContext)
4. Repository (CRUD) – Tests!
5. Web API Controllers 
6. REST & Hypermedia (kurz angerissen)

    Technologien: Autofac, MSpec, Moq, EF, Web API, OData


## Tag 2 - ASP.NET MVC
1. ASP.NET MVC Routing Bundling, ggf. mit Transformation
2. Render Section
3. ActionFilter
4. OData (IQueryable)
5. Daten anzeigen per Grid und Chart


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

## Tag 5 - SignalR

1. SignalR

Beispiel:
```
    $(#button).hide(); // Prozedual
    <button data-bind="visible: !data.length">:-)</button> // Bindings (MVVM)
```






## Tools

* Eigener Laptop                              
* Visual Studio 2012 Update 4
* Resharper 8 (ggf. Trial)
* GitExtensions https://code.google.com/p/gitextensions/


## Online

https://github.com/JohannesHoppe/AspNetMvcWorkshop2015