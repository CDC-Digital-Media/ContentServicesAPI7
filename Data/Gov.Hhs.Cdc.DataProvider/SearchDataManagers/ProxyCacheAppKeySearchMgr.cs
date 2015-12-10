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
using Gov.Hhs.Cdc.Bo;
using Gov.Hhs.Cdc.DataServices;
using Gov.Hhs.Cdc.DataServices.Bo;

namespace Gov.Hhs.Cdc.DataProvider
{
    class ProxyCacheAppKeySearchMgr : SearchDataManager<ProxyCacheAppKeyObject>
    {
        public override string ApplicationCode { get { return "Data"; } }

        public static IObjectContextFactory ProxyCacheAppKeyObjectContextFactory { get; set; }

        public ProxyCacheAppKeySearchMgr()
            : base(ProxyCacheAppKeyObjectContextFactory)
        {
        }

        public static void Inject(IObjectContextFactory objectContextFactory)
        {
            ProxyCacheAppKeyObjectContextFactory = objectContextFactory;
        }

        public override DataSetResult GetData(SearchPlan searchPlan, ResultSetParms resultSetParms)
        {
            using (IDataServicesObjectContext dataObjectContext = ObjectContextFactory.Create())
            {
                var dbContext = dataObjectContext as DataObjectContext;

                IQueryable<ProxyCacheAppKeyObject> proxyCacheAppKeyObjects = ProxyCacheAppKeyCtl.Get(dbContext);

                return CreateDataSetResults(proxyCacheAppKeyObjects, searchPlan, resultSetParms.ResultSetId);
            }
        }

        public override List<ListItem> GetListItems(FilterCriterion parameter, bool getOnlySelectedItems)
        {
            throw new NotImplementedException();
        }

        public override List<HierarchicalItem> GetHierarchicalItems(FilterCriterion parameter, bool getRoot,
            FilterCriterion currentlySelectedItems, string parentKey, FilterCriterion filter)
        {
            throw new NotImplementedException();
        }
    }
}
