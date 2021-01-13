﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splashscreen : MonoBehaviour {

	public Image spashScreen;

    public static bool isHidden = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(FadeImage(true));
	}

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 5; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                spashScreen.color = new Color(1, 1, 1, i);
                yield return null;
            }
            isHidden = true;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                spashScreen.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
