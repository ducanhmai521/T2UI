using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T2UI.Properties;

namespace T2UI.UserControls
{
    public partial class UserControlSettings_Acc : UserControl
    {
        public UserControlSettings_Acc()
        {
            InitializeComponent();
        }

        private void UserControlSettings_Acc_Load(object sender, EventArgs e)
        {
            if (Settings.Default["AutoLogin"].Equals(true))
            {
                guna2CheckBox2.Checked = true;
            }
            label1.Text = loginform.username;
        }
        //Declare a delegate and Event.  Here called StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public static event StatusUpdateHandler OnUpdateStatus;
        private void UpdateStatus()
        {
            //Create arguments.  You should also have custom one, or else return EventArgs.Empty();
            EventArgs args = new EventArgs();

            //Call any listeners
            OnUpdateStatus?.Invoke(this, args);

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UpdateStatus();
            Settings.Default["AutoLogin"] = false;
            Settings.Default.Save();
            new loginform().Show();
            if (Settings.Default["SoundEnabled"].Equals(true))
            {
                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                simpleSound.Play();
            }
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["AutoLogin"] = guna2CheckBox2.Checked;
            Settings.Default.Save();
        }
    }
}
