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

namespace Gov.Hhs.Cdc.MediaProvider
{
    public abstract class MediaAddress
    {
        public string MediaTypeCode { get; set; }
        public string SourceTable { get; set; } //i.e., Media
        public int SourceId { get; set; }   //i.e., MediaId
        
        public string SourceCode { get; set; }
        public string DomainName { get; set; }
        public bool IsArchived { get; set; }

        //These items are used by MediaValidator
        public bool AddressIsAlreadyPersisted { get; set; }
        public bool AddressIsAlreadyPersistedWithSameExtractionCriteria { get; set; }

        public int ExistingMediaId { get; set; }
        public virtual string GetUniqueKey() { return null; }
        public HtmlPreferences MediaPreferences { get; set; }

        public MediaObject MediaObject { get; set; }

        //public PreferencesSet Preferences { get; set; }
    }
}
