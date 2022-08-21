using JHTwitterSampleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace JHTTwitterUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Unit test JHTwitterSampleApp by mocking out key variables with local values
        /// NOTE: There is not much to test in this app, so this is just some samples of moq'ing out some values and asserting some Equals
        /// I'm not sure you'd want to run a test on GetTwitterDataLive since it's Persistent.
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
    }
}
