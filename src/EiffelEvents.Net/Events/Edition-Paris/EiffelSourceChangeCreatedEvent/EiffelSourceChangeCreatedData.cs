//    Copyright (c) 2021 ICT Cube, doWhile, and Eiffel Community collaborators.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Data;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelSourceChangeCreatedData : EiffelData
    {
        /// <summary>
        /// The author of the change.
        /// </summary>
        [NestedObject]
        public EiffelSourceChangeAuthor Author { get; init; }

        /// <summary>
        /// A summary of the change.
        /// </summary>
        [NestedObject]
        public EiffelSourceChange Change { get; init; }

        /// <summary>
        /// Identifier of a Git change.
        /// </summary>
        [NestedObject]
        public EiffelSourceChangeGitIdentifier GitIdentifier { get; init; }

        /// <summary>
        /// Identifier of a Subversion change.
        /// </summary>
        [NestedObject]
        public EiffelSourceChangeSvnIdentifier SvnIdentifier { get; init; }

        /// <summary>
        /// Identifier of a composite ClearCase change – in other words, not single file commit,
        /// but analogous of repository-wide commits of e.g. SVN or Git.
        /// </summary>
        [NestedObject]
        public EiffelSourceChangeCcCompositeIdentifier CcCompositeIdentifier { get; init; }

        /// <summary>
        /// Identifier of a Mercurial change.
        /// </summary>
        [NestedObject]
        public EiffelSourceChangeHgIdentifier HgIdentifier { get; init; }
    }
}