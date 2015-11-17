using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class ScrollingBg
    {
        public Texture2D BgTexure;
        public Rectangle BgRectangle;
        public int temp;
        public void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(BgTexure,BgRectangle,Color.White);
        }

    }
    class MainScrolling : ScrollingBg
    {
        public MainScrolling(Texture2D newtexture,Rectangle newRectangle) {
            BgRectangle = newRectangle;
            BgTexure = newtexture;
        }

        public void update() {
            BgRectangle.X -= 2;
            temp = BgRectangle.X;
         }
        public void updatestop()
        {
            BgRectangle.X = temp;
        }

    }
}
