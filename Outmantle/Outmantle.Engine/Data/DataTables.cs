using Outmantle.Engine.Graphics;
using Outmantle.Engine.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Outmantle.Engine.Data
{
    public enum Tables
    {
        Texture     = 0,
        Animation   = 1,
        Sound       = 2,
        TileSet         = 3
    }
    public class DataTables
    {
        public DataSet Data;
        
        public DataTables()
        {
            Data = new DataSet();
        }

        
        public void Serialize()
        {
           try
            {
                Data.WriteXml(File.Create(DirectoryManager.DATA_DIRECTORY + "Tables.otm"));
                
            }
            catch
            {
                throw new Exception("ya boi could not serialize");
            }
        }

        public void Deserialize()
        {
            try
            {
                
                Data.ReadXml(File.Open(DirectoryManager.DATA_DIRECTORY + "Tables.otm", FileMode.Open));
                
            }
            catch
            {
                throw new Exception("ya boi could not deserialize");
            }
        }

        

        public void AddTexture(TextureData data, string name)
        {
            //Get current Index
            int index = Data.Tables[(int)Tables.Texture].Rows.Count;
            // calculate location in data file.
            long currentLocation;
            if(index == 0)
            {
                currentLocation = 0;
            }
            else
            {
                currentLocation = Convert.ToInt64((string)Data.Tables[(int)Tables.Texture].Rows[index - 1]["DataLocation"]) + ((Convert.ToInt64((string)Data.Tables[(int)Tables.Texture].Rows[index - 1]["Stride"]) * Convert.ToInt64((string)Data.Tables[(int)Tables.Texture].Rows[index - 1]["Height"])));

            }
            //Insert Texture to Table
            Data.Tables[(int)Tables.Texture].Rows.Add(index, name, data.Width, data.Height, currentLocation, data.Stride);
        }
        public void CreateTextureTable()
        {
            DataColumn column;
            DataTable table = new DataTable
            {
                TableName = "TextureData"
            };

            column = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "ID",
                Unique = true
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "TEXTURENAME",
                Unique = true
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "Width",
                Unique = false
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "Height",
                Unique = false
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = typeof(long),
                ColumnName = "DataLocation",
                Unique = true
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "Stride",
                Unique = false
            };
            table.Columns.Add(column);
            
            Data = new DataSet();
            Data.Tables.Add(table);
            table = null;
            column = null;
            //Serialize();

            
        }


    }
}
