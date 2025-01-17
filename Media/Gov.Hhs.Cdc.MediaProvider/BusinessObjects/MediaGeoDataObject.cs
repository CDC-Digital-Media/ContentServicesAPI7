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

using Gov.Hhs.Cdc.Bo;

namespace Gov.Hhs.Cdc.MediaProvider
{
    [FilteredDataSet]
    public class MediaGeoDataObject : DataSourceBusinessObject, IValidationObject
    {
        [FilterSelection(CriterionType = FilterCriterionType.MultiSelect)]
        public int MediaId { get; set; }
        public int GeoNameId { get; set; }
        //public IEnumerable<int> MediaIds { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
        public string CountryCode { get; set; }
        public int ParentId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Timezone { get; set; }
        public string Admin1Code { get; set; }

        public string AsciiName { get; set; }
    }
}
