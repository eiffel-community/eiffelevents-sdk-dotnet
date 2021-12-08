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

namespace EiffelEvents.Net.Events.Edition_Paris.Shared.Enums
{
    /// <summary>
    /// The type of Artifact location.
    /// </summary>
    public enum EiffelArtifactLocationType
    {
        /// <summary>
        /// signifies an <a href="https://www.jfrog.com/artifactory/"> Artifactory</a>
        /// </summary>
        ARTIFACTORY,
        
        /// <summary>
        /// signifies a <a href="http://www.sonatype.org/nexus/"> Nexus</a>
        /// </summary>
        NEXUS,
        
        /// <summary>
        /// signifies a plain HTTP GET request.
        /// </summary>
        PLAIN ,
        
        /// <summary>
        /// signifies other methods of retrieval.
        /// Note that using this type likely requires some foreknowledge on part of the reader in order to fetch the artifact.
        /// </summary>
        OTHER 
        
    }
}