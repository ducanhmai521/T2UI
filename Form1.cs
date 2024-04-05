using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Media;
using AutoUpdaterDotNET;
using T2UI.UserControls;
using T2UI.Properties;
using NiL.JS.Expressions;

namespace T2UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            UserControlSettings_Acc.OnUpdateStatus += customControl_OnUpdateStatus;
            if (Settings.Default["SettedDefYTPath"].Equals(false))
            {
                string userName = Environment.UserName;
                Settings.Default["MP3DownPath"] = @"C:\Users\" + userName + @"\Downloads\T2UI\MP3\";
                Settings.Default["SettedDefYTPath"] = true;
                Settings.Default.Save();
            }
            UserControlTiofe2 uc = new UserControlTiofe2();
            addUserControl(uc);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            if (Settings.Default["AutoCheckForUpdate"].Equals(true))
            {
                AutoUpdater.Start("https://raw.githubusercontent.com/ducanhmai521/ducanhmai521.github.io/main/update.xml");
            }    
        }
        private void customControl_OnUpdateStatus(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {
                Updater.latver = args.CurrentVersion;
                guna2Button5.Checked = true;
                UserControlUpdateAvai uc3 = new UserControlUpdateAvai();
                addUserControl(uc3);  
            }
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            UserControlTiofe2 uc = new UserControlTiofe2();
            addUserControl(uc);
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {
            UserControlDownMP3 uc2 = new UserControlDownMP3();
            addUserControl(uc2);
        }

        private void guna2Button4_CheckedChanged(object sender, EventArgs e)
        {
            UserControlEnDe uc = new UserControlEnDe();
            addUserControl(uc);
        }

        private void guna2Button5_CheckedChanged(object sender, EventArgs e)
        {
            Updater uc = new Updater();
            addUserControl(uc);
        }

        private void guna2Button3_CheckedChanged(object sender, EventArgs e)
        {
            UserControlSettings uc = new UserControlSettings();
            addUserControl(uc);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
