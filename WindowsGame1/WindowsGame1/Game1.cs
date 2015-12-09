using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//using Microsoft.Xna.Framework.

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Character player;
        Bad bad;
        MainScrolling bg1;
        MainScrolling bg2;
        List<Bullet> bullets = new List<Bullet>();
        List<Patform> platform = new List<Patform>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
            bg1 = new MainScrolling(Content.Load<Texture2D>("bg1"), new Rectangle(0,0,1024,480));
            bg2 = new MainScrolling(Content.Load<Texture2D>("bg2"), new Rectangle(1024, 0, 1024, 480));

            player = new Character(Content.Load<Texture2D>("walk"), Content.Load<Texture2D>("atack"),Content.Load<SpriteFont>("Font"), new Vector2(100, 375), 44, 40,bg1,bg2);
            bad = new Bad(Content.Load<Texture2D>("bad"), new Vector2(400, 360));

            platform.Add(new Patform(Content.Load<Texture2D>("platform"), new Vector2(150,290)));
            platform.Add(new Patform(Content.Load<Texture2D>("platform"), new Vector2(378, 280)));

            // TODO: use this.Content to load your game content here



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
       

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {



            player.Update(gameTime);
           


            if (bg1.BgRectangle.X + bg1.BgTexure.Width <= 0)
            {

                bg1.BgRectangle.X = bg2.BgRectangle.X + bg2.BgTexure.Width;
                
            }
            if (bg2.BgRectangle.X + bg2.BgTexure.Width <= 0)
            {
                bg2.BgRectangle.X = bg1.BgRectangle.X + bg2.BgTexure.Width;
               
            }

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Shoot();

            UpdateBullets();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (player.position.X >= 600) {
                    bad.position.X -= 2f;
                    foreach (Patform plat in platform)
                    {
                        plat.rec.X -= 2;

                    }

                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (player.position.X <= 50 )
                {
                    bad.position.X += 2f;

                    foreach (Patform plat in platform)
                    {
                        plat.rec.X += 2;

                    }

                }
            }


            // TODO: Add your update logic here

            foreach (Patform plat in platform)
            {
                if (player.rectangle.Topof(plat.rec)) {
                    player.position.Y = 0f;
                    player.hasJumped = false;
                }

            }

            bad.Update(gameTime);
                

            base.Update(gameTime);

        }

        public void CollisionPlatform() {

            foreach (Patform plat in platform)
            {
                /* if (player.rectangle.Bottom >= plat.rec.Top -5 && player.rectangle.Bottom <= plat.rec.Top +1 &&
                     player.rectangle.Right >= plat.rec.Left +5 && player.rectangle.Left >= plat.rec.Right)*/

                if (player.position.X <= plat.position.X + plat.texture.Width && player.position.X + player.textur.Width >= plat.position.X && player.position.Y <= plat.position.Y + plat.texture.Height && player.textur.Height + player.position.Y >= plat.position.Y)
                    player.position.Y = plat.position.Y-8 ;
                   // player.hasJumped = true;

            }
           


        }
        public void UpdateBullets() {
            
            foreach (Bullet bullet in bullets) {
                bullet.position += bullet.velocity;
                if (player.position.X >= bullet.position.X && player.position.Y >= bullet.position.Y) { 
                    bullet.isVisible = false;
                    player.live -= 2;
                }

                else if (Vector2.Distance(bullet.position, bad.position) > 350)
                {
                    bullet.isVisible = false;
                }

            }
            for (int i = 0; i < bullets.Count; i++) {
                if (!bullets[i].isVisible) {
                    bullets.RemoveAt(i);
                    i--;
                }
              }
        }


        public void Shoot() {
            Bullet newBullet = new Bullet(Content.Load<Texture2D>("bullet1"));
            newBullet.font = Content.Load<SpriteFont>("Font");
            newBullet.velocity = new Vector2( -2f,0);
            newBullet.position = bad.position + newBullet.velocity * 3;
            newBullet.isVisible = true;
            if (bullets.Count() < 2) {
                bullets.Add(newBullet);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();


            bg1.Draw(spriteBatch);
            bg2.Draw(spriteBatch);
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);

            }
            foreach (Patform plat in platform)
            {
                plat.Draw(spriteBatch);

            }
            bad.Draw(spriteBatch);
            player.Draw(spriteBatch);
           
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
static class Recthelp {
    public static bool Topof(this Rectangle rect1, Rectangle rect2) {

        return (rect1.Bottom >= rect2.Top - 5 && rect1.Bottom <= rect2.Top + 1 &&
                     rect1.Right >= rect2.Left + 5 && rect1.Left >= rect2.Right);

    }




}
