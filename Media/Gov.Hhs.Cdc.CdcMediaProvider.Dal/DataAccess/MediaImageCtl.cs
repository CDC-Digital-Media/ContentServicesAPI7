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

using Gov.Hhs.Cdc.DataServices;
using Gov.Hhs.Cdc.MediaProvider;

namespace Gov.Hhs.Cdc.CdcMediaProvider.Dal
{
    public class MediaImageCtl : BaseCtl<MediaImage, Image, MediaImageCtl, MediaObjectContext>
    {
        public override void SetInitialValues(DateTime modifiedDateTime, Guid modifiedGuid)
        {
            PersistedDbObject = new Image();

            PersistedDbObject.CreatedDateTime = modifiedDateTime;
            PersistedDbObject.CreatedByGUID = modifiedGuid;
        }

        public override void SetUpdatableValues(DateTime modifiedDateTime, Guid modifiedGuid)
        {

            PersistedDbObject.Title = NewBusinessObject.Title;
            PersistedDbObject.Description = NewBusinessObject.Description;
            PersistedDbObject.SourceURL = NewBusinessObject.SourceUrl;
            PersistedDbObject.LinkURL = NewBusinessObject.TargetUrl;
            if (NewBusinessObject.Height.HasValue)
            {
                PersistedDbObject.Height = NewBusinessObject.Height.Value;
            }
            if (NewBusinessObject.Width.HasValue)
            {
                PersistedDbObject.Width = NewBusinessObject.Width.Value;
            }
            PersistedDbObject.ModifiedDateTime = modifiedDateTime;
            PersistedDbObject.ModifiedByGUID = modifiedGuid;
        }

        public override bool DbObjectEqualsBusinessObject()
        {
            return false;
        }

        public override bool VersionMatches()
        {
            return true;
        }

        public override void UpdateIdsAfterInsert()
        {
        }

        public override void Delete()
        {
            TheObjectContext.MediaDbEntities.Images.DeleteObject(PersistedDbObject);
        }

        public override void AddToDb()
        {
            TheObjectContext.MediaDbEntities.Images.AddObject(PersistedDbObject);
        }

        public override object Get(bool forUpdate)
        {
            return Get(TheObjectContext, forUpdate);
        }

        public static IQueryable<MediaImage> Get(MediaObjectContext media, bool forUpdate = false)
        {
            return media.MediaDbEntities.Images.Select(i => new MediaImage
            {
                MediaId = i.MediaID,
                Title = i.Title,
                Description = i.Description,
                Height = i.Height,
                Width = i.Width,
                SourceUrl = i.SourceURL,
                TargetUrl = i.LinkURL,
                CreatedBy = i.CreatedByGUID,
                CreatedDateTime = i.CreatedDateTime,
                ModifiedBy = i.ModifiedByGUID,
                ModifiedDateTime = i.ModifiedDateTime
            });
        }

        public override string ToString()
        {
            return PersistedBusinessObject.GetType().Name;
        }
    }
}
