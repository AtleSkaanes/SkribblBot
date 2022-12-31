using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace SkribblBot
{
    public partial class Form1 : Form
    {
        // Classes
        Click click = new Click();
        GlobalKeyboardHook globalKeyboardHook = new GlobalKeyboardHook();


        // Bools
        bool gotImage = false;
        bool isConfigured = false;
        bool isDrawing = false;

        // Configure size
        bool isConfiguring = false;
        bool firstPressed = false;
        bool secondPressed = false;
        int[] firstPos = new int[2];
        int[] secondPos = new int[2];
        Bitmap resizedImg = null;

        // Strings
        string currentFilePath = string.Empty;
        string[] accepetedFileTypes = { ".png", ".jpeg", ".jpg" };

        int[] acceptedInput = { 75, 73, 85, 89 };
                             //  k   i   u   y
        
        // Image bitmap
        Bitmap imgBitmap = null;

        // Image dimensions
        int originalWidth;
        int originalHeight;
        int newWidth;
        int newHeight;

        // Timer
        int timerSeconds;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.TopMost = true;

            globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in filePaths)
            {
                if (accepetedFileTypes.Any(element => Path.GetExtension(file) == element))
                {
                    filePathText.ForeColor = Color.Black;
                    currentFilePath = file;
                    filePathText.Text = currentFilePath;
                    //imgBitmap = new Bitmap(currentFilePath);
                    imgBitmap = new Bitmap(System.Drawing.Image.FromFile(currentFilePath));
                    pictureBoxOrigin.Image = System.Drawing.Image.FromFile(currentFilePath);
                    GrayScaleImage();
                }
                else
                {
                    filePathText.ForeColor = Color.Red;
                    filePathText.Text = Path.GetExtension(file)+" is not a supported file extension";
                }
                StartButton.Enabled = (isConfigured && gotImage);

                if (isConfigured) { ChangeImgSize(); }

            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            ConfigureSize();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitApp(true);
        }

        private void DrawingProgressBar_Click(object sender, EventArgs e)
        {
        }

        void GrayScaleImage()
        {
            // Get image dimensions
            originalWidth = imgBitmap.Width;
            originalHeight = imgBitmap.Height;

            // color of the pixel
            Color pixel;

            //Grayscale
            for(int y = 0; y < originalHeight; y++)
            {
                for (int x = 0; x < originalWidth; x++)
                {
                    // Get pixel value
                    pixel = imgBitmap.GetPixel(x, y);

                    // Get ARGB from pixel value
                    int A = pixel.A;
                    int R = pixel.R;
                    int G = pixel.G;
                    int B = pixel.B;

                    // Get average
                    int average = (R + G + B) / 3;

                    // Turn Contrast up to max (Only full balck and full white allowed)
                    if (average >= 127)
                    {
                        average = 255;
                    }
                    else { average = 0; }

                    // Set new pixel value
                    imgBitmap.SetPixel(x,y,Color.FromArgb(A,average,average,average));
                }
            }

            // Load grayscale Image in picturebox
            pictureBoxGray.Image = imgBitmap;
            gotImage = true;
        }

        public void ConfigureSize()
        {
            ConfigureButton.Text = "Cancel (u)";

            isConfiguring = true;
            firstPressed = false;
            secondPressed = false;         
        }

        void FirstConfigPressed()
        {
            firstPressed = true;
            firstPos[0] = Cursor.Position.X;
            firstPos[1] = Cursor.Position.Y;
        }

        void SecondConfigPressed()
        {
            secondPressed = true;
            secondPos[0] = Cursor.Position.X;
            secondPos[1] = Cursor.Position.Y;
            ConfigureButton.Text = "Configure (u)";
            if (gotImage) { ChangeImgSize(); }
            isConfigured = true;
            isConfiguring = false;
            StartButton.Enabled = (isConfigured && gotImage);
        }

        // src: https://stackoverflow.com/a/10445101
        void ChangeImgSize()
        {
            int width = Math.Abs(firstPos[0] - secondPos[0]);
            int height = Math.Abs(firstPos[1] - secondPos[1]);

            if (width <= 2 || height <= 2)
            {
                MessageBox.Show("No pixels selected");
                return;
            }

            int newWidth;
            int newHeight;

            //float scale = Math.Min(width / imgBitmap.Width, height / imgBitmap.Height);
            if (imgBitmap.Height >= imgBitmap.Width)
            {
                newWidth = (int)(height * imgBitmap.Width / imgBitmap.Height);
                newHeight = (height);
            }
            else
            {
                newWidth = (width);
                newHeight = (int)(width * imgBitmap.Height / imgBitmap.Width);
            }

            resizedImg = new Bitmap((int)width, (int)height);
            var graph = Graphics.FromImage(resizedImg);
            var brush = new SolidBrush(Color.White);

            graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
            graph.DrawImage(imgBitmap, ((int)width - newWidth) / 2, ((int)height - newHeight) / 2, newWidth, newHeight);

            resizedImg.Save("Resized.png");

            pictureBoxGray.Image = resizedImg;
            SizeLabel.Text = "new Size: "+width+"x"+height+"  original size: "+originalWidth+"x"+originalHeight;

        }

        void DrawImage()
        {
            timerSeconds = 0;

            TimeSpan startTime = DateTime.Now.TimeOfDay;
            TimeSpan runTime;

            if (!isConfigured || !gotImage) return;

            DrawingProgressBar.Maximum = resizedImg.Width * resizedImg.Height;

            StartButton.Text = "Stop (y)";
            StartButton.ForeColor = Color.Red;
            isDrawing = true;

            int startX = Math.Min(firstPos[0], secondPos[0]);
            int startY = Math.Min(firstPos[1], secondPos[1]);

            for (int y = 0; y < resizedImg.Height; y++)
            {
                for (int x = 0; x < resizedImg.Width; x++)
                {
                    MoveCursor(x+startX, y+startY);
                    if (resizedImg.GetPixel(x, y).R == 0)
                    {
                        click.leftClick();
                        Thread.Sleep(1);
                    }
                    DrawingProgressBar.Value = y * resizedImg.Width + x;
                    
                    //TimerLabel.Text = runTime.ToString();

                    if (!isDrawing) { break; }
                }
                if (!isDrawing) { break; }
            }
            isDrawing = false;
            if (!isDrawing)
            {
                StartButton.Text = "Start (y)";
                StartButton.ForeColor = Color.Black;
            }
            DrawingProgressBar.Value = 0;
            runTime = DateTime.Now.TimeOfDay - startTime;
            TimerLabel.Text = runTime.ToString("mm\\:ss");
        }

        void MoveCursor(int x, int y)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(x,y);
        }

        void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            //if (acceptedInput.All(element => e.KeyboardData.VirtualCode != element))
                //return;

            // y
            if (e.KeyboardData.VirtualCode == 89 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                if (!isDrawing)
                {
                    DrawImage();
                }
                else { isDrawing = false; }
                Thread.Sleep(50);
            }

            // u
            if (e.KeyboardData.VirtualCode == 85 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                ConfigureSize();
                Thread.Sleep(50);
            }

            // i
            if (e.KeyboardData.VirtualCode == 73 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                ExitApp(true);
                Thread.Sleep(50);
            }

            if (isConfiguring)
            {
                if (!secondPressed && firstPressed)
                {
                    if (e.KeyboardData.VirtualCode == 75 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
                    {
                        SecondConfigPressed();
                        Thread.Sleep(50);
                    }
                }

                if (!firstPressed)
                {
                    if (e.KeyboardData.VirtualCode == 75 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
                    {
                        FirstConfigPressed();
                        Thread.Sleep(50);
                    }
                }
            }
        }

        void ExitApp(bool showDialog)
        {
            if (showDialog)
            {
                DialogResult exitDialog = MessageBox.Show("Do you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (exitDialog == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else{ this.Close(); }
        }
    }
}