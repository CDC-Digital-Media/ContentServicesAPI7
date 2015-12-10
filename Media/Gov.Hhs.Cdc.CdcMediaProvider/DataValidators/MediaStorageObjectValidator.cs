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
using Gov.Hhs.Cdc.CdcMediaProvider.Dal;
using Gov.Hhs.Cdc.DataServices;
using Gov.Hhs.Cdc.DataServices.Bo;
using Gov.Hhs.Cdc.MediaProvider;

namespace Gov.Hhs.Cdc.CdcMediaProvider
{
    public class MediaStorageObjectValidator : IValidator<StorageObject, StorageObject>
    {
        public void PreSaveValidate(ref ValidationMessages validationMessages, IList<StorageObject> items)
        {
            foreach (StorageObject storageObject in items)
            {
                RegExValidator v = new RegExValidator(validationMessages, storageObject.ValidationKey);
                                
                v.IsValid(v.Numeric, storageObject.MediaId.ToString(), required: true, message: "MediaId is invalid");
                v.IsValid(v.Numeric, storageObject.StorageId.ToString(), required: true, message: "StorageId is invalid");
            }
        }

        public void PreDeleteValidate(ValidationMessages validationMessages, IList<StorageObject> items)
        {
        }

        public void ValidateSave(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, IList<StorageObject> items)
        {
        }

        public void PostSaveValidate(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, IList<StorageObject> items)
        {
        }

        public void ValidateDelete(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, IList<StorageObject> items)
        {
        }

        public StorageObject GetValidationObject(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, StorageObject theObject)
        {
            return theObject;
        }
    }
}