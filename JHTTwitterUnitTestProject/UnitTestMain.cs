using JHTwitterSampleApp.BusinessLogic;
using JHTwitterSampleApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using log4net;

namespace JHTTwitterUnitTestProject
{
    [TestClass]
    public class UnitTestMain
    {
        public ILog _log;
        /// <summary>
        /// Unit test JHTwitterSampleApp by mocking out key variables with local values
        /// NOTE: There is not much to test in this app, so this is just some samples of moq'ing out some values and asserting some Equals
        /// </summary>
        [TestMethod]
        public void TestMainTwitterPollingMethod()
        {
            var mock = new Mock<ITwitterPollingLogic>();
            mock.Setup(x => x._sampleSizeForTrendingReport).Returns(int.Parse(ConfigurationManager.AppSettings["SampleSizeForTrendingReport"]));
            mock.Setup(x => x._twitterBearerToken).Returns(ConfigurationManager.AppSettings["TwitterBearerToken"]);
            mock.Setup(x => x._url).Returns(ConfigurationManager.AppSettings["TwitterApiUrl"]);

            Assert.AreEqual(mock.Object._sampleSizeForTrendingReport, int.Parse(ConfigurationManager.AppSettings["SampleSizeForTrendingReport"]));
            Assert.AreEqual(mock.Object._twitterBearerToken, ConfigurationManager.AppSettings["TwitterBearerToken"]);
            Assert.AreEqual(mock.Object._url, ConfigurationManager.AppSettings["TwitterApiUrl"]);

            mock.Setup(p => p.GetTwitterDataLive(It.IsAny<IProgress<List<TwitterDataModel>>>(), It.IsAny<IProgress<TwitterReportModel>>(), It.IsAny<int>()));

            var test = mock.Object;
            test.GetTwitterDataLive(new Progress<List<TwitterDataModel>>(), new Progress<TwitterReportModel>(), 0);
        }

        /// <summary>
        /// Test we can combine models into 1 for simplicity sake
        /// </summary>
        [TestMethod]
        public void TestMainTwitterTrendingLogic()
        {
            log4net.Config.XmlConfigurator.Configure();

            var tdmList = new List<TwitterDataModel>();
            var tdm = new TwitterDataModel();
            var tdm2 = new TwitterDataModel();

            Data data = new Data();
            data.entities = new Entities();
            data.entities.hashtags = new List<Hashtag>() {
                new Hashtag() { tag = "math" },
                new Hashtag() { tag = "science" },
                new Hashtag() { tag = "geology" },
                new Hashtag() { tag = "math" }};
            tdm.data = data;
            tdmList.Add(tdm);

            Data data1 = new Data();
            data1.entities = new Entities();
            data1.entities.hashtags = new List<Hashtag>() {
                new Hashtag() { tag = "test1" },
                new Hashtag() { tag = "test2" },
                new Hashtag() { tag = "test3" },
                new Hashtag() { tag = "test4" }};
            tdm2.data = data1;
            tdmList.Add(tdm2);

        
            ICombineAllHashTagsLists combine = new CombineAllHashTagsLists(tdmList, null);
            List<Hashtag> retList = combine.CombineAllHashTagsIntoOneList();

            Assert.AreEqual(retList.Count, 8);
        }

        public void TestGetTrendingHashTags()
        { 
            // TODO
        }
    }
}
