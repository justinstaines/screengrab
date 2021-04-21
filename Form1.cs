using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

/// <summary>
/// (C) Copyright Justin Staines 2021. Very simple Windows form app. Copies the screen. Pastes it back in the window and also saves a copy to the same directory.
/// </summary>

namespace WindowsFormsApp3screen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void DrawImage()
        {
            
            Graphics x = this.CreateGraphics();
            x.DrawImage(memoryImage, new Rectangle(0, 0, memoryImage.Width, memoryImage.Height));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            DrawImage();
            memoryImage.Save("page.png");
        }
    }
}
