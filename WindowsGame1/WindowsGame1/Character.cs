using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class Character
    {
      public  Texture2D textur;
        Texture2D atack;

        SpriteFont font;
      public  Rectangle rectangle;
        Vector2 orignoalPosition;
      public  Vector2 position;
      public  Vector2 velocity;

        int frameHeight;
        int framewidth;
        int currentFrame;
      public  int live = 20;

        float timer;
        float interval = 125;

     public   bool hasJumped = false;
        bool hasAtack = false;

        MainScrolling bg1,bg2;

        // Keyboard ks = Keyboard.GetState;
        public Character(Texture2D newtexure,Texture2D newatck,SpriteFont newfont, Vector2 newPosition, int newframeHeight, int newframewidth, MainScrolling newbg1, MainScrolling newbg2) {
            textur = newtexure;
            atack = newatck;
            font = newfont;
            position = newPosition;
            frameHeight = newframeHeight;
            framewidth = newframewidth;
            bg1 = newbg1;
            bg2 = newbg2;
        }
        public void Update(GameTime gameTime) {
            rectangle = new Rectangle(currentFrame * frameHeight,0,framewidth,frameHeight);
            orignoalPosition = new Vector2(rectangle.Width/2, rectangle.Height / 2);
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {

                hasAtack = true;
            }else hasAtack = false;
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                right(gameTime);
                velocity.X = 3;
                if (position.X >= 600)
                {

                    bg1.update();
                    bg2.update();
                    position.X = 600;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                left(gameTime);
                velocity.X = -3;
                if (position.X <= 50)
                {

                    bg1.updaterevers();
                    bg2.updaterevers();
                    position.X = 50;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 200f;
                hasJumped = true;
            } else {
                velocity = Vector2.Zero;
            }



            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 1.15f * i;   
            }

            if (position.Y + rectangle.Height < 420)
            {
                velocity.Y += .5f;
                if (position.Y + rectangle.Height > 420)
                {
                    position.Y = 420 - rectangle.Height;
                    velocity = Vector2.Zero;
                    hasJumped = false;
                }

            }
            else
            {
                hasJumped = false;
            }

            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }

            position = position + velocity;
            Console.Out.WriteLine("p - " + position.Y);
        }
        

        public void right(GameTime gametime)
        {
            if (currentFrame > 6)
            {
                currentFrame = 0;
                timer = 0;
            }

            timer += (float)gametime.ElapsedGameTime.Milliseconds;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0;

                if (currentFrame == 6)
                {
                    currentFrame = 0;
                }
            }
        }

        public void left(GameTime gametime)
        {
            if (currentFrame < 6)
            {
                currentFrame = 6;
                timer = 0;
            }

            timer += (float)gametime.ElapsedGameTime.Milliseconds;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0;

                if (currentFrame == 11)
                {
                    currentFrame = 0;
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch) {

            if (hasAtack) {
                spriteBatch.Draw(atack, position, rectangle, Color.White, 0f, orignoalPosition, 1.0f, SpriteEffects.None, 0);
                spriteBatch.DrawString(font, "Live:" + live, new Vector2(20, 20), Color.White);
            }
            else {
                spriteBatch.DrawString(font, "Live:"+ live+" pos"+position , new Vector2(20,20),Color.White);
                 spriteBatch.Draw(textur, position, rectangle, Color.White, 0f, orignoalPosition, 1.0f, SpriteEffects.None, 0);
               // spriteBatch.Draw(textur, rectangle, Color.White);
            }
        }
    }
}
