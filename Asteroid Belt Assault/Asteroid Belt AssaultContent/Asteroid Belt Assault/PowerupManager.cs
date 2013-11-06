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
        public Sprite shieldPowerup;
        public Sprite shotPowerup;
        public Sprite freezePowerup;
        public Texture2D spriteSheet;
        public PlayerManager playerManager;
        

        public PowerupManager(Texture2D spriteSheet, PlayerManager playerManager)
        {
            this.spriteSheet = spriteSheet;
            this.playerManager = playerManager;


        }

        public void SpawnShotPowerup()
        {
            if (shotPowerup == null)
                shotPowerup = new Sprite(new Vector2(20, 20), spriteSheet, new Rectangle(352, 135, 61, 68), new Vector2(50, 50));
            else
                shotPowerup.Location = new Vector2(500, 50);
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
            //Shot powerup code
            if (shotPowerup != null)
            {
                shotPowerup.Update(gameTime);

                if (shotPowerup.IsCircleColliding(playerManager.playerSprite.Center, 15))
                {
                    SpawnShotPowerup();
                    playerManager.minShotTimer = 0.09f;
                    SoundManager.PlaySpeedSound();
                }
            }
            if (playerManager.PlayerScore % 1500 == 0 && playerManager.PlayerScore > 0)
            {
                playerManager.PlayerScore += 100;
                SpawnShotPowerup();
            }

            if (playerManager.Destroyed == true)
            {
                playerManager.minShotTimer = 0.2f;
            }
        


            //Speed powerup code
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
            if (shotPowerup != null)
                shotPowerup.Draw(spritebatch);
        }
    }
}
