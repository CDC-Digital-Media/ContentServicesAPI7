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


namespace Gov.Hhs.Cdc.CdcMediaValidationProvider
{
    public class XPathSelection
    {
        public string _elementType;
        public string ElementType
        {
            get { return _elementType; }
            set { _elementType = value == null ? null : value.ToLower(); }
        }
        public AttributeSelection AttributeSelection { get; set; }
        public string XPath { get; set; }

        public XPathSelection(string elementType, AttributeSelection attributeSelection)
        {
            this.ElementType = elementType;
            this.AttributeSelection = attributeSelection;
        }

        public XPathSelection(string elementType)
        {
            this.ElementType = elementType;
            this.AttributeSelection = new AttributeSelection();
        }

        public string GetXPath()
        {
            return XPathFormat(ElementType) + AttributeSelection.Value;
        }

        private string XPathFormat(string elementType)
        {
            if (elementType == null)
                return "";
            string xPath = (elementType == "*" ? "*" : CdcSiteXmlDocument.ExtractionPrefix + elementType);
            return xPath;
        }

        public override string ToString()
        {
            return GetXPath();
        }
    }
}
