using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Outmantle.Engine.Graphics
{
    public static class TextureGenerator
    {
        public static Texture2D BufferToTexture(TextureData data)
        {
            //create blank texture
            Texture2D result = new Texture2D(OTM.Instance.GraphicsDevice, data.Width, data.Height);
            //create color data
            Color[] cData = new Color[data.Width * data.Height];
            //insert data from buffer into color data
            int count = 0;
            for(int column = 0; column < data.Height; column++)
            {
                for(int row = 0; row < data.Width; row++)
                {
                    byte b = data.Buffer[(column * data.Stride) + (row * 4)];
                    byte g = data.Buffer[(column * data.Stride) + (row * 4) + 1];
                    byte r = data.Buffer[(column * data.Stride) + (row * 4) + 2];
                    byte a = data.Buffer[(column * data.Stride) + (row * 4) + 3];
                    cData[count++] = new Color(r, g, b, a);
                    //System.Console.WriteLine(data.Stride);
                }
            }
            //insert color data into texture
            result.SetData(cData);
            //return texture
            return result;
        }
    }
}
