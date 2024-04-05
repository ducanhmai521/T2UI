using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T2UI.Properties;

namespace T2UI.UserControls
{
    public partial class UserControlSettings_General : UserControl
    {
        public UserControlSettings_General()
        {
            InitializeComponent();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["AutoCheckForUpdate"] = guna2CheckBox1.Checked;
            Settings.Default.Save();
        }

        private void UserControlSettings_General_Load(object sender, EventArgs e)
        {
            if (Settings.Default["AutoCheckForUpdate"].Equals(true))
            {
                guna2CheckBox1.Checked = true;
            }
            if (Settings.Default["T2EnterToAction"].Equals(true))
            {
                guna2CheckBox2.Checked = true;
            }
            guna2TextBox1.Text = Settings.Default["MP3DownPath"].ToString();
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["T2EnterToAction"] = guna2CheckBox2.Checked;
            Settings.Default.Save();
        }

        private void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog od = new FolderBrowserDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox1.Text = od.SelectedPath;
                Settings.Default["MP3DownPath"] = od.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void guna2Button2_MouseClick(object sender, MouseEventArgs e)
        {
            string userName = Environment.UserName;
            Settings.Default["MP3DownPath"] = @"C:\Users\" + userName + @"\Downloads\T2UI\MP3\";
            Settings.Default["SettedDefYTPath"] = true;
            Settings.Default.Save();
            guna2TextBox1.Text = Settings.Default["MP3DownPath"].ToString();
        }
    }
}
