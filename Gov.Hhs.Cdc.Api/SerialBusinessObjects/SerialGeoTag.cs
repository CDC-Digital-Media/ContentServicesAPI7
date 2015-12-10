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

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Gov.Hhs.Cdc.Api
{
    [DataContract(Name = "geoTag")]
    public class SerialGeoTag : ISerialLocation
    {
        [DataMember(Order = 1)]
        public string name { get; set; }

        [DataMember(Order = 2)]
        public string countryCode { get; set; }

        [DataMember(Order = 3)]
        public int? geoNameId { get; set; }

        [DataMember(Order = 4)]
        public int? parentId { get; set; }

        [DataMember(Order = 5)]
        public double? latitude { get; set; }

        [DataMember(Order = 6)]
        public double? longitude { get; set; }

        [DataMember(Order = 7)]
        public string timezone { get; set; }

        [DataMember(Order = 8)]
        public string admin1Code { get; set; }
    }
}
