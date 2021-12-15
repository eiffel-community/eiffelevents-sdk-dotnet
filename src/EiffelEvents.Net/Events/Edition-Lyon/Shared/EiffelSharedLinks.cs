using System.Collections.Generic;
using EiffelEvents.Net.Events.Core.Links;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared
{
    public record EiffelSharedLinks : EiffelLinks
    {
        /// <summary>
        /// Identifies a cause of the event occurring.
        /// Legal targets: Any
        /// </summary>
        [NestedList]
        public List<EiffelCauseLink> Cause { get; init; }

        /// <summary>
        /// Identifies the activity or test suite of which this event constitutes a part.
        /// Legal targets: EiffelActivityTriggeredEvent, EiffelTestSuiteStartedEvent
        /// </summary>
        [NestedObject]
        public EiffelContextLink Context { get; init; }

        /// <summary>
        /// Identifies the flow context of the event.
        /// Legal targets: EiffelFlowContextDefinedEvent
        /// </summary>
        [NestedList]
        public List<EiffelFlowContextLink> FlowContext { get; init; }
    }
}