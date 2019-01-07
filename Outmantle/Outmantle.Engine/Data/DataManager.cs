using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Outmantle.Engine.Data
{
    public class DataManager
    {
        private DataTables dataTable;
        public Dictionary<string, Texture2D> TextureData;

        public DataManager()
        {
            TextureData = new Dictionary<string, Texture2D>();
            dataTable = new DataTables();
            dataTable.Deserialize();
        }
        /// <summary>
        /// Adds Data to Data Structure
        /// </summary>
        /// <param name="name"></param>
        public void AddTexture(string name)
        { 
            if (!TextureData.ContainsKey(name))
            {
                Texture2D tempTxtr = AssetLoader.LoadTexture(name, dataTable);
                TextureData.Add(name, tempTxtr);
            }
        }
        /// <summary>
        /// Gets Texture in Data Structure
        /// </summary>
        /// <param name="name"></param>
        public Texture2D GetTexture(string name) => TextureData.ContainsKey(name) ? TextureData[name] : throw new Exception("Could not get texture from data structure");
        /// <summary>
        /// Clears/Flushes textures in data structure
        /// </summary>
        public void FlushTextureData() => TextureData.Clear();
        /// <summary>
        /// Removes specific texture in data structure.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        public void RemoveTexture(string name, Texture2D texture)
        {
            if (TextureData.ContainsKey(name))
            {
                TextureData.Remove(name);
            }
        }


    }
}
