using EiffelEvents.Net.Events.Core.Links;

namespace EiffelEvents.Net.Events.Edition_Paris.Shared
{
    public record EiffelSerializedLink : IEiffelSerializedLink
    {
        public string Type { get; init; }
        public string Target { get; init; }
    }
}