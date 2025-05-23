using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using WombatQOL.Gores;
using Microsoft.Xna.Framework.Graphics;
using WombatQOL.Dusts;
using WombatQOL.Walls;

namespace WombatQOL
{
	public class QOLTile : GlobalTile
	{
        public override void SetStaticDefaults()
        {
            if (ModContent.GetInstance<Visuals>().SnowDirtMerge)
            {
                Main.tileMergeDirt[TileID.SnowBlock] = true;
                TileMerge(TileID.SnowBlock, TileID.IceBlock);
                TileMerge(TileID.SnowBlock, TileID.Slush);
                TileMerge(TileID.SnowBlock, TileID.CorruptIce);
                TileMerge(TileID.SnowBlock, TileID.FleshIce);
                TileMerge(TileID.SnowBlock, TileID.HallowedIce);
            }

            if (ModContent.GetInstance<Gameplay>().HoneyDispenser)
            {
                TileID.Sets.CountsAsHoneySource[TileID.HoneyDispenser] = true;
            }

            if (ModContent.GetInstance<Gameplay>().TilePickup)
            {
                TileID.Sets.CanDropFromRightClick[TileID.BloomingHerbs] = true;
                TileID.Sets.CanDropFromRightClick[TileID.MatureHerbs] = true;

                TileID.Sets.CanDropFromRightClick[TileID.DyePlants] = true;
                TileID.Sets.CanDropFromRightClick[TileID.Sunflower] = true;
                TileID.Sets.CanDropFromRightClick[TileID.Plants] = true;
                TileID.Sets.CanDropFromRightClick[TileID.HallowedPlants] = true;
                TileID.Sets.CanDropFromRightClick[TileID.CorruptPlants] = true;
                TileID.Sets.CanDropFromRightClick[TileID.JunglePlants] = true;
                TileID.Sets.CanDropFromRightClick[TileID.CrimsonPlants] = true;

                TileID.Sets.CanDropFromRightClick[TileID.Books] = true;
                TileID.Sets.CanDropFromRightClick[TileID.BeachPiles] = true;

            }
        }

        private void TileMerge(ushort tile1, ushort tile2)
        {
            Main.tileMerge[tile1][tile2] = true;
            Main.tileMerge[tile2][tile1] = true;
        }

