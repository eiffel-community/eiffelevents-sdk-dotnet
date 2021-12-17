namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelFlowContextLink : EiffelLink
    {
        public override string Type => "FLOW_CONTEXT";

        public EiffelFlowContextLink()
        {
        }

        public EiffelFlowContextLink(string target, string domainId = "") : base(target, domainId)
        {
        }
    }
}