using JHTwitterSampleApp.BusinessLogic;
using JHTwitterSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace JHTwitterSampleApp
{
    public partial class JHTwitterSampleApp : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public JHTwitterSampleApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        private async void btnStartPollingTwitter_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("Starting Twitter Polling");

                btnStartPollingTwitter.Enabled = false;
                var twitterDataDynamic = new Progress<List<TwitterDataModel>>(value =>
                {
                    lblMessage.Text = value.Count.ToString();
                });

                var twitterReportModel = new Progress<TwitterReportModel>(value =>
                {
                    lblTrending.Text = value.trending;
                });

                // this could be put in a DB or more dynamic, hard coded for now
                string url = ConfigurationManager.AppSettings["TwitterApiUrl"] + ConfigurationManager.AppSettings["TwitterApiUrlAppendFields"];

                ITwitterPollingLogic twitter = new TwitterPollingLogic(url, ConfigurationManager.AppSettings["TwitterApiUrlAppendFields"], ConfigurationManager.AppSettings["TwitterBearerToken"],
                    int.Parse(ConfigurationManager.AppSettings["SampleSizeForTrendingReport"]), log);

                await Task.Run(() => twitter.GetTwitterDataLive(twitterDataDynamic, twitterReportModel, int.Parse(ConfigurationManager.AppSettings["SampleSizeForTrendingReport"])));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        private void btnStopPollingTwitter_Click(object sender, EventArgs e)
        {
            log.Info("End Twitter Polling");
            // TODO: Add a stop to polling 
            Application.Exit();
        }
    }
}
