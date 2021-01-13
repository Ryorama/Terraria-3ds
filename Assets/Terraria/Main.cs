using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Runtime;
using UnityEngine;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using TerrainEngine2D;

public class Main : MonoBehaviour {

	public static SpriteFont fontMouseText;
	public static SpriteFont fontDeathText;
	public static System.Random rand;
	public static bool[] tileLighted = new bool[419];
	public static bool[] tileMergeDirt = new bool[419];
	public static bool[] tileCut = new bool[419];
	public static bool[] tileAlch = new bool[419];
	public static int[] tileShine = new int[419];
	public static bool[] tileShine2 = new bool[419];
	public static bool[] wallHouse = new bool[225];
	public static bool[] wallDungeon = new bool[225];
	public static bool[] wallLight = new bool[225];
	public static int[] wallBlend = new int[225];
	public static bool[] tileStone = new bool[419];
	public static bool[] tileAxe = new bool[419];
	public static bool[] tileHammer = new bool[419];
	public static bool[] tileWaterDeath = new bool[419];
	public static bool[] tileLavaDeath = new bool[419];
	public static bool[] tileTable = new bool[419];
	public static bool[] tileBlockLight = new bool[419];
	public static bool[] tileNoSunLight = new bool[419];
	public static bool[] tileDungeon = new bool[419];
	public static bool[] tileSpelunker = new bool[419];
	public static bool[] tileSolidTop = new bool[419];
	public static bool[] tileSolid = new bool[419];
	public static bool[] tileBouncy = new bool[419];
	public static short[] tileValue = new short[419];
	public static byte[] tileLargeFrames = new byte[419];
	public static byte[] wallLargeFrames = new byte[225];
	public static bool[] tileRope = new bool[419];
	public static bool[] tileBrick = new bool[419];
	public static bool[] tileMoss = new bool[419];
	public static bool[] tileNoAttach = new bool[419];
	public static bool[] tileNoFail = new bool[419];
	public static bool[] tileObsidianKill = new bool[419];
	public static bool[] tileFrameImportant = new bool[419];
	public static bool[] tilePile = new bool[419];
	public static bool[] tileBlendAll = new bool[419];
	public static short[] tileGlowMask = new short[419];
	public static bool[] tileContainer = new bool[419];
	public static bool[] tileSign = new bool[419];
	public static bool[][] tileMerge = new bool[419][];
	public static int zoneX = 99;
	public static int zoneY = 87;
	public static double rockLayer;
	public static bool bloodMoon = false;
	public static bool pumpkinMoon = false;
	public static bool mapReady = false;
	public static bool hardMode = false;
	public static int dungeonX;
	public static int dungeonY;
	public static bool snowMoon = false;
	public static bool[] tileSand = new bool[419];
	public static int myPlayer = 0;
	public static bool raining = false;
	public static bool eclipse = false;
	public static int spawnTileX;
	public static bool mapEnabled = true;
	public static Microsoft.Xna.Framework.Graphics.Texture2D magicPixel;
	public static int spawnTileY;
	public static int[] treeX = new int[4];
	public static int[] treeStyle = new int[4];
	public static int[] caveBackX = new int[4];
	public static int[] caveBackStyle = new int[4];
	public static bool blockMouse = false;
	public static double worldSurface;
	public static bool expertMode = false;
	public static bool validateSaves = true;
	public static string WorldPath;
	public static Microsoft.Xna.Framework.Graphics.Texture2D[] tileTexture = new Microsoft.Xna.Framework.Graphics.Texture2D[419];
	public static float leftWorld = 0f;
    public static float rightWorld = 2000;
    public static float topWorld = 0f;
    public static float bottomWorld = -1800;
	public static int mapMinX = 0;
	public static bool[] tileSetsLoaded = new bool[419];
	public static int mapMaxX = 0;
	public static int mapMinY = 0;
	public static int mapMaxY = 0;
	public static int mapTimeMax = 30;
	public static int mapTime = Main.mapTimeMax;
	public static int worldRate = 1;
	public static string worldName = "";
	public static int worldID;
	public Game game = new Game();
	public static int maxTilesX = (int)Main.rightWorld;
    public static int maxTilesY = (int)Main.bottomWorld;
    public static int maxSectionsX = Main.maxTilesX / 200;
    public static int maxSectionsY = Main.maxTilesY / 150;
	public static int maxChunkX = 200;
	public static int maxChunkY = -200;
	public TileChunkManager manager;
	public World world;
	GenWorld2 gen;
	public AudioSource day1;
	public AudioSource night;

    void Start()
    {
		WorldPath = UnityEngine.Application.persistentDataPath + "/Worlds";
		Main.magicPixel = game.Content.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("Images/MagicPixel");
		Main.fontMouseText = game.Content.Load<SpriteFont>("Content/Fonts/Mouse_Text.xnb");
		Main.fontDeathText = game.Content.Load<SpriteFont>("Content/Fonts/Death_Text.xnb");
	}
	void Awake()
	{
		WorldPath = UnityEngine.Application.persistentDataPath + "/Worlds";
		Main.magicPixel = game.Content.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("Images/MagicPixel");
		Main.fontMouseText = game.Content.Load<SpriteFont>("Content/Fonts/Mouse_Text.xnb");
		Main.fontDeathText = game.Content.Load<SpriteFont>("Content/Fonts/Death_Text.xnb");
	}
	void Update()
	{
		bool isMusicPlaying = false;
		
		if (world.TimeOfDay >= 19 || world.TimeOfDay <= 7) {
			day1.Stop();
			isMusicPlaying = false;
			if (isMusicPlaying == false) {
				night.Play();
				isMusicPlaying = true;
			}
		}
		else {
			night.Stop();
			isMusicPlaying = false;
			if (isMusicPlaying == false) {
				day1.Play();
				isMusicPlaying = true;
			}
		}
	}
	public static string worldPathName
	{
		get
		{
			return WorldPath;
		}
	}
	protected void LoadTiles(int i)
	{
		if (!Main.tileSetsLoaded[i])
		{
			Main.tileTexture[i] = game.Content.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(string.Concat(new object[]
			{
				"Content/Images/Tiles_" + i
			}));
			Main.tileSetsLoaded[i] = true;
		}
	}
}
