## EiffelEvents

EiffelEvents package has Eiffel events implementation, and their validation, main events security logic. Eiffel events are categorized by their edition under namespaces in the **Events** directory, where each edition has its own namespace. For instance Edition-Paris and Edition-Lyon for Eiffel events for Paris and Lyon edition respectively.

For more details check [Implement Events Checklist](implement-event.md)

## Validation

- Events validation is declarative by using attribute validation, hence the events are considered as a domain class, which is self-contained for their definition and validation.

```c#
[NestedObject]
[Required(AllowEmptyStrings = false)]
public EiffelOutcome Outcome { get; init; }
```

- Custom call to Validate method return the validation Result object.

```c#
public Result Validate()
    
```

It is also called according to options parameter in Publish in the **EiffelEvents.RabbitMq.Client** package

```c#
public Result<T> Publish<T>(T eiffelEvent, bool validateBeforePublish = true)
...
```

- Validation Result: events validation results are reported by the returned object of `Result<T>` using **FluentResult **: An external library for  [Result](https://github.com/altmann/FluentResults) object implementation with cumulative errors.

## Exceptions

  - For exceptional situations that could not be handled like `EiffelSecurityException` or Message Brocker exceptions, an exception hierarchy is developed to handle such exceptions and raise meaningful messages.

   ```c#
public abstract class EiffelException : Exception
 {    ...
     /// <summary>
     /// Source of exception raising either EiffelLibrary or MessageBroker.
     /// </summary>
     public virtual ExceptionSource RaisedBy => ExceptionSource.EiffelLibrary;
 }
   ```

  - Library Exception

   ```c#
    public class EiffelSecurityException : EiffelException
    {
        public EiffelSecurityException(string message) : base(message)
        {
        }
    }
   ```

​    

Versioning

Security

