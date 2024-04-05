using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using VideoLibrary;
using MediaToolkit;
using MediaToolkit.Model;
using System.IO;
using System.Windows.Forms;
using T2UI.UserControls;
using T2UI.Properties;
using System.Web;
using System.Diagnostics;

namespace T2UI.UserControls
{
    public partial class UserControlDownloadingMP3 : UserControl
    {
        private void addUserControl(UserControl userControl)
        {
            Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void SaveMP3(string SaveToFolder, string VideoURL, string MP3Name)
        {
            var source = @SaveToFolder;
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(VideoURL);
            File.WriteAllBytes(source + vid.FullName, vid.GetBytes());
            string vidname = vid.FullName;
            vidname = vidname.Remove(vidname.Length - 4);
            label1.Text = "Converting...";
            var inputFile = new MediaFile { Filename = source + vid.FullName };
            var outputFile = new MediaFile { Filename = $"{MP3Name}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }
            File.Delete(source + vid.FullName);
        }

        public UserControlDownloadingMP3()
        {
            InitializeComponent();
        }
        private void UserControlDownloadingMP3_Load(object sender, EventArgs e)
        {
            if (Settings.Default["SoundEnabled"].Equals(true))
            {
                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                simpleSound.Play();
            }
            pictureBox1.Hide();
            label2.Hide();
            pictureBox2.Hide();
            guna2Button2.Text = "No, lemme out";
            guna2Button3.Hide();
            guna2Button1.Hide();
            guna2Button2.Hide();
            string ytlink = UserControlDownMP3.ytlink;
            var vid = YouTube.Default.GetVideo(ytlink);
            string vidname = vid.FullName;
            vidname = vidname.Remove(vidname.Length - 4);
            var uri = new Uri(ytlink);
            // you can check host here => uri.Host <= "www.youtube.com"
            var query = HttpUtility.ParseQueryString(uri.Query);
            var videoId = string.Empty;
            if (query.AllKeys.Contains("v"))
            {
                videoId = query["v"];
            }
            else
            {
                videoId = uri.Segments.Last();
            }
            pictureBox1.ImageLocation = @"https://i3.ytimg.com/vi/" + videoId + "/maxresdefault.jpg";
            pictureBox1.Show();
            pictureBox2.Show();
            label2.Show();
            label1.Text = "Are you sure want to download this Youtube video as MP3?";
            label2.Text = vidname;
            guna2Button1.Show();
            guna2Button2.Show();
        }

        private void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Button1.Hide();
            guna2Button2.Hide();
            string ytlink = UserControlDownMP3.ytlink;
            label1.Text = "Downloading...";
            var vid = YouTube.Default.GetVideo(ytlink);
            string where = Settings.Default["MP3DownPath"].ToString() + @"\";
            System.IO.Directory.CreateDirectory(where);
            string vidname = vid.FullName;
            vidname = vidname.Remove(vidname.Length - 4);
            string mp3where = where + vidname;
            SaveMP3(where, ytlink, mp3where);
            if (Settings.Default["SoundEnabled"].Equals(true))
            {
                SoundPlayer simpleSound = new SoundPlayer("suc.wav");
                simpleSound.Play();
            }
            label1.Text = "Done!";
            guna2Button3.Show();
            guna2Button2.Show();
            guna2Button2.Text = "Exit";
        }

        private void guna2Button2_MouseClick(object sender, MouseEventArgs e)
        {
            UserControlDownMP3 uc = new UserControlDownMP3();
            addUserControl(uc);
        }

        private void guna2Button3_MouseClick(object sender, MouseEventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer("suc.wav");
            simpleSound.Play();
            string where = Settings.Default["MP3DownPath"].ToString() +@"\";
            Process.Start(where);
        }
    }
}
