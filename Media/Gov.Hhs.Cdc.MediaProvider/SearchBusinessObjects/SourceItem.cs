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
    public class SourceItem
    {
        [FilterSelection(CriterionType = FilterCriterionType.Text, TextType=FilterTextType.StartsWith)]
        public string Code { get; set; }
        public string Acronym { get; set; }
        public string Description { get; set; }
        public string LogoSmallUrl { get; set; }
        public string LogoLargeUrl { get; set; }
        public string PrimaryUrl { get; set; }
        public string Comments { get; set; }
        public int DisplayOrdinal { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}