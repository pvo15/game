using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Patform
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle rec;


        public Patform(Texture2D newtexture, Vector2 newposition) {

            texture = newtexture;
            position = newposition;

            rec = new Rectangle((int)position.X,(int)position.Y,texture.Width,texture.Height);  
        }
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture,rec,Color.Wheat);

        }
    }
}
