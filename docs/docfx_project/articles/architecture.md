This section describes the EiffelEvents.NET SDK system architecture and main design decisions.

## High-Level architecture

EiffelEvents.NET SDK high-level architecture consists of two main parts: **EiffelEvents** vocabulary implementation and the assisted publishing client to a message broker, RabbitMQ called **EiffelEvents.Clients.RabbitMq**. The two parts are separated .NET class library projects which could be packaged and published individually so users may use the **EiffelEvents** package for strongly-typed validated Eiffel events alone. 



![](../images/sdk-structure.svg)
