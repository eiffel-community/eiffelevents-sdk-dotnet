# Implement Events Checklist

This checklist is to follow when implementing events. 

1. 
   Create directory for event under `Events/<edition namespace directory>`, for instance **Events / Edition-Paris / EiffelActivityTriggeredEvent**.

2. The event should be `record` type, inherit and implement `EiffelEvent<TData, TMeta, TLinks>` with its edition namespace, for example  `EiffelActivityTriggeredEvent` will be as follows:


```c#
public record EiffelActivityTriggeredEvent
    : EiffelEvent<EiffelActivityTriggeredData, EiffelActivityTriggeredMeta, EiffelActivityTriggeredLinks>
```

3. Each Data, Links, and Meta properties has its own class, such as `<EventName>Data`, `<EventName>Links`, and `<EventName>Meta` respectively, e.g `EiffelActivityTriggeredData`, as long as the event itself.
4. Initialize Data, Meta, and Links properties with `new()`. Although, they are required by the protocol schemas for all events, sometimes are not applicable to some events that have no Data or Links required such as `EiffelArtifactReusedEvent` that has no required Data (internal properties) required,  `EiffelActivityTriggeredEvent,` and `EiffelAnnouncementPublishedEvent` that has no required Links  (internal properties).

*Hence, as a developer experience and a standard implementation, we chose to initialize them, as they are objects and their internal properties have their attribute validation checks as specified by the Eiffel protocol. Also to avoid enforcing users to initialize unneeded objects, as the SDK is a kind of protocol abstraction. Finally, as a maintainability perspective, to eliminate bugs born by missing some validation for future updates or the Eiffel protocol stepping, in case if it selectively initializes the property that may be not applicable for Required validation.*

```c#
/// <inheritdoc/>
public override EiffelActivityTriggeredData Data { get; init; } = new();
   
/// <inheritdoc/>
public override EiffelActivityTriggeredMeta Meta { get; init; } = new();
   
/// <inheritdoc/>
public override EiffelActivityTriggeredLinks Links { get; init; } = new();
```

5.  The event should implement `FromJson` method to pass its type to `Deserialize` method in the `EiffelEvent` class.


```c#
public override IEiffelEvent FromJson(string json)
{
            return Deserialize<EiffelActivityTriggeredEvent>(json);
}
```

5. For validating event attributes, attribute validation according to property validation mentioned by Eiffel protocol or  from datatype semantics is used such as 


```c#
 [Required(AllowEmptyStrings = false)]
 public string Name { get; init; }
```

6. For properties of custom data type [NestedObject] attribute validation should be used.


```c#
 [NestedObject]
 public EiffelEnvironmentHost Host { get; init; }
```

7. For properties of List data type [NestedList] attribute validation should be used.


```c#
[NestedList]
public List<EiffelLiveLog> LiveLogs { get; init; }
```

8. Any property of type Enum should be nullable to not set the default value of it with (0) while event creation otherwise, the default value for this property will be (null).


```c#
/// <summary>
/// How this activity will be executed.
/// </summary>
public EiffelDataExecutionType? ExecutionType { get; init; }
```

9. Docstrings should also be provided for all classes, enums, and properties according to Eiffel protocol.


```c#
/// <summary>
/// Announces that an activity has been triggered.
/// <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelActivityTriggeredEvent.md">
/// EiffelActivityTriggeredEvent
/// </a>
/// for details.
/// </summary>
public record EiffelActivityTriggeredEvent
```

