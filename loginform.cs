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
using T2UI.Properties;

namespace T2UI
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
            Settings.Default["easterlogin"] = 0;
            Settings.Default.Save();
        }
        private void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            bool istrue = false;
            if(guna2TextBox1.Text =="tiofethefox" && guna2TextBox2.Text == "therealdev")
            {
                istrue = true;
            }
            if (guna2TextBox1.Text == "dovethebird" && guna2TextBox2.Text == "therealtester")
            {
                istrue = true;
            }
            if (guna2TextBox1.Text == "thirdtheperson" && guna2TextBox2.Text == "whoami")
            {
                istrue = true;
            }
            if (istrue==true)
            {
                username = guna2TextBox1.Text;
                Settings.Default["username"] = username;
                Settings.Default.Save();
                new Form1().Show();
                this.Hide();
            }
            else
            {
                Settings.Default["easterlogin"] = Convert.ToInt32(Settings.Default["easterlogin"]) + 1;
                Settings.Default.Save();
                if (Convert.ToInt32(Settings.Default["easterlogin"]) == 3)
                {
                    MessageBox.Show("Can you try harder?", "Huh?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(Settings.Default["easterlogin"]) == 4)
                {
                    MessageBox.Show("For real?", "Ehh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(Settings.Default["easterlogin"]) == 5)
                {
                    MessageBox.Show("You're trying to get into my app without my permission, right?", "What are u doing?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(Settings.Default["easterlogin"]) == 6)
                {
                    MessageBox.Show("Get tf out of my app, NOW!", "Fxck u!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Try again lul", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                guna2TextBox2.Text = "";
                guna2TextBox1.Text = "";
                guna2TextBox1.Focus();
            }
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CheckBox1.Checked)
            {
                guna2TextBox2.PasswordChar = '\0';
            }
            else
            {
                guna2TextBox2.PasswordChar = '●';
            }    
        }
        public static string username = "";
        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool istrue = false;
                if (guna2TextBox1.Text == "tiofethefox" && guna2TextBox2.Text == "therealdev")
                {
                    istrue = true;
                }
                if (guna2TextBox1.Text == "dovethebird" && guna2TextBox2.Text == "therealtester")
                {
                    istrue = true;
                }
                if (guna2TextBox1.Text == "thirdtheperson" && guna2TextBox2.Text == "whoami")
                {
                    istrue = true;
                }
                if (istrue == true)
                {
                    username = guna2TextBox1.Text;
                    Settings.Default["username"] = username;
                    Settings.Default.Save();
                    new Form1().Show();
                    this.Hide();
                }
                else
                {
                    Settings.Default["easterlogin"] = Convert.ToInt32(Settings.Default["easterlogin"]) + 1;
                    Settings.Default.Save();
                    if (Convert.ToInt32(Settings.Default["easterlogin"]) == 3)
                    {
                        MessageBox.Show("Can you try harder?", "Huh?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                    else if (Convert.ToInt32(Settings.Default["easterlogin"]) == 4)
                    {
                        MessageBox.Show("For real?", "Ehh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToInt32(Settings.Default["easterlogin"]) == 5)
                    {
                        MessageBox.Show("You're trying to get into my app without my permission, right?", "What are u doing?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToInt32(Settings.Default["easterlogin"]) == 6)
                    {
                        MessageBox.Show("Get tf out of my app, NOW!", "Fxck u!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Try again lul", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                    guna2TextBox2.Text = "";
                    guna2TextBox1.Text = "";
                    guna2TextBox1.Focus();
                }
            }
        }

        private void loginform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void loginform_Shown(object sender, EventArgs e)
        {
            if (Settings.Default["AutoLogin"].Equals(true))
            {
                username = Settings.Default["username"].ToString();
                new Form1().Show();
                this.Hide();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://t.me/htiofe");
        }
    }
}
