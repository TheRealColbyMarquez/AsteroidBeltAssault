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
        public Sprite speedPowerup;
        public Texture2D spriteSheet;
        public PlayerManager playerManager;
        

        public PowerupManager(Texture2D spriteSheet, PlayerManager playerManager)
        {
            this.spriteSheet = spriteSheet;
            this.playerManager = playerManager;


        }

        public void SpawnSpeedPowerup()
        {
            if (speedPowerup == null)
                speedPowerup = new Sprite(new Vector2(20, 20), spriteSheet, new Rectangle(1, 343, 51, 37), new Vector2(50, 50));
            else
                speedPowerup.Location = new Vector2(500, 50);
         }

        public void Update(GameTime gameTime)
        {
            if (speedPowerup != null)
            {
                speedPowerup.Update(gameTime);

                if (speedPowerup.IsCircleColliding(playerManager.playerSprite.Center, 15))
                {
                    speedPowerup.Location = new Vector2(-500, -500);
                    playerManager.playerSpeed = 500f;
                    SoundManager.PlaySpeedSound();
                }
            }

            if (playerManager.PlayerScore % 600 == 0 && playerManager.PlayerScore > 0)
            {
                playerManager.PlayerScore += 100;
                SpawnSpeedPowerup();
            }


            if (playerManager.Destroyed == true)
            {
                playerManager.playerSpeed = 160f;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (speedPowerup != null)
                speedPowerup.Draw(spritebatch);
        }
    }
}
