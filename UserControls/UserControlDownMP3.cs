using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T2UI.UserControls;
using T2UI.Properties;

namespace T2UI.UserControls
{
    public partial class UserControlDownMP3 : UserControl
    {
        public UserControlDownMP3()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            Controls.Add(userControl);
            userControl.BringToFront();
        }
        public static string ytlink = "";
        private void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            ytlink = guna2TextBox1.Text;
            string checkyt1 = "youtube.com/";
            string checkyt2 = "youtu.be/";
            if (ytlink.Contains(checkyt1) || ytlink.Contains(checkyt2))
            {
                ytlink = guna2TextBox1.Text;
                UserControlDownloadingMP3 uc3 = new UserControlDownloadingMP3();
                addUserControl(uc3);
            }
            else
            {
                label1.Text = "Please check your link";
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
            }
        }

        private void guna2Button2_MouseClick(object sender, MouseEventArgs e)
        {
            string where = Settings.Default["MP3DownPath"].ToString();
            System.IO.Directory.CreateDirectory(where);
            Process.Start(where);
        }
    }
}