        public override void MouseOver(int i, int j, int type)
        {
            Tile tile = Main.tile[i, j];

            if (tile.HasTile && ModContent.GetInstance<Gameplay>().TilePickup && Main.netMode == NetmodeID.SinglePlayer)
            {
                Player player = Main.LocalPlayer;

                if (tile.TileType == TileID.BloomingHerbs || tile.TileType == TileID.MatureHerbs)
                {
                    player.cursorItemIconEnabled = true;
                    if (tile.TileFrameX == 0)
                    {
                        player.cursorItemIconID = ItemID.Daybloom;
                    }
                    else if (tile.TileFrameX == 18)
                    {
                        player.cursorItemIconID = ItemID.Moonglow;
                    }
                    else if (tile.TileFrameX == 18 * 2)
                    {
                        player.cursorItemIconID = ItemID.Blinkroot;
                    }
                    else if (tile.TileFrameX == 18 * 3)
                    {
                        player.cursorItemIconID = ItemID.Deathweed;
                    }
                    else if (tile.TileFrameX == 18 * 4)
                    {
                        player.cursorItemIconID = ItemID.Waterleaf;
                    }
                    else if (tile.TileFrameX == 18 * 5)
                    {
                        player.cursorItemIconID = ItemID.Fireblossom;
                    }
                    else if (tile.TileFrameX == 18 * 6)
                    {
                        player.cursorItemIconID = ItemID.Shiverthorn;
                    }
                }
                else if (tile.TileType == TileID.DyePlants)
                {
                    player.cursorItemIconEnabled = true;
                    if (tile.TileFrameX == 0)
                    {
                        player.cursorItemIconID = ItemID.TealMushroom;
                    }
                    else if (tile.TileFrameX == 34)
                    {
                        player.cursorItemIconID = ItemID.GreenMushroom;
                    }
                    else if (tile.TileFrameX == 34 * 2)
                    {
                        player.cursorItemIconID = ItemID.SkyBlueFlower;
                    }
                    else if (tile.TileFrameX == 34 * 3)
                    {
                        player.cursorItemIconID = ItemID.YellowMarigold;
                    }
                    else if (tile.TileFrameX == 34 * 4)
                    {
                        player.cursorItemIconID = ItemID.BlueBerries;
                    }
                    else if (tile.TileFrameX == 34 * 5)
                    {
                        player.cursorItemIconID = ItemID.LimeKelp;
                    }
                    else if (tile.TileFrameX == 34 * 6)
                    {
                        player.cursorItemIconID = ItemID.PinkPricklyPear;
                    }
                    else if (tile.TileFrameX == 34 * 7)
                    {
                        player.cursorItemIconID = ItemID.OrangeBloodroot;
                    }
                    else if (tile.TileFrameX == 34 * 8)
                    {
                        player.cursorItemIconID = ItemID.StrangePlant1;
                    }
                    else if (tile.TileFrameX == 34 * 9)
                    {
                        player.cursorItemIconID = ItemID.StrangePlant2;
                    }
                    else if (tile.TileFrameX == 34 * 10)
                    {
                        player.cursorItemIconID = ItemID.StrangePlant3;
                    }
                    else if (tile.TileFrameX == 34 * 11)
                    {
                        player.cursorItemIconID = ItemID.StrangePlant4;
                    }
                    else player.cursorItemIconID = ItemID.PinkPricklyPear;
                }
                else if (tile.TileType == TileID.JunglePlants && tile.TileFrameX == 18 * 8)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.JungleSpores;
                }
                else if ((tile.TileType == TileID.Plants || tile.TileType == TileID.HallowedPlants) && tile.TileFrameX == 18 * 8)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.Mushroom;
                }
                else if (tile.TileType == TileID.CorruptPlants && tile.TileFrameX == 18 * 8)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.VileMushroom;
                }
                else if (tile.TileType == TileID.CrimsonPlants && tile.TileFrameX == 18 * 15)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.ViciousMushroom;
                }
                else if (tile.TileType == TileID.Sunflower)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.Sunflower;
                }
                else if (tile.TileType == TileID.Books && tile.TileFrameX != 18 * 5)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.Book;
                }
                else if (tile.TileType == TileID.BeachPiles)
                {
                    player.cursorItemIconEnabled = true;

                    if (tile.TileFrameY == 22)
                    {
                        player.cursorItemIconID = ItemID.Starfish;
                    }
                    else if (tile.TileFrameY == 22 * 2)
                    {
                        player.cursorItemIconID = ItemID.LightningWhelkShell;
                    }
                    else if (tile.TileFrameY == 22 * 3)
                    {
                        player.cursorItemIconID = ItemID.TulipShell;
                    }
                    else if (tile.TileFrameY == 22 * 4)
                    {
                        player.cursorItemIconID = ItemID.JunoniaShell;
                    }
                    else player.cursorItemIconID = ItemID.Seashell;
                }
            }
        }

        public override void PostDraw(int i, int j, int type, SpriteBatch spriteBatch)
        {
            if (ModContent.GetInstance<Visuals>().HallowFireflies)
            {
                Tile tile = Main.tile[i, j];
                if (tile.HasTile && tile.TileType == TileID.Crystals && Main.rand.NextBool(50))
                {
                    int x = i + Main.rand.Next(-12, 13);
                    int y = j + Main.rand.Next(-12, 13);

                    if (!Main.tile[x, y].HasTile || !Main.tileSolid[Main.tile[x, y].TileType])
                    {
                        Dust.NewDustDirect(new Vector2(x, y) * 16, 16, 16, ModContent.DustType<hallowfirefly>());
                    }
                }
            }
        }
    }

    public class QOLWall : GlobalWall
    {
        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            float num48 = 0.55f / 2;

            bool tileBlock = tile.HasTile && Main.tileBlockLight[tile.TileType] && !(tile.Slope != SlopeType.Solid || tile.IsHalfBlock);
            bool wallBlock = !Main.wallLight[tile.WallType];

            #region tilelight
            if (ModContent.GetInstance<Visuals>().GlowingHellstone)
            {
                if (tile.HasTile && (tile.TileType == TileID.Hellstone || tile.TileType == TileID.HellstoneBrick))
                {
                    r = num48;
                    g = num48 * 0.3f;
                    b = num48 * 0.1f;
                }
                else if (!tileBlock)
                {
                    if (tile.WallType == WallID.HellstoneBrickUnsafe || tile.WallType == WallID.HellstoneBrick || tile.WallType == WallID.LavaUnsafe1 || tile.WallType == WallID.LavaUnsafe2 || tile.WallType == WallID.LavaUnsafe3 || tile.WallType == WallID.LavaUnsafe4)
                    {
                        r = num48;
                        g = num48 * 0.3f;
                        b = num48 * 0.1f;
                    }
                }
            }
            if (!tileBlock && !wallBlock && ModContent.GetInstance<Visuals>().GlowingLavaBG)
            {
                if (j > Main.maxTilesY - 300 && j <= Main.maxTilesY - 200)
                {
                    r = num48;
                    g = num48 * 0.3f;
                    b = num48 * 0.1f;
                }
            }
            #endregion
        }

        public override void PostDraw(int i, int j, int type, SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;

            if (player.ZoneJungle && ModContent.GetInstance<Visuals>().JungleFireflies)
            {
                Tile tile = Main.tile[i, j];
                if (j > Main.worldSurface && Main.rand.NextBool(5000) && !tile.HasTile && tile.LiquidAmount == 0 && !Main.wallHouse[tile.WallType] && tile.WallType != WallID.LihzahrdBrickUnsafe)
                {
                    if (tile.WallType == WallID.HiveUnsafe || tile.WallType == ModContent.WallType<honeybrickwallunsafe>() || ModLoader.TryGetMod("Remnants", out Mod remnants) && remnants.TryFind("hive", out ModWall hive) && tile.WallType == hive.Type)
                    {
                        Dust.NewDust(new Vector2(i, j) * 16, 16, 16, ModContent.DustType<honeyfirefly>());
                    }
                    else Dust.NewDust(new Vector2(i, j) * 16, 16, 16, ModContent.DustType<junglefirefly>());
                }
            }
        }
    }
}