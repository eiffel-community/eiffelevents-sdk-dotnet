using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public abstract record EiffelLink
    {
        /// <summary>
        /// Link type
        /// </summary>
        public abstract string Type { get; init; }

        /// <summary>
        /// UUID corresponding to the meta.id of the target event, on string format
        /// </summary>
        [ValidGuid(IsMultiple = false)]
        [Required(AllowEmptyStrings = false)]
        public string Target { get; init; }

        /// <summary>
        /// Optionally the id of the domain where the target event was published (i.e. its meta.source.domainId member).
        /// The absence of a domain id means that the target event was sent in, or can at least be retrieved from,
        /// the same domain as the current event.
        /// </summary>
        public string DomainId { get; init; }

        // public EiffelLink(string target, string domainId)
        // {
        //     Target = target;
        //     DomainId = domainId;
        // }
        //
        // public EiffelLink()
        // {
        // }
    }
}