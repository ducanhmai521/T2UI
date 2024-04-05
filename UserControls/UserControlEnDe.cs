using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Media;
using T2UI.Properties;

namespace T2UI.UserControls
{
    public partial class UserControlEnDe : UserControl
    {
        byte[] abc;
        byte[,] table;
        public UserControlEnDe()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Multiselect = false;
            if (od.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox1.Text = od.FileName;
            }
        }

        private void UserControlEnDe_Load(object sender, EventArgs e)
        {
            // init abc and table
            abc = new byte[256];
            for (int i = 0; i < 256; i++)
                abc[i] = Convert.ToByte(i);

            table = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    table[i, j] = abc[(i + j) % 256];
                }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Check input values
            if (!File.Exists(guna2TextBox1.Text))
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
                MessageBox.Show("File does not exist.");
                return;
            }
            if (String.IsNullOrEmpty(guna2TextBox2.Text))
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
                MessageBox.Show("Password empty. Please enter your password");
                return;
            }

            // Get file content and key for encrypt/decrypt
            try
            {
                byte[] fileContent = File.ReadAllBytes(guna2TextBox1.Text);
                byte[] passwordTmp = Encoding.ASCII.GetBytes(guna2TextBox2.Text);
                byte[] keys = new byte[fileContent.Length];
                for (int i = 0; i < fileContent.Length; i++)
                    keys[i] = passwordTmp[i % passwordTmp.Length];

                // Encrypt
                byte[] result = new byte[fileContent.Length];

                if (guna2RadioButton2.Checked)
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueIndex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == value)
                            {
                                valueIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        result[i] = table[keyIndex, valueIndex];
                    }
                }
                // Decrypt
                else
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueIndex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (table[keyIndex, j] == value)
                            {
                                valueIndex = j;
                                break;
                            }
                        result[i] = abc[valueIndex];
                    }
                }

                // Save result to new file with the same extension
                String fileExt = Path.GetExtension(guna2TextBox1.Text);
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Files (*" + fileExt + ") | *" + fileExt;
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sd.FileName, result);
                }
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                    simpleSound.Play();
                }
                MessageBox.Show("Done!");
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
            }
            catch
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
                MessageBox.Show("File is in use. Close other program is using this file and try again.");
                return;
                }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(guna2TextBox1.Text))
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSoundha = new SoundPlayer("fai.wav");
                    simpleSoundha.Play();
                }
                MessageBox.Show("File does not exist.");
                return;
            }
            string where = guna2TextBox1.Text;
            string filename = Path.GetFileName(where);
            where = where.Remove(where.Length - filename.Length);
            if (Settings.Default["SoundEnabled"].Equals(true))
            {
                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                simpleSound.Play();
            }
            Process.Start(where);
        }
    }
}
