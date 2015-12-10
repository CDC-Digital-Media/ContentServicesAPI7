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
using Gov.Hhs.Cdc.DataServices.Bo;
using System.Data.Objects;
using Gov.Hhs.Cdc.MediaProvider;

namespace Gov.Hhs.Cdc.CdcMediaProvider.Dal
{
    public class PotentialValueRelationshipCtl
    {
        public static IQueryable<PotentialValueRelationshipItem> Get(MediaObjectContext media)
        {
            IQueryable<ValueToValueSetObject> items = ValueToValueSetCtl.Get(media);

            IQueryable<PotentialValueRelationshipItem> potentialRelationshipItems = 
                from r in ValueSetRelationItemCtl.Get(media)
                    join i in items
                        on r.ValueSetId equals i.ValueSetId
                    join ri in items
                        on r.RelatedValueSetId equals ri.ValueSetId
                    select new PotentialValueRelationshipItem()
                    {
                        ValueSetRelationItem = r,
                        ValueValueSetItem = i,
                        RelatedValueValueSetItem = ri
                    };

            return potentialRelationshipItems;
        }

        //http://stackoverflow.com/questions/12481868/how-to-use-scalar-valued-function-with-linq-to-entity
        //<Function Name="HasInheritedRelationship_Alt" Aggregate="false" BuiltIn="false" NiladicFunction="false" IsComposable="false" ParameterTypeSemantics="AllowImplicitConversion" Schema="dbo">
        //  <CommandText>
        //    select dbo.HasInheritedRelationship_Alt(@ValueId,@RelationshipTypeName,@RelatedValueId)
        //  </CommandText>
        //  <Parameter Name="ValueId" Type="int" Mode="In" />
        //  <Parameter Name="RelationshipTypeName" Type="real" Mode="In" />
        //  <Parameter Name="RelatedValueId" Type="int" Mode="In" />
        //</Function>
        public static bool DoesInheritedRelationshipExists(MediaObjectContext media, int valueId, string inverseRelationshipTypeName, int relatedValueId)
        {
            string exists= media.MediaDbEntities.HasInheritedValueRelationship(valueId, inverseRelationshipTypeName, relatedValueId).First();
            return exists == "Yes";
        }

        public static bool DoesRecursiveLoopRelationshipExist(MediaObjectContext media, int valueId, string inverseRelationshipTypeName)
        {
            string exists = media.MediaDbEntities.HasRecursiveLoopValueRelationship(valueId, inverseRelationshipTypeName).First();
            return exists == "Yes";
        }


    }
}
