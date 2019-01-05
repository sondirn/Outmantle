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
        Sound       = 2
    }
    public class DataTables
    {
        public DataSet Data;
        
        public DataTable test;
        
        public DataTables()
        {
            
        }

        public string DirectorManager { get; private set; }

        public void Serialize()
        {
           try
            {
                Data.WriteXml(File.Create(DirectoryManager.DATA_DIRECTORY + "Tables.otm"));
            }
            catch
            {
                OTM.Instance.Exit();
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
                OTM.Instance.Exit();
            }
        }

        public void AddTexture(TextureData data)
        {
            int index = Data.Tables[(int)Tables.Texture].Rows.Count;
            int previousIndexWidth = (int)Data.Tables[(int)Tables.Texture].Rows[index - 1]["Width"];
            int previousIndexHeight = (int)Data.Tables[(int)Tables.Texture].Rows[index - 1]["Height"];
            long currentLocation = (long)Data.Tables[(int)Tables.Texture].Rows[index - 1]["DataLocation"] +
                ((long)previousIndexWidth * (long)previousIndexHeight);
            Data.Tables[(int)Tables.Texture].Rows.Add(index, data.TextureName, data.Width, data.Height, currentLocation, data.Stride);

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
                ColumnName = "TEXTURE NAME",
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
               
            table.Rows.Add(0, "test", 16, 16, 0, 55);

            Data = new DataSet();
            Data.Tables.Add(table);
            table = null;
            column = null;
            Serialize();

            
        }


    }
}
