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
using System.Web;

using Gov.Hhs.Cdc.Logging;
using Gov.Hhs.Cdc.CsCaching;

namespace Gov.Hhs.Cdc.Api.Public
{
    public class WebBrowserNoScriptRedirectModule
    {
        public static string GetUrl(string[] segments)
        {
            int mediaId = int.Parse(segments[segments.GetUpperBound(0) - 1]);
            string sUrl = string.Empty;
            if (mediaId > 0)
            {
                try
                {
                    var cache = CacheManager.CachedValue<Uri>(mediaId.ToString() + "|noscript");
                    if (cache == null)
                    {
                        sUrl = NoScriptSearchHandler.RedirectUrl(mediaId);
                    }
                    else
                    {
                        sUrl = cache.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError("The Persistent URL key (" + mediaId + ") was not found in the collection. " + ex.ToString());
                }
            }

            return sUrl;
        }
    }
}
