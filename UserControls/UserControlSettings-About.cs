using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T2UI.UserControls
{
    public partial class UserControlSettings_About : UserControl
    {
        public UserControlSettings_About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", "https://www.codeproject.com/Articles/1259429/Simple-Files-Encrypt-Decrypt");
        }
    }
}
