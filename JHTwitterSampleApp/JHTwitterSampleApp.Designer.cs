
namespace JHTwitterSampleApp
{
    partial class JHTwitterSampleApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnStartPollingTwitter = new System.Windows.Forms.Button();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumTweets = new System.Windows.Forms.Label();
            this.btnStopPollingTwitter = new System.Windows.Forms.Button();
            this.lblTrending = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(298, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 25);
            this.lblMessage.TabIndex = 0;
            // 
            // btnStartPollingTwitter
            // 
            this.btnStartPollingTwitter.BackColor = System.Drawing.Color.LawnGreen;
            this.btnStartPollingTwitter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartPollingTwitter.Location = new System.Drawing.Point(648, 284);
            this.btnStartPollingTwitter.Name = "btnStartPollingTwitter";
            this.btnStartPollingTwitter.Size = new System.Drawing.Size(259, 92);
            this.btnStartPollingTwitter.TabIndex = 1;
            this.btnStartPollingTwitter.Text = "Start Polling Twitter";
            this.btnStartPollingTwitter.UseVisualStyleBackColor = false;
            this.btnStartPollingTwitter.Click += new System.EventHandler(this.btnStartPollingTwitter_Click);
            // 
            // tblLayout
            // 
            this.tblLayout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.Controls.Add(this.label1, 0, 1);
            this.tblLayout.Controls.Add(this.lblTrending, 0, 1);
            this.tblLayout.Controls.Add(this.lblMessage, 1, 0);
            this.tblLayout.Controls.Add(this.lblNumTweets, 0, 0);
            this.tblLayout.Location = new System.Drawing.Point(984, 284);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.Size = new System.Drawing.Size(591, 150);
            this.tblLayout.TabIndex = 2;
            // 
            // lblNumTweets
            // 
            this.lblNumTweets.AutoSize = true;
            this.lblNumTweets.Location = new System.Drawing.Point(3, 0);
            this.lblNumTweets.Name = "lblNumTweets";
            this.lblNumTweets.Size = new System.Drawing.Size(240, 25);
            this.lblNumTweets.TabIndex = 1;
            this.lblNumTweets.Text = "Number of Tweets Received: ";
            // 
            // btnStopPollingTwitter
            // 
            this.btnStopPollingTwitter.BackColor = System.Drawing.Color.OrangeRed;
            this.btnStopPollingTwitter.Location = new System.Drawing.Point(648, 438);
            this.btnStopPollingTwitter.Name = "btnStopPollingTwitter";
            this.btnStopPollingTwitter.Size = new System.Drawing.Size(259, 92);
            this.btnStopPollingTwitter.TabIndex = 3;
            this.btnStopPollingTwitter.Text = "Close application";
            this.btnStopPollingTwitter.UseVisualStyleBackColor = false;
            this.btnStopPollingTwitter.Click += new System.EventHandler(this.btnStopPollingTwitter_Click);
            // 
            // lblTrending
            // 
            this.lblTrending.AutoSize = true;
            this.lblTrending.Location = new System.Drawing.Point(298, 75);
            this.lblTrending.Name = "lblTrending";
            this.lblTrending.Size = new System.Drawing.Size(0, 25);
            this.lblTrending.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Tweets Received: ";
            // 
            // JHTwitterSampleApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 929);
            this.Controls.Add(this.btnStopPollingTwitter);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.btnStartPollingTwitter);
            this.Name = "JHTwitterSampleApp";
            this.Text = "JH Twitter Sample App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnStartPollingTwitter;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Label lblNumTweets;
        private System.Windows.Forms.Button btnStopPollingTwitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrending;
    }
}

