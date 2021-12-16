using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Lyon.Shared;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    public record EiffelActivityTriggeredEvent
        : EiffelEvent<EiffelActivityTriggeredData, EiffelActivityTriggeredMeta, EiffelActivityTriggeredLinks>
    {
        /// <inheritdoc/>
        [Required]
        public override EiffelActivityTriggeredData Data { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelActivityTriggeredMeta Meta { get; init; }

        /// <inheritdoc/>
        public override EiffelActivityTriggeredLinks Links { get; init; }

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelActivityTriggeredEvent>(json, MapLink);
        }

        private object MapLink(string linkName, List<EiffelSerializedLink> serializedLinks)
        {
            return linkName switch
            {
                nameof(Links.Cause) =>
                    serializedLinks.Select(x => new EiffelCauseLink
                    {
                        Target = x.Target,
                        DomainId = x.DomainId
                    }).ToList(),
                
                nameof(Links.Context) =>
                    serializedLinks.Select(x => new EiffelContextLink
                    {
                        Target = x.Target,
                        DomainId = x.DomainId
                    }).FirstOrDefault(),
                
                nameof(Links.FlowContext) =>
                    serializedLinks.Select(x => new EiffelFlowContextLink
                    {
                        Target = x.Target,
                        DomainId = x.DomainId
                    }).ToList(),
                
                _ => null
            };
        }
    }
}