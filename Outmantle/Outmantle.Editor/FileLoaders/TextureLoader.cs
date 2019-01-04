using Outmantle.Engine.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace Outmantle.Editor.FileLoaders
{
    public static class TextureLoader
    {
        public static TextureData FromFile(string filePath)
        {
            //create bitmap
            Bitmap bm = new Bitmap(@filePath);
            //lock bits in bitmap
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
            //get address of first line
            IntPtr ptr = bmData.Scan0;
            //get size of buffer
            int stride = bmData.Stride;
            int bufferSize = stride * bm.Height;
            //create data buffer
            byte[] bytes = new byte[bufferSize];
            Marshal.Copy(ptr, bytes, 0, bytes.Length);
            //unlock bitmap
            bm.UnlockBits(bmData);
            //return textureData
            return new TextureData {
                Buffer = bytes,
                BufferSize = bufferSize,
                Stride = stride,
                Width = bm.Width,
                Height = bm.Height
            };

        }
    }
}
