﻿// Copyright [2015] [Centers for Disease Control and Prevention] 
// Licensed under the CDC Custom Open Source License 1 (the 'License'); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at
// 
//   http://t.cdc.gov/O4O
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Gov.Hhs.Cdc.Api
{
    [DataContract(Name = "tag")]
    public sealed class SerialTag
    {
        [DataMember(Order = 1)]
        public int id { get; set; }

        [DataMember(Order = 2)]
        public string name { get; set; }

        [DataMember(Order = 3)]
        public string language { get; set; }

        [DataMember(Order = 4)]
        public string type { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0} {1}:{2}", id, type, name);
        }
        
    }
}
