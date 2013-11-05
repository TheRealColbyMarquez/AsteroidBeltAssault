﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;


namespace Asteroid_Belt_Assault
{
    public static class SoundManager
    {
        private static List<SoundEffect> explosions = new
            List<SoundEffect>();
        private static int explosionCount = 4;

        private static SoundEffect playerShot;
        private static SoundEffect enemyShot;
        private static SoundEffect playerDead;
        private static Song menuMusic;
        public static Song speedSound;

        private static Random rand = new Random();

        public static void Initialize(ContentManager content)
        {
            try
            {
                playerShot = content.Load<SoundEffect>(@"Sounds\Shot1");
                enemyShot = content.Load<SoundEffect>(@"Sounds\Shot2");
                playerDead = content.Load<SoundEffect>(@"Sounds\inceptionbutton");
                menuMusic = content.Load<Song>(@"Sounds\titleMusic");
                speedSound = content.Load<SoundEffect>(@"Sounds\speedSound");

                

                for (int x = 1; x <= explosionCount; x++)
                {
                    explosions.Add(
                        content.Load<SoundEffect>(@"Sounds\Explosion" +
                            x.ToString()));
                }
            }
            catch
            {
                Debug.Write("SoundManager Initialization Failed");
            }
        }

        public static void PlayMenuSong()
        {
            MediaPlayer.Play(menuMusic);
        }

        public static void StopMenuSong()
        {
            MediaPlayer.Stop();
        }

        public static void PlayExplosion()
        {
            try
            {
                explosions[rand.Next(0, explosionCount)].Play();
            }
            catch
            {
                Debug.Write("PlayExplosion Failed");
            }
        }

        public static void PlayDeath()
        {
            try
            {
                playerDead.Play();
            }
            catch
            {
                Debug.Write("PlayDead Failed");
            }
        }

        public static void PlayPlayerShot()
        {
            try
            {
                playerShot.Play();
            }
            catch
            {
                Debug.Write("PlayPlayerShot Failed");
            }
        }

        public static void PlayEnemyShot()
        {
            try
            {
                enemyShot.Play();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }

    }
}
