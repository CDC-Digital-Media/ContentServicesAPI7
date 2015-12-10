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

using System.Linq;
using Gov.Hhs.Cdc.Api;
using Gov.Hhs.Cdc.CdcMediaProvider;
using Gov.Hhs.Cdc.Connection;
using Gov.Hhs.Cdc.CsBusinessObjects.Media;
using Gov.Hhs.Cdc.Global;
using Gov.Hhs.Cdc.MediaProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gov.Hhs.Cdc.Bo;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SearchUnitTests
{
    [TestClass]
    public class MediaOutputTests
    {
        public MediaOutputTests()
        {
            ContentServicesDependencyBuilder.BuildAssembliesWithTestEMailProvider();
            CurrentConnection.Name = "ContentServicesDb";
        }

        private static SerialMediaAdmin media = TestApiUtility.SinglePublishedHtml();
        private static MediaObject searchResult = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var mediaId = media.mediaId;
            var criteria = new SearchCriteria { MediaId = mediaId.ToString() };
            var result = CsMediaSearchProvider.Search(criteria);

            Assert.AreEqual(1, result.Count());

            searchResult = result.First();
        }

        [TestMethod]
        public void IdsMatch()
        {
            Assert.AreEqual(media.id, searchResult.Id.ToString());
        }

        [TestMethod]
        public void MediaIdsMatch()
        {
            Assert.AreEqual(media.mediaId, searchResult.MediaId.ToString());
        }

        [TestMethod]
        public void TitlesMatch()
        {
            Assert.AreEqual(media.title, searchResult.Title);
        }

        [TestMethod]
        public void SubtitlesMatch()
        {
            //TODO:  Add SubTitle as a searchable field in the prod
            //write a method that retrieves an item with a SubTitle
            //compare it to the search result.
            //Right now this test compares NULL with NULL -- not very useful

            //TODO:  Add SubTitle to MediaCtl once added to proc output
            Assert.AreEqual(media.subTitle, searchResult.SubTitle);
        }

        [TestMethod]
        public void DescriptionsMatch()
        {
            Assert.AreEqual(media.description, searchResult.Description);
        }

        [TestMethod]
        public void LanguagesMatch()
        {
            Assert.AreEqual(media.language, searchResult.LanguageCode);
        }

        [TestMethod]
        public void MediaTypesMatch()
        {
            Assert.AreEqual(media.mediaType, searchResult.MediaTypeCode);
        }

        [TestMethod]
        public void MimeTypesMatch()
        {
            Assert.AreEqual(media.mimeType, searchResult.MimeTypeCode);
        }

        [TestMethod]
        public void EncodingsMatch()
        {
            Assert.AreEqual(media.encoding, searchResult.CharacterEncodingCode);
        }

        [TestMethod]
        public void SourceUrlsMatch()
        {
            Assert.AreEqual(media.sourceUrl, searchResult.SourceUrl);
        }

        [TestMethod]
        public void TargetUrlsMatch()
        {
            Assert.AreEqual(media.targetUrl, searchResult.TargetUrl);
        }

        [TestMethod]
        public void PersistentUrlsMatch()
        {
            Assert.AreEqual(media.persistentUrl, searchResult.PersistentUrlToken);
        }

        [TestMethod]
        public void SourceCodesMatch()
        {
            Assert.AreEqual(media.sourceCode, searchResult.SourceCode);
        }

        [TestMethod]
        public void OwningOrgIdsMatch()
        {
            //TODO:  Write a search on Owning Org and test one that has one
            Assert.AreEqual(media.owningOrgId, searchResult.OwningBusinessUnitId);
        }

        [TestMethod]
        public void OwningOrgNamesMatch()
        {
            Assert.AreEqual(media.owningOrgName, searchResult.OwningBusinessUnitName);
        }

        [TestMethod]
        public void MaintainingOrgIdsMatch()
        {
            Assert.AreEqual(media.maintainingOrgId, searchResult.MaintainingBusinessUnitId);
        }

        [TestMethod]
        public void MaintainingOrgNamesMatch()
        {
            Assert.AreEqual(media.maintainingOrgName, searchResult.MaintainingBusinessUnitName);
        }

        [TestMethod]
        public void AlternateImagesMatch()
        {
            //TODO:  Write test that looks for media with alternate images
            Assert.AreEqual(media.alternateImages == null ? 0 : media.alternateImages.Count(), searchResult.AlternateImages == null ? 0 : searchResult.AlternateImages.Count());
        }

        [TestMethod]
        public void AlternateTextsMatch()
        {
            //TODO:  Write test that looks for media with alternate text
            Assert.AreEqual(media.alternateText, searchResult.AlternateText);
        }

        [TestMethod]
        public void NoScriptTextsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.noScriptText, searchResult.NoScriptText);
        }

        [TestMethod]
        public void FeaturedTextsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.featuredText, searchResult.FeaturedText);
        }

        [TestMethod]
        public void AuthorsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.author, searchResult.Author);
        }

        [TestMethod]
        public void LengthsMatch()
        {
            if (!searchResult.Length.HasValue && string.IsNullOrEmpty(media.length)) return;
            Assert.AreEqual(media.length, searchResult.Length);
        }

        [TestMethod]
        public void SizesMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.size, searchResult.Size);
        }

        [TestMethod]
        public void HeightsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.height, searchResult.Height);
        }

        [TestMethod]
        public void WidthsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.width, searchResult.Width);
        }

        [TestMethod]
        public void ChildRelationshipCountsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.childRelationshipCount, searchResult.Children == null ? 0 : searchResult.Children.Count());
        }

        [TestMethod]
        public void ChildRelationshipsMatch()
        {
            if (media.childRelationships.Count == 0 && searchResult.Children == null) return;

            //TODO:  Write test that looks for media with this value
            foreach (var rel in media.childRelationships)
            {
                Assert.IsTrue(searchResult.Children.Any(c => c.MediaId == rel.relatedMediaId));
            }
            foreach (var child in searchResult.Children)
            {
                Assert.IsTrue(media.childRelationships.Any(r => r.relatedMediaId == child.MediaId));
            }
        }

        [TestMethod]
        public void ChildCountsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.childCount, searchResult.Children == null ? 0 : searchResult.Children.Count());
        }

        [TestMethod]
        public void ChildrenMatch()
        {
            if (media.children == null && searchResult.Children == null) return;

            //TODO:  Write test that looks for media with this value
            foreach (var rel in media.children)
            {
                Assert.IsTrue(searchResult.Children.Any(c => c.MediaId.ToString() == rel.mediaId));
            }
            foreach (var child in searchResult.Children)
            {
                Assert.IsTrue(media.children.Any(r => r.mediaId == child.MediaId.ToString()));
            }
        }

        [TestMethod]
        public void ParentCountsMatch()
        {
            //TODO:  Write test that looks for media with this value
            Assert.AreEqual(media.parentCount, searchResult.Parents == null ? 0 : searchResult.Parents.Count());
        }

        [TestMethod]
        public void ParentsMatch()
        {
            //TODO:  Write test that looks for media with this value
            if (media.parents == null && searchResult.Parents == null) return;

            foreach (var parent in media.parents)
            {
                Assert.IsTrue(searchResult.Parents.Any(p => p.MediaId.ToString() == parent.mediaId));
            }

            foreach (var parent in searchResult.Parents)
            {
                Assert.IsTrue(media.parents.Any(r => r.mediaId == parent.MediaId.ToString()));
            }
        }

        [TestMethod]
        public void RatingOverridesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.AreEqual(media.ratingOverride, searchResult.RatingOverride);
        }

        [TestMethod]
        public void RatingMinimumsMatch()
        {
            Assert.AreEqual(media.ratingMinimum, searchResult.RatingMinimum);
        }

        [TestMethod]
        public void RatingMaximumsMatch()
        {
            Assert.AreEqual(media.ratingMaximum, searchResult.RatingMaximum);
        }

        [TestMethod]
        public void CommentsMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.AreEqual(media.comments, searchResult.Comments);
        }

        [TestMethod]
        public void StatusesMatch()
        {
            Assert.AreEqual(media.status, searchResult.MediaStatusCode);
        }

        [TestMethod]
        public void PublishDatesMatch()
        {
            Assert.IsTrue(DateTimesMatch(media.datePublished.ParseUtcDateTime(), searchResult.PublishedDate.Value));
            Assert.IsTrue(DateTimesMatch(media.datePublished.ParseUtcDateTime(), searchResult.PublishedDateTime.Value));
        }

        private bool DateTimesMatch(DateTime? d1, DateTime? d2)
        {
            if (!d1.HasValue && !d2.HasValue) return true;

            TimeSpan? res = d1 - d2;
            TimeSpan ts = res.Value;
            return ts.Days == 0 && ts.Milliseconds < 1000;// less than a second?  close enough.
        }

        [TestMethod]
        public void LastReviewDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateLastReviewed.ParseUtcDateTime(), searchResult.LastReviewedDate));
            Assert.IsTrue(DateTimesMatch(media.dateLastReviewed.ParseUtcDateTime(), searchResult.LastReviewedDateTime));
        }

        [TestMethod]
        public void RowVersionsMatch()
        {
            Assert.AreEqual(media.rowVersion, searchResult.RowVersion.ToBase64String());
        }

        [TestMethod]
        public void TopicCountsMatch()
        {
            Assert.AreEqual(media.tags.topic.Count, searchResult.AttributeValues.Count());
        }

        [TestMethod]
        public void TopicIdsMatch()
        {
            //TODO:  Think about convertic TopicJSON to plain AttributeJSON so we can support more types

            var ids1 = media.tags.topic.Select(t => t.id).ToList();
            var ids2 = searchResult.AttributeValues.Where(a => a.AttributeName == "Topic").Select(t => t.ValueKey.Id).ToList();
            CollectionAssert.AreEqual(ids1, ids2);
        }

        [TestMethod]
        public void GeoTagsMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            var ids1 = media.geoTags.Select(g => g.geoNameId).ToList();
            if (ids1.Count == 0 && !searchResult.HasGeoData) return;
            var ids2 = searchResult.MediaGeoData.Select(g => g.GeoNameId).ToList();
            CollectionAssert.AreEqual(ids1, ids2);
        }

        [TestMethod]
        public void ContentAuthoredDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateContentAuthored.ParseUtcDateTime(), searchResult.DateContentAuthored));
        }

        [TestMethod]
        public void ContentPublishedDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateContentPublished.ParseUtcDateTime(), searchResult.DateContentPublished));
        }

        [TestMethod]
        public void ContentReviewDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateContentReviewed.ParseUtcDateTime(), searchResult.DateContentReviewed));            
        }

        [TestMethod]
        public void SyndicationCaptureDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateSyndicationCaptured.ParseUtcDateTime(), searchResult.DateSyndicationCaptured));            
        }

        [TestMethod]
        public void SyndicationUpdateDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateSyndicationUpdated.ParseUtcDateTime(), searchResult.DateSyndicationUpdated));            
        }

        [TestMethod]
        public void SyndicationVisibleDatesMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            Assert.IsTrue(DateTimesMatch(media.dateSyndicationVisible.ParseUtcDateTime(), searchResult.DateSyndicationVisible));
        }

        [TestMethod]
        public void ExtendedAttributeCountsMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            if (media.extendedAttributes.Count == 0 && searchResult.ExtendedAttributes == null) return;
            Assert.AreEqual(media.extendedAttributes.Count(), searchResult.ExtendedAttributes.Count());
        }

        [TestMethod]
        public void PageCountsMatch()
        {
            //TODO:  Write test that looks for (or creates) media with this value
            if (string.IsNullOrEmpty(media.pageCount) && !searchResult.PageCount.HasValue) return;
            Assert.AreEqual(media.pageCount, searchResult.PageCount);
        }

        [TestMethod]
        public void DataSizesMatch()
        {
                        //TODO:  Write test that looks for (or creates) media with this value
            Assert.AreEqual(media.dataSize, searchResult.DataSize);
        }

        [TestMethod]
        public void DomainNamesMatch()
        {
            //TODO:  Does this attribute make sense on Media table?
            Assert.AreEqual(media.domainName, searchResult.DomainName);
        }

        [TestMethod]
        public void ModifiedDatesMatch()
        {
            Assert.IsTrue(DateTimesMatch(media.dateModified.ParseUtcDateTime(), searchResult.ModifiedDate), searchResult.ModifiedDate.ToString());
            Assert.IsTrue(DateTimesMatch(media.dateModified.ParseUtcDateTime(), searchResult.ModifiedDateTime), searchResult.ModifiedDateTime.ToString());
        }


    }
}
