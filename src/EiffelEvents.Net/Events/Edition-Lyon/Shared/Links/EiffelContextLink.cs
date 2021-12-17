namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelContextLink : EiffelLink
    {
        public override string Type => "CONTEXT";

        public EiffelContextLink()
        {
        }

        public EiffelContextLink(string target, string domainId = "") : base(target, domainId)
        {
            
        }
    }
}