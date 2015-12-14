using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View
{
    class Aim
    {
        private float crosshairSize = 0.01f;
        private Camera _camera;
        Vector2 spritePosition;

        public Aim()
        {
            
        }
        public void Update(Vector2 Mouseposition)
        {
            spritePosition.X = Mouseposition.X;
            spritePosition.Y = Mouseposition.Y;
        }
        public void DrawCrosshair(SpriteBatch spriteBatch, Camera camera, Texture2D crossHair)
        {
            _camera = camera;
            spriteBatch.Begin();
            Vector2 scale = _camera.ScaleObjects(crossHair.Height , crossHair.Width );
           spriteBatch.Draw(crossHair, _camera.GetCrossHairVisualCoord(this.spritePosition.X, this.spritePosition.Y), null, Color.White, 0, new Vector2(crossHair.Bounds.Width/2, crossHair.Bounds.Height/2), 0.5f, SpriteEffects.None, 1);
            spriteBatch.End();
        }
        
        public float CrosshairSize
        {
            get { return crosshairSize; }
        }


    }
}
