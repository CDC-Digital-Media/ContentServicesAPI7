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

namespace Gov.Hhs.Cdc.Media.Api
{
    public class Criteria
    {
        public string[] MediaTypes { get; set; }
        public string CampaignId { get; set; }
        public string TopicId { get; set; }
        public string AudienceId { get; set; }
        public string WebAddress { get; set; }
        public String Language { get; set; }
        public DateTime? AvailableDate { get; set; }
        public String AuthorizationProfileId { get; set; }
        public DateTime? ActiveDate { get; set; }
        
        private bool? _visible = true;
        public bool? Visible
        {
            get { return _visible; }

            set { _visible = value; }
        }

        private bool? _active = true;
        public bool? Active
        {
            get { return _active; }

            set { _active = value; }
        }
    }

}
