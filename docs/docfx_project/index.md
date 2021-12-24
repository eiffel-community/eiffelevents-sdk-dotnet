# EiffelEvents .NET SDK

**EiffelEvents .NET SDK** is a .NET implementation for Eiffel events and  Assisted publishing service, which acts as an intermediate between the event author (publisher) and the Message Broker (RabbitMQ for instance).

EiffelEvents .NET SDK features include:

- Implement Eiffel events vocabularies as described in [Eiffel protocol](https://github.com/eiffel-community/eiffel) 
- Validate events' schema regarding target event’s version.
- Sign and verify events' signatures.
- Serialization/deserialization of events.
- Provide  APIs for users to publish, subscribe, acknowledge, reject and unsubscribe for strongly-typed Eiffel events to RabbitMQ.

It consists of two packages:

1. **EiffelEvents.Net** for events' implementation, 
2. **EiffelEvents.RabbitMq.Client** for assisted publishing to RabbitMQ.

## Design Specifications

For detailed API description please check [API Documentation](api/index.md), for SDK architecture and design specifications please refer to [Articles](articles/index.md).

## Requirements For Development ##

- .NET 6 ([Installation](https://dotnet.microsoft.com/download/dotnet/6.0)).
- C# (9)

## Dependencies

- **RabbitMQ.Client 6.2.2**:  An external [library](https://github.com/rabbitmq/rabbitmq-dotnet-client) RabbitMQ communication, NuGet [link](https://www.nuget.org/packages/RabbitMQ.Client/).
- **FluentResult 2.5.0**: An external [library](https://github.com/altmann/FluentResults) for Result object implementation, NuGet [link](https://www.nuget.org/packages/FluentResults/).
- **Newtonsoft.Json 13.0.1**:  An external [library](https://github.com/JamesNK/Newtonsoft.Json) for serialization/deserialization support, NuGet [link](https://www.nuget.org/packages/Newtonsoft.Json).
- **[DocFX](https://dotnet.github.io/docfx/index.html)** documentation generation tool.
