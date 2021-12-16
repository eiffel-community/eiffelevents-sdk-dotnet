namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelContextLink : EiffelLink
    {
        public override string Type { get; init; } = "CONTEXT";
    }
}