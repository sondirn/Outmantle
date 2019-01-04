using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Outmantle.Engine.Graphics
{
    public static class TextureGenerator
    {
        public static Texture2D bufferToTexture(TextureData buffer)
        {
            Texture2D result = new Texture2D(OTM.Instance.GraphicsDevice, buffer.Width, buffer.Height);
            Color[] cData = new Color[buffer.Width * buffer.Height];
            for(int column = 0; column < buffer.Width; column++)
            {
                for (int row = 0; row < buffer.Height; row++)
                {
                    byte g = buffer.Buffer[]
                    
                }
            }
        }
    }
}
