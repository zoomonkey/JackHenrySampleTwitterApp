using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHTwitterSampleApp
{
    public partial class JHTwitterSampleApp : Form
    {
        public JHTwitterSampleApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private async void btnStartPollingTwitter_Click(object sender, EventArgs e)
        {
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

            ITwitterPollingLogic twitter = new TwitterPollingLogic(url, ConfigurationManager.AppSettings["TwitterBearerToken"], int.Parse(ConfigurationManager.AppSettings["SampleSizeForTrendingReport"]));

            await Task.Run(() => twitter.GetTwitterDataLive(twitterDataDynamic, twitterReportModel, int.Parse(ConfigurationManager.AppSettings["SampleSizeForTrendingReport"])));
        }
     
        private void btnStopPollingTwitter_Click(object sender, EventArgs e)
        {
            // TODO: Add a stop to polling 
            Application.Exit();
        }
    }
}
