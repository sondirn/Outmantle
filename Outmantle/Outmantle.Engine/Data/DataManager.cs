using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Outmantle.Engine.Data
{
    public class DataManager
    {
        public Dictionary<string, Texture2D> TextureData;

        public DataManager()
        {
            TextureData = new Dictionary<string, Texture2D>();
        }

        public void AddTexture(string name, Texture2D texture)
        {
            if (!TextureData.ContainsKey(name))
            {
                TextureData.Add(name, texture);
            }
        }

        public void FlushTextureData()
        {
            TextureData.Clear();
        }

        public void RemoveTexture(string name, Texture2D texture)
        {
            if (TextureData.ContainsKey(name))
            {
                TextureData.Remove(name);
            }
        }


    }
}
