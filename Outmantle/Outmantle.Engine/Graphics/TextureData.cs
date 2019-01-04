using System;
using System.Collections.Generic;
using System.Text;

namespace Outmantle.Engine.Graphics
{
    public struct TextureData
    {
        public byte[] Buffer { get; set; }
        public int Stride { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
