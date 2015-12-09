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
    class Bullet
    {
        public Texture2D texture;
        public Vector2 orignoalPosition;
        public Vector2 position;
        public Vector2 velocity;
        public Rectangle rec;
        public    SpriteFont font;



        public Boolean isVisible;

        public Bullet(Texture2D newtexture) {
            texture = newtexture;
            rec = new Rectangle((int)position.X, (int)position.Y,32,32);
            isVisible = false;

        }
        public void Draw(SpriteBatch sprateBatch) {
            sprateBatch.DrawString(font, "Live:" + position, new Vector2(40, 40), Color.White);

            sprateBatch.Draw(texture,position,null,Color.Wheat,0f,orignoalPosition,1f,SpriteEffects.None,0);

        }
    }
}
