using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PowerupManager
    {
        private float powerupTime = 10f;
        private float spawnPowerup = 20f;
        private bool powerupEnabled = false;

        public Sprite powerup;

        public PowerupManager()
        {
        }

        public void SpawnPowerup()
        {
           // powerup = new Sprite ( ... );
        }

        public void Update(GameTime gameTime)
        {
            if (powerup != null)
                powerup.Update(gameTime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (powerup != null)
                powerup.Draw(spritebatch);
        }
    }
}
