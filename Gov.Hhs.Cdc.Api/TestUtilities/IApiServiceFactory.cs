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

namespace Gov.Hhs.Cdc.Api
{
    public interface IApiServiceFactory
    {
        RestServiceBase CreateNewService(int version);
        TestUrl CreateTestUrl(string resource);
        TestUrl CreateTestUrl(string resource, int id, string action, string queryParms);
        TestUrl CreateTestUrl(string resource, string id, string action, string queryParms, int version = 1);
    }
}
