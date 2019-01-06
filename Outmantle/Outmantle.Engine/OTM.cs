using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Outmantle.Editor.FileLoaders;
using Outmantle.Engine.Data;
using Outmantle.Engine.Graphics;
using Outmantle.Engine.Utils;

namespace Outmantle.Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public sealed class OTM : Game
    {
        private static OTM instance = null;
        private static object padlock = new object();
        public static OTM Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new OTM();
                    }
                    return instance;
                }
                
            }
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        DataTables table;
        bool test;
        
        public OTM()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            instance = this;
            test = false;
            table = new DataTables();
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            table.Deserialize();
            //table.CreateTextureTable();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!test)
            {
                
                //AssetLoader.saveTexture(Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png").Buffer);
                texture = AssetLoader.LoadTexture("whatwhat1", table);
                table.AddTexture(Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png"), "whatwhat");
                table.AddTexture(Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png"), "whatwhat1");
                int test1 = Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png").BufferSize;
                int test2 = Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png").Stride;
                int test3 = Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png").Height;
                //AssetLoader.saveTexture(Editor.FileLoaders.TextureLoader.FromFile(Environment.CurrentDirectory + "/Data/test.png").Buffer);
                
                //table.Serialize();
                //table.Serialize();
                test = true;

            }

            

            base.Update(gameTime);
        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(texture: texture, position: Vector2.Zero);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
