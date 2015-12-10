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

namespace Gov.Hhs.Cdc.ECardProvider
{
    public class CardSubmission
    {
        public IList<CardInstanceObject> Instances { get; set; }
        public CardMessageObject Message { get; set; }
        public int MediaId { get; set; }


        /// <summary>
        /// Constructor for the API to call
        /// </summary>
        /// <param name="instances"></param>
        /// <param name="message"></param>
        /// <param name="mediaId"></param>
        public CardSubmission(IList<CardInstanceObject> instances, CardMessageObject message, int mediaId)
        {
            Instances = instances;
            Message = message;
            MediaId = mediaId;
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="oldCardInstance"></param>
        public CardSubmission(CardSubmission oldCardInstance, int mediaId)
        {
            Instances = oldCardInstance.Instances.Select(i => 
                new CardInstanceObject(i.RecipientName, i.RecipientEmailAddress, i.IsSender, mediaId)).ToList();
            Message = new CardMessageObject(oldCardInstance.Message);
        }
    }
}
