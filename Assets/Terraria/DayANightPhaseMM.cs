using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayANightPhaseMM : MonoBehaviour {

	public int maxFramesPerLoop = 10;

	public bool half = false;

	public Transform image;
	public SpriteRenderer imageSprite;

	public AudioSource title_music;

	void Update () {

		if (Splashscreen.isHidden == true)
		{
			float x = image.position.x;

			float y = image.position.y;

			x += 0.03f;

			image.position = new Vector2(x, y);

			if (image.position.x >= 9)
            {
				image.position = new Vector2(-10, y);
			}
		}
	}
}
