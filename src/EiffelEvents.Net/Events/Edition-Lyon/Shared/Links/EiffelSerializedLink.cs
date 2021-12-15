using EiffelEvents.Net.Events.Core.Links;

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelSerializedLink : IEiffelSerializedLink
    {
        public string DomainId { get; init; }
        public string Type { get; init; }
        public string Target { get; init; }
    }
}