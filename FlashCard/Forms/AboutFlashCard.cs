using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlashCard
{
    public partial class AboutFlashCard : Form
    {
        public AboutFlashCard()
        {
            this.SetAppIcon();
            InitializeComponent();
            LbVersion.Text = "Version : " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            LinkLabel.Link email = new LinkLabel.Link();
            email.LinkData = "mailto:codearteng@gmail.com";
            linkEmail.Links.Add(email);

            LinkLabel.Link homepage = new LinkLabel.Link();
            homepage.LinkData = "https://www.codearteng.com/2019/04/flash-card-for-you.html";
            linkHomepage.Links.Add(homepage);
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
