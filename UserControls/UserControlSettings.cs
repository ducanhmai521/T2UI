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
    public partial class UserControlSettings : UserControl
    {
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public static int easter = 0;
        public UserControlSettings()
        {
            InitializeComponent();
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            UserControlSettings_Acc uc = new UserControlSettings_Acc();
            addUserControl(uc);
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {
            UserControlSettings_General uc = new UserControlSettings_General();
            addUserControl(uc);
        }

        private void guna2Button3_CheckedChanged(object sender, EventArgs e)
        {
            UserControlSettings_Sounds uc = new UserControlSettings_Sounds();
            addUserControl(uc);
        }

        private void guna2Button4_CheckedChanged(object sender, EventArgs e)
        {
            UserControlSettings_Others uc = new UserControlSettings_Others();
            addUserControl(uc);
        }

        private void guna2Button5_CheckedChanged(object sender, EventArgs e)
        {
            UserControlSettings_About uc = new UserControlSettings_About();
            addUserControl(uc);
        }

        private void UserControlSettings_Load(object sender, EventArgs e)
        {
            UserControlSettings_General uc = new UserControlSettings_General();
            addUserControl(uc);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (easter==0)
            {
                MessageBox.Show("Hey!", "Tiofe");
                easter++;
            }    
            else if (easter==1)
            {
                MessageBox.Show("Huh?", "Tiofe");
                easter++;
            }  
            else if (easter==2)
            {
                MessageBox.Show("What do you want?", "Tiofe");
                easter++;
            }    
            else if (easter==3)
            {
                MessageBox.Show("...", "Tiofe");
                easter++;
            }    
            else if (easter==4)
            {
                DialogResult diasult = MessageBox.Show("How about this, I'll tell you my secret then you'll leave me alone?", "Tiofe", MessageBoxButtons.YesNo);
                if (diasult==DialogResult.Yes)
                {
                    easter++;
                }    
                else
                {
                    easter = 0;
                }    
            }
            else if (easter==5)
            {
                MessageBox.Show("Eh...I...like... No, used to like...him... Qbỡụờì...", "Tiofe");
                MessageBox.Show("Now leave me alone! :<", "Tiofe");
                easter = 0;
            }    
        }
    }
}
