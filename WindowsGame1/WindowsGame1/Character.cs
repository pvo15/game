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
        Texture2D textur;
        Rectangle rectangle;
        Vector2 orignoalPosition;
        Vector2 position;
        Vector2 velocity;

        int frameHeight;
        int framewidth;
        int currentFrame;

        float timer;
        float interval = 125;

        bool hasJumped = false;

        MainScrolling bg1,bg2;

        // Keyboard ks = Keyboard.GetState;
        public Character(Texture2D newtexure, Vector2 newPosition, int newframeHeight, int newframewidth, MainScrolling newbg1, MainScrolling newbg2) {
            textur = newtexure;
            position = newPosition;
            frameHeight = newframeHeight;
            framewidth = newframewidth;
            bg1 = newbg1;
            bg2 = newbg2;
        }
        public void Update(GameTime gameTime) {
            rectangle = new Rectangle(currentFrame * frameHeight,0,framewidth,frameHeight);
            orignoalPosition = new Vector2(rectangle.Width/2, rectangle.Height / 2);
            position = position+ velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                right(gameTime);
                velocity.X = 3;
                if (position.X >= 300)
                {

                    bg1.update();
                    bg2.update();
                    position.X = 300;
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

            }
            else {
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
            }
         /*  else if (position.Y + rectangle.Height >= 420)
            {
                velocity.Y = 420;
            }*/
            else
            {
                hasJumped = false;
            }

            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }


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

            spriteBatch.Draw(textur, position, rectangle, Color.White,0f,orignoalPosition,1.0f,SpriteEffects.None,0);
        }
    }
}
