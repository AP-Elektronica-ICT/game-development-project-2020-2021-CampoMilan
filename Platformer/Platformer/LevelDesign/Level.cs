﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.LevelDesign
{
    public abstract class Level
    {
        protected Texture2D blockTexture;
        protected Texture2D bgTexture;

        protected byte[,] byteTileArray;
        private Blok[,] blokTileArray;
        private BackgroundBlok[,] bgTileArray;

        private ContentManager content;

        public Level()
        {
            CreateTileArray();
            blokTileArray = new Blok[byteTileArray.GetLength(0), byteTileArray.GetLength(1)];
            CreateWorld();
            InitializeContent();
        }

        private void InitializeContent()
        {
            blockTexture = content.Load<Texture2D>("Block");
            bgTexture = content.Load<Texture2D>("bgBlock");
        }

        protected abstract void CreateTileArray();


        private void CreateWorld()
        {
            for (int x = 0; x < byteTileArray.GetLength(0); x++)
            {
                for (int y = 0; y < byteTileArray.GetLength(1); y++)
                {
                    switch (byteTileArray[x, y])
                    {
                        case 1:
                            blokTileArray[x, y] = new Blok(blockTexture, new Vector2(y * 17, x * 17));
                            break;
                        case 0:
                            bgTileArray[x, y] = new BackgroundBlok(bgTexture, new Vector2(y * 17, x * 17));
                            break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < byteTileArray.GetLength(0); x++)
            {
                for (int y = 0; y < byteTileArray.GetLength(1); y++)
                {
                    if (blokTileArray[x, y] != null)
                    {
                        blokTileArray[x, y].Draw(spriteBatch);
                    }
                    if (bgTileArray[x, y] != null)
                    {
                        bgTileArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}