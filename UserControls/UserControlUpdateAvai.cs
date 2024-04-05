using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T2UI.UserControls;

namespace T2UI.UserControls
{
    public partial class UserControlUpdateAvai : UserControl
    {
        bool accepted = false;
        public UserControlUpdateAvai()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Updater uc = new Updater();
            addUserControl(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            accepted = true;
            AutoUpdater.Start("https://raw.githubusercontent.com/ducanhmai521/ducanhmai521.github.io/main/update.xml");
        }

        private void UserControlUpdateAvai_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            label2.Text = "Your current version: " + version;
            label3.Text = "Latest version: " + Updater.latver;
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {
                if (accepted == true)
                {
                    try
                    {
                        if (AutoUpdater.DownloadUpdate(args))
                        {
                            Application.Exit();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(@"You're using the latest version!", @"T2UI Updater",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
