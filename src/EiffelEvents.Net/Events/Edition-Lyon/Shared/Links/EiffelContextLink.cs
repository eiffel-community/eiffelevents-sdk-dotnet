namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public record EiffelContextLink : EiffelLink
    {
        public override string Type { get; init; } = "CONTEXT";
        
        // public EiffelContextLink(string target, string domainId) : base(target, domainId)
        // {
        // }
        //
        // public EiffelContextLink()
        // {
        //     
        // }
    }
}