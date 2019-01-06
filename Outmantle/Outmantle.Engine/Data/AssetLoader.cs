using Microsoft.Xna.Framework.Graphics;
using Outmantle.Engine.Graphics;
using Outmantle.Engine.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Outmantle.Engine.Data
{
    public static class AssetLoader
    {

        public static Texture2D LoadTexture(string AssetName, DataTables table)
        {
            
            DataRow[] row = table.Data.Tables[(int)Tables.Texture].Select("TEXTURENAME = '" + AssetName + "'");
            int index = Int32.Parse((string)row[0].ItemArray.GetValue(0));
            
            
            int tStride = Int32.Parse((string)table.Data.Tables[(int)Tables.Texture].Rows[index]["Stride"]);
            int tHeight = Int32.Parse((string)table.Data.Tables[(int)Tables.Texture].Rows[index]["Height"]);
            int tbufferSize = (int)tStride * (int)tHeight;
            byte[] tBuffer = new byte[tbufferSize];
            using(BinaryReader reader = new BinaryReader(new FileStream(DirectoryManager.DATA_DIRECTORY + "Data1.otd", FileMode.Open)))
            {
                reader.BaseStream.Seek(Convert.ToInt64((string)table.Data.Tables[(int)Tables.Texture].Rows[(int)index]["DataLocation"]), SeekOrigin.Begin);
                reader.Read(tBuffer, 0, tbufferSize);
                reader.BaseStream.Close();
                reader.Close();
            }
            TextureData resultData = new TextureData
            {
                Buffer = tBuffer,
                BufferSize = tbufferSize,
                Stride = tStride,
                Height = tHeight,
                Width = Int32.Parse((string)table.Data.Tables[(int)Tables.Texture].Rows[index]["Width"]),
                TextureName = (string)table.Data.Tables[(int)Tables.Texture].Rows[(int)index]["TEXTURENAME"]
                
                
            };

            Texture2D result = TextureGenerator.BufferToTexture(resultData);
            return result;
        }

        public static void saveTexture(byte[] data)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(DirectoryManager.DATA_DIRECTORY + "Data1.otd", FileMode.Append)))
            {
                writer.Write(data);
                writer.Close();
            }
        }


    }
}
