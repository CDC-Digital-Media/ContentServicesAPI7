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

using Gov.Hhs.Cdc.MediaProvider;

namespace Gov.Hhs.Cdc.CdcMediaProvider.Dal
{
    public class PersistentUrlCtl
    {
        public static IQueryable<PersistentUrlObject> Get(MediaObjectContext media, bool forUpdate = false)
        {
            var data = from a in media.MediaDbEntities.Medias
                       where a.MediaTypeCode != null && a.MediaTypeCode == "html" && a.MediaStatusCode == "published"
                       select new PersistentUrlObject()
                       {
                           Token = a.PersistentURLToken,
                           Url = a.TargetUrl
                       };

            return data;
        }
    }
}
