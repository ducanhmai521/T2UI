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
    public partial class UserControlSettings_Sounds : UserControl
    {
        public UserControlSettings_Sounds()
        {
            InitializeComponent();
        }

        private void UserControlSettings_Sounds_Load(object sender, EventArgs e)
        {
            if (Settings.Default["SoundEnabled"].Equals(true))
            {
                guna2CheckBox2.Checked = true;
            }
            if (Settings.Default["easterhomecvm"].Equals(true))
            {
                doge.Visible = true;
                pictureBox1.Visible = false;
            }
            else
            {
                doge.Visible = false;
                pictureBox1.Visible = true;
            }    
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["SoundEnabled"] = guna2CheckBox2.Checked;
            Settings.Default.Save();
        }

        private async void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult diasult = MessageBox.Show("Yay! You found out an easter egg, wanna see it?", "Tiofe", MessageBoxButtons.YesNo);
            if (diasult == DialogResult.Yes)
            {
                Settings.Default["easterhomecvm"] = true;
                SoundPlayer simpleSound = new SoundPlayer("homecvm.wav");
                simpleSound.Play();
                await Task.Delay(2000);
                AutoClosingNoResultMessageBox.Show("Here you go!", "Homecvming", 2000);
                await Task.Delay(5000);
                AutoClosingNoResultMessageBox.Show("Wait for it...", "Homecvming", 1000);
                await Task.Delay(5000);
                AutoClosingNoResultMessageBox.Show("Almost there...", "Homecvming", 1000);
                await Task.Delay(1500);
                pictureBox1.Visible = false;
                doge.Visible = true;
                AutoClosingNoResultMessageBox.Show("Beat drop baby!!!", "Homecvming", 3000);
                await Task.Delay(40000);
                doge.Visible = false;
                pictureBox1.Visible = true;
                Settings.Default["easterhomecvm"] = false;
                AutoClosingNoResultMessageBox.Show("Thanks for listening! Made by RXCodes", "Homecvming", 3000);
            }
            else
            {
                MessageBox.Show("Okay then... You hurted me...", "Tiofe");
            }
        }
        public class AutoClosingNoResultMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingNoResultMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingNoResultMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}
