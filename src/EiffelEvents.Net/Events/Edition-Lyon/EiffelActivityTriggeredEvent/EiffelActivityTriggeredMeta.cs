using EiffelEvents.Net.Events.Edition_Lyon.Shared;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    public record EiffelActivityTriggeredMeta : EiffelSharedMeta
    {
        public override string Type { get; init; } = nameof(EiffelActivityTriggeredEvent);
        public override string Version { get; init; } = "4.1.0";
    }
}