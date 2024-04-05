using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T2UI.Properties;

namespace T2UI.UserControls
{
    public partial class UserControlTiofe2 : UserControl
    {
        public UserControlTiofe2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { checkBox2.Checked = false; inspacecheckbox.Visible = true; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            { checkBox1.Checked = false; inspacecheckbox.Visible = false; }
        }

        private void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
                label1.Text = "(ㆆ_ㆆ) Please enter input";
            }
            else
            {
                if (checkBox1.Checked && !checkBox2.Checked)
                {
                    string fileName = "TioTemp.txt";
                    string outputfn = "TioOut.txt";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                    File.WriteAllText(fileName, textBox1.Text);
                    if (!inspacecheckbox.Checked)
                    {
                        string ToTio = "ToTiofeWS.exe";
                        var process = Process.Start(ToTio);
                        process.WaitForExit();
                    }
                    else
                    {
                        string ToTio = "ToTiofe.exe";
                        var process = Process.Start(ToTio);
                        process.WaitForExit();
                    }
                    string output = File.ReadAllText(outputfn).Remove(File.ReadAllText(outputfn).Length - 1);
                    textBox2.Text = output;
                    if (Settings.Default["SoundEnabled"].Equals(true))
                    {
                        SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                        simpleSound.Play();
                    }
                    label1.Text = "(●'◡'●)";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                }
                else if (!checkBox1.Checked && checkBox2.Checked)
                {
                    string fileName = "TioTemp.txt";
                    string FromTio = "FromTiofe.exe";
                    string outputfn = "TioOut.txt";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                    File.WriteAllText(fileName, textBox1.Text);
                    var process = Process.Start(FromTio);
                    process.WaitForExit();
                    string output = File.ReadAllText(outputfn).Remove(File.ReadAllText(outputfn).Length - 1);
                    textBox2.Text = output;
                    if (Settings.Default["SoundEnabled"].Equals(true))
                    {
                        SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                        simpleSound.Play();
                    }
                    label1.Text = "(●'◡'●)";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                }
                else if (!checkBox1.Checked && !checkBox2.Checked)
                {
                    if (Settings.Default["SoundEnabled"].Equals(true))
                    {
                        SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                        simpleSound.Play();
                    }
                    label1.Text = "(ㆆ_ㆆ) Please select a translation option";
                }
            }
        }

        private void guna2Button3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
                label1.Text = "(ㆆ_ㆆ) There's nothing to copy!";
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(textBox2.Text.Remove(textBox2.Text.Length - 1));
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                    simpleSound.Play();
                }
                label1.Text = "(●'◡'●) Copied!";
            }
        }

        private void guna2Button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText();
                textBox1.Text = clipboardText;
                if (checkBox1.Checked && !checkBox2.Checked)
                {
                    string fileName = "TioTemp.txt";
                    string outputfn = "TioOut.txt";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                    File.WriteAllText(fileName, textBox1.Text);
                    if (!inspacecheckbox.Checked)
                    {
                        string ToTio = "ToTiofeWS.exe";
                        var process = Process.Start(ToTio);
                        process.WaitForExit();
                    }
                    else
                    {
                        string ToTio = "ToTiofe.exe";
                        var process = Process.Start(ToTio);
                        process.WaitForExit();
                    }
                    string output = File.ReadAllText(outputfn).Remove(File.ReadAllText(outputfn).Length - 1);
                    textBox2.Text = output;
                    if (Settings.Default["SoundEnabled"].Equals(true))
                    {
                        SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                        simpleSound.Play();
                    }
                    label1.Text = "(●'◡'●)";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                }
                else if (!checkBox1.Checked && checkBox2.Checked)
                {
                    string fileName = "TioTemp.txt";
                    string FromTio = "FromTiofe.exe";
                    string outputfn = "TioOut.txt";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                    File.WriteAllText(fileName, textBox1.Text);
                    var process = System.Diagnostics.Process.Start(FromTio);
                    process.WaitForExit();
                    string output = File.ReadAllText(outputfn).Remove(File.ReadAllText(outputfn).Length - 1);
                    textBox2.Text = output;
                    if (Settings.Default["SoundEnabled"].Equals(true))
                    {
                        SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                        simpleSound.Play();
                    }
                    label1.Text = "(●'◡'●)";
                    File.Delete(fileName);
                    File.Delete(outputfn);
                }
                else if (!checkBox1.Checked && !checkBox2.Checked)
                {
                    if (Settings.Default["SoundEnabled"].Equals(true))
                    {
                        SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                        simpleSound.Play();
                    }
                    label1.Text = "(ㆆ_ㆆ) Please select a translation option";
                }
            }
            else
            {
                if (Settings.Default["SoundEnabled"].Equals(true))
                {
                    SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                    simpleSound.Play();
                }
                label1.Text = "(ㆆ_ㆆ) Please check your Clipboard!";
            }
        }

        private void guna2Button5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = "Hi " + Environment.UserName + "!";
            textBox2.Text = "";
            textBox1.Text = "";
            if (Settings.Default["SoundEnabled"].Equals(true))
            {
                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                simpleSound.Play();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Settings.Default["T2EnterToAction"].Equals(true))
                {
                    if (textBox1.Text == "" || textBox1.Text == " ")
                    {
                        if (Settings.Default["SoundEnabled"].Equals(true))
                        {
                            SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                            simpleSound.Play();
                        }
                        label1.Text = "(ㆆ_ㆆ) Please enter input";
                    }
                    else
                    {
                        if (checkBox1.Checked && !checkBox2.Checked)
                        {
                            string fileName = "TioTemp.txt";
                            string outputfn = "TioOut.txt";
                            File.Delete(fileName);
                            File.Delete(outputfn);
                            File.WriteAllText(fileName, textBox1.Text);
                            if (!inspacecheckbox.Checked)
                            {
                                string ToTio = "ToTiofeWS.exe";
                                var process = Process.Start(ToTio);
                                process.WaitForExit();
                            }
                            else
                            {
                                string ToTio = "ToTiofe.exe";
                                var process = Process.Start(ToTio);
                                process.WaitForExit();
                            }
                            string output = File.ReadAllText(outputfn).Remove(File.ReadAllText(outputfn).Length - 1);
                            textBox2.Text = output;
                            if (Settings.Default["SoundEnabled"].Equals(true))
                            {
                                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                                simpleSound.Play();
                            }
                            label1.Text = "(●'◡'●)";
                            File.Delete(fileName);
                            File.Delete(outputfn);
                        }
                        else if (!checkBox1.Checked && checkBox2.Checked)
                        {
                            string fileName = "TioTemp.txt";
                            string FromTio = "FromTiofe.exe";
                            string outputfn = "TioOut.txt";
                            File.Delete(fileName);
                            File.Delete(outputfn);
                            File.WriteAllText(fileName, textBox1.Text);
                            var process = Process.Start(FromTio);
                            process.WaitForExit();
                            string output = File.ReadAllText(outputfn).Remove(File.ReadAllText(outputfn).Length - 1);
                            textBox2.Text = output;
                            if (Settings.Default["SoundEnabled"].Equals(true))
                            {
                                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                                simpleSound.Play();
                            }
                            label1.Text = "(●'◡'●)";
                            File.Delete(fileName);
                            File.Delete(outputfn);
                        }
                        else if (!checkBox1.Checked && !checkBox2.Checked)
                        {
                            if (Settings.Default["SoundEnabled"].Equals(true))
                            {
                                SoundPlayer simpleSound = new SoundPlayer("fai.wav");
                                simpleSound.Play();
                            }
                            label1.Text = "(ㆆ_ㆆ) Please select a translation option";
                        }
                    }
                }    
            }
        }
    }
}
