using Microsoft.VisualBasic.Devices;
using NetDiscordRpc;
using NetDiscordRpc.Core.Logger;
using NetDiscordRpc.RPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDLogoRender
{
    public partial class Form1 : Form
    {
        Form2 setform;
        int xFlip = 1;
        int yFlip = 1;
        int wd = 818, hg = 497;
        bool mouse_holding = false;
        public static int speed = 4;
        public static Size dvdlogosize;
        public Form1(int speed)
        {
            if (object.Equals(speed, null))
            {
                speed = 4;
            }
            dvdlogosize = new Size(262, 115);
            InitializeComponent();
            StartUp();
        }

        private async void StartUp()
        {
            await Task.Delay(1000);
            DiscordRPC Discord_RPC = new DiscordRPC("1099499188011667487");
            Discord_RPC.Logger = new ConsoleLogger();
            Discord_RPC.Initialize();
            Discord_RPC.SetPresence(new NetDiscordRpc.RPC.RichPresence()
            {
                Assets = new NetDiscordRpc.RPC.Assets()
                {
                    LargeImageKey = "dvd",
                    LargeImageText = "DVD Render"
                },
                State = "Waiting for the DVD Logo to hit the corner",
                Buttons = new NetDiscordRpc.RPC.Button[]
                {
                    new NetDiscordRpc.RPC.Button()
                    {
                        Label = "Download DVD Logo Renderer",
                        Url = "https://github.com/Deniz-seckin55/dvdrenderer"
                    }
                },

                Timestamps = Timestamps.Now
            });

            Discord_RPC.Invoke();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + speed * xFlip, pictureBox1.Location.Y + speed * yFlip);
            if (pictureBox1.Location.X + pictureBox1.Width >= wd)
            {
                xFlip = -1;
            }

            if (pictureBox1.Location.X <= 0)
            {
                xFlip = 1;
            }

            if (pictureBox1.Location.Y + pictureBox1.Height >= hg)
            {
                yFlip = -1;
            }

            if (pictureBox1.Location.Y <= 0)
            {
                yFlip = 1;
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            wd = ActiveForm.Size.Width;
            hg = ActiveForm.Size.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_holding = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_holding = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pictureBox1.Size = dvdlogosize;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                setform = new Form2();
                setform.ShowDialog();
            }

            if (e.KeyCode == Keys.H)
            {
                if (ActiveForm.FormBorderStyle == FormBorderStyle.None)
                {
                    ActiveForm.FormBorderStyle = FormBorderStyle.Sizable;
                }
                else
                {
                    ActiveForm.FormBorderStyle = FormBorderStyle.None;
                }
            }

            if (e.KeyCode == Keys.O)
            {
                ActiveForm.TopMost = !ActiveForm.TopMost;
            }
        }
    }
}
