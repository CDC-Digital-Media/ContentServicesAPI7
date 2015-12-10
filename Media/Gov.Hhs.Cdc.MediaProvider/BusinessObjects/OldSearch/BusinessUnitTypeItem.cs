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

using Gov.Hhs.Cdc.Bo;

namespace Gov.Hhs.Cdc.MediaProvider
{
    [FilteredDataSet]
    public class BusinessUnitTypeItem : DefaultableBusinessObject
    {
        public int DisplayOrdinal { get; set; }

        [FilterSelection(Code = "Description", CriterionType = FilterCriterionType.Text, TextType = FilterTextType.Contains)]
        public string Description { get; set; }
        public string TypeCode { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
