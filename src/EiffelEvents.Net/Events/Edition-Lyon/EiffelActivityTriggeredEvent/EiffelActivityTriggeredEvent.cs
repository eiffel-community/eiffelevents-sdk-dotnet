using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Lyon.Shared;

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
            return Deserialize<EiffelActivityTriggeredEvent>(json);
        }
    }
}