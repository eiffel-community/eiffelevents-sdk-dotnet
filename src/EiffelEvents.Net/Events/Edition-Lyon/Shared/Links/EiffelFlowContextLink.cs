namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelFlowContextLink : EiffelLink
    {
        public override string Type { get; init; } = "FLOW_CONTEXT";

        // public EiffelFlowContextLink(string target, string domainId) : base(target, domainId)
        // {
        // }
        //
        // public EiffelFlowContextLink()
        // {
        // }
    }
}