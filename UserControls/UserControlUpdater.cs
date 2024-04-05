using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using T2UI.UserControls;
using T2UI.Properties;

namespace T2UI.UserControls
{
    public partial class Updater : UserControl
    {
        public Updater()
        {
            InitializeComponent();
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            string version = fvi.FileVersion;
            label3.Text = "Your current version: " + version;
        }
        private void addUserControl(UserControl userControl)
        {
            Controls.Add(userControl);
            userControl.BringToFront();
        }
        public static string latver = "";
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                    simpleSound.Play();
                }
                latver = args.CurrentVersion;
                UserControlUpdateAvai uc3 = new UserControlUpdateAvai();
                addUserControl(uc3);
            }
            else
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                    simpleSound.Play();
                }
                label3.Text = @"You're using the latest version!";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/ducanhmai521/ducanhmai521.github.io/main/update.xml");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            latver = fvi.FileVersion;
            UserControlUpdateAvai uc3 = new UserControlUpdateAvai();
            addUserControl(uc3);
        }
    }
}
