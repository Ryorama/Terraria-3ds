using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GenWorld2 : MonoBehaviour {

	public GameObject grass;
	public GameObject dirt;
	public GameObject stone;

	public Vector2 value;

	public void Gen()
    {
		int l = 0;
		int h = 0;

		for (int x = -11; x < Main.maxChunkX - 11; x++)
        {
			l = x;
			Instantiate(grass, new Vector2(x, 0), Quaternion.identity);
			for (int y = -1; y > -15; y--)
			{
				h = y;
				Instantiate(dirt, new Vector2(l, y), Quaternion.identity);
			}
			for (int y = -15; y > -185; y--)
			{
				h = y;
				Instantiate(stone, new Vector2(l, y), Quaternion.identity);
			}
		}
		Mountinater(l, h);
	}

	public void Mountinater(int i, int j)
	{
		int min1 = 80;
		int max1 = 120;
		double num = Random.Range(min1, max1);
		int min2 = 40;
		int max2 = 55;
		float num2 = Random.Range(min2, max2);
		value.x = (float)i;
		value.y = (float)j + num2 / 2f;
		Vector2 value2;
		int min3 = -10;
		int max3 = 11;
		value2.x = Random.Range(min3, max3) * 0.1f;
		int min4 = -20;
		int max4 = -10;
		value2.x = Random.Range(min4, max4) * 0.1f;
		value2.y = Random.Range(min4, max4) * 0.1f;
		while (num > 0.0 && num2 > 0f)
		{
			int min5 = 0;
			int max5 = 4;
			num -= Random.Range(min5, max5);
			num2 -= 1f;
			int num3 = (int)((double)value.x - num * 0.5);
			int num4 = (int)((double)value.x + num * 0.5);
			int num5 = (int)((double)value.y - num * 0.5);
			int num6 = (int)((double)value.y + num * 0.5);
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			int min6 = 80;
			int max6 = 120;
			double num7 = num * Random.Range(min6, max6) * 0.01;
			for (int k = num3; k < num4; k++)
			{
				for (int l = num5; l < num6; l++)
				{
					float num8 = Mathf.Abs((float)k - value.x);
					float num9 = Mathf.Abs((float)l - value.y);
					double num10 = Mathf.Sqrt((num8 * num8 + num9 * num9));
					if (num10 < num7 * 0.4)
					{
						Instantiate(dirt, new Vector2(num8, num9), Quaternion.identity);
					}
				}
			}
		}
	}

	public void genNewChunk()
    {
		int l = 0;
		int h = 0;

		for (int x = -11; x < Main.maxChunkX - 11; x++)
		{
			l = x;
			Instantiate(grass, new Vector2(x, 0), Quaternion.identity);
			for (int y = -1; y > -15; y--)
			{
				h = y;
				Instantiate(dirt, new Vector2(l, y), Quaternion.identity);
			}
			for (int y = -15; y > -50; y--)
			{
				h = y;
				Instantiate(stone, new Vector2(l, y), Quaternion.identity);
			}
		}
	}
}
