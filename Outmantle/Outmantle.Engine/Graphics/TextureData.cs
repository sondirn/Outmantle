namespace Outmantle.Engine.Graphics
{
    public class TextureData
    {
        public byte[] Buffer { get; set; }
        public int BufferSize { get; set; }
        public int Stride { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string TextureName { get; set; }
    }
}
