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
using System.Text;

using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Gov.Hhs.Cdc.Api
{
    [DataContract(Name = "resultSet")]
    public sealed class SerialResultSet
    {
        public SerialResultSet()
        {
            //isComplete = true;
        }

        [DataMember(Name = "id", Order = 1, EmitDefaultValue = true)]
        public string id { get; set; }                  //Result Set ID

        //[DataMember(Name = "isComplete", Order = 2, EmitDefaultValue = true)]
        //public bool isComplete { get; set; }            //Complete Flag

        //[DataMember(Name = "duration", Order = 3, EmitDefaultValue = true)]
        //public double duration { get; set; }            //Duration

        //[DataMember(Name = "timestamp", Order = 4, EmitDefaultValue = true)]
        //public string timestamp { get; set; }            //Duration
    }
}
