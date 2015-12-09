using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace WindowsGame1
{
    class Bad
    {
      public  Texture2D textur;

        SpriteFont font;
        public Rectangle rectangle;
        public Vector2 position;
        int timer;
       
       

        int live = 0;

        // Keyboard ks = Keyboard.GetState;
        public Bad(Texture2D newtexure, Vector2 newPosition)
        {
            textur = newtexure;
           
            position = newPosition;

        }
        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle((int)position.X , (int)position.Y,32,32);
           
            if (timer > 200)
                Randomizer();
            else timer++;
         
           
        }

        public void Randomizer() {
           
                             position.X -= 5f;
                             timer = 0;

            
        }
       
        public void Draw(SpriteBatch spritebatch) {

            spritebatch.Draw(textur, position, Color.White);

        }
    }
}
