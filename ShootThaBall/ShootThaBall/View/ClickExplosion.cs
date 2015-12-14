using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShootThaBall.Model;
using ShootThaBall.View.ExplosionSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View
{
    class ClickExplosion
    {
        public List<TheOneWhoControl> explosionsView = new List<TheOneWhoControl>();

        ContentManager _content;
        SpriteBatch _spritebatch;
        Camera _camera;
        Vector2 mousePosition;
       
        

        public ClickExplosion(ContentManager content, SpriteBatch spritebatch, Camera camera)
        {
            _content = content;
            _spritebatch = spritebatch;
            _camera = camera;
        }
        public void CreateExplosion(Vector2 MousePosition)
        {
            mousePosition = MousePosition;
            explosionsView.Add(new TheOneWhoControl(_content, _spritebatch, _camera, MousePosition));
        }

        public void Update(float time)
        {
            foreach(TheOneWhoControl explosionOnClick in explosionsView)
            {
                explosionOnClick.Updateeverything(time);
                
            }
        }
        public void Draw()
        {
            
            foreach(TheOneWhoControl explosionOnClick in explosionsView)
            {
                explosionOnClick.DrawEverything(mousePosition);
            }
        }
    }
}
