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
using Gov.Hhs.Cdc.RegistrationProvider;
using Gov.Hhs.Cdc.DataServices.Bo;
using Gov.Hhs.Cdc.DataServices;
using Gov.Hhs.Cdc.Bo;

namespace Gov.Hhs.Cdc.CdcRegistrationProvider
{
    public class DomainObjectValidator : IValidator<DomainObject, DomainObject>
    {
        public void PreSaveValidate(ref ValidationMessages validationMessages, IList<DomainObject> items)
        {
            foreach (DomainObject organization in items)
            {
            }
        }
        public void PreDeleteValidate(ValidationMessages validationMessages, IList<DomainObject> items)
        {
        }

        public void ValidateSave(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, IList<DomainObject> items)
        {

            foreach (DomainObject domain in (IEnumerable<DomainObject>)items)
            {
                //domain.IsNew = !DomainObjectCtl.Get((RegistrationObjectContext)objectContext, forUpdate: false).Where(o => o.DomainName == domain.DomainName).Any();
                //if (DomainObjectCtl.Get((RegistrationObjectContext)objectContext, forUpdate:false).Where(o => o.DomainName == domain.DomainName).Any())
                //    validationMessages.AddError(domain.ValidationKey, "The organization already exists in the system");
            }
        }

        public void PostSaveValidate(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, IList<DomainObject> items)
        {
        }

        public void ValidateDelete(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, IList<DomainObject> items)
        {
        }

        public DomainObject GetValidationObject(IDataServicesObjectContext objectContext, ValidationMessages validationMessages, DomainObject theObject)
        {
            return theObject;
        }

    }
}
