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
using Gov.Hhs.Cdc.DataServices.Bo;
using Gov.Hhs.Cdc.DataServicesCacheProvider;
using Gov.Hhs.Cdc.Bo;
using Gov.Hhs.Cdc.MediaValidatonProvider;

namespace Gov.Hhs.Cdc.MediaValidation.Dal
{
    public class MediaMimeTypeItemCtl : ICachedDataControl
    {

        public IQueryable Get(IDataServicesObjectContext dataEntities)
        {
            MediaValidationObjectContext db = (MediaValidationObjectContext)dataEntities;
            return GetMediaMimeType(db);
        }

        public static IQueryable<MediaMimeTypeItem> GetMediaMimeType(MediaValidationObjectContext db)
        {
            IQueryable<MediaMimeTypeItem> mediaMimeTypeItems = from m in db.MediaValidationDbEntities.MediaMimeTypes
                                                               select new MediaMimeTypeItem()
                                                       {
                                                           MediaTypeCode = m.MediaTypeCode,
                                                           MimeTypeCode = m.MimeTypeCode
                                                       };
            return mediaMimeTypeItems;
        }

    }
}
