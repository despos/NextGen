PURPOSE
===
This project demonstrates how to set up **MementoFX** in the context of an ASP.NET MVC (classic) application. It also shows how to perform 
basic CRUD-style operations via _sagas_, _commands_ and _events_. **ASP.NET SignalR** is used to refresh the user interface and HTML forms are posted using JavaScript and jQuery. Functionally, the demo implements the following actions:

1) Create a new task
2) Edit an existing task
3) Delete an existing task

The sample application follows the CQRS pattern and uses distinct data sources for the command and the query stack. In particular, it uses **MongoDB** as the event store and a plain SQL Server (any version) for the read model.

DETAILS
===
This specific step shows 
1) How to (try to) regenerate the read model
2) How to extract the history of a given todo-item