namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelCauseLink : EiffelLink
    {
        public override string Type { get; init; } = "CAUSE";

        // public EiffelCauseLink(string target, string domainId) : base(target, domainId)
        // {
        // }
        //
        // public EiffelCauseLink()
        // {
        // }
    }
}