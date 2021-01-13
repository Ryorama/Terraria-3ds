using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.UI;
using TerrainEngine2D;
using TerrainEngine2D.SideScrollerDemo;

public class MenuMainManager : MonoBehaviour {

	public Text play;
	
	public GameObject MMCamera;
	public GameObject worldCamera;

	public AudioSource menu_tick;

	public int selectedOption = 0;

	public static bool played = false;

	public Text gdw;
	public GameObject gdwO;

	public GameObject logo;
	public GameObject playO;
	public GameObject version;
	
	public SideScrollerTerrainGenerator world;
	
	public World world2;

	public GameObject worldStuff;

	public bool logoRotateRigt = true;

	public RectTransform logoT;

	public static bool mainMenu = true;

	public GenWorld2 gen;

	public int maxSelection = 2;

	public static bool debugWorld = false;

	public TileChunkManager manager;
	
	public AudioSource day1;
	public AudioSource night;

	void Update() {

		manager.callLAU();

		if (GamePad.GetButtonHold(N3dsButton.Down)) {
			if (selectedOption < 2)
			{
				selectedOption += 1;
				menu_tick.Play();
				return;
			}
		}

		if (Splashscreen.isHidden == true)
		{
			float speed = 0.5f;
			float maxRotation = 10f;

			logo.transform.rotation = Quaternion.Euler(0f, 0f, (maxRotation * Mathf.Sin(Time.time * speed)));
		}

		if (mainMenu == true)
		{
			logo.SetActive(true);
			playO.SetActive(true);
			version.SetActive(true);
		}
       
		if (GamePad.GetButtonHold(N3dsButton.Up))
		{
			if (selectedOption >= maxSelection)
			{
				selectedOption -= 1;
				menu_tick.Play();
				return;
			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (selectedOption < 2)
			{
				selectedOption += 1;
				menu_tick.Play();
			}
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (selectedOption >= maxSelection)
			{
				selectedOption -= 1;
				menu_tick.Play();
			}
		}

		if (selectedOption == 1)
		{
			play.color = Color.yellow;
			if (GamePad.GetButtonRelease(N3dsButton.A))
            {
				played = true;
				playO.SetActive(false);
				logo.SetActive(false);
				gdwO.SetActive(false);
				version.SetActive(false);
				mainMenu = false;
            }
			if (Input.GetKeyDown(KeyCode.A))
			{
				played = true;
				playO.SetActive(false);
				logo.SetActive(false);
				gdwO.SetActive(false);
				version.SetActive(false);
				mainMenu = false;
			}
		}
		else
        {
			play.color = Color.white;
        }

		if (selectedOption == 2)
		{
			gdw.color = Color.yellow;
			if (GamePad.GetButtonRelease(N3dsButton.A))
			{
				playO.SetActive(false);
				logo.SetActive(false);
				version.SetActive(false);
				mainMenu = false;
				gdwO.SetActive(false);
				worldStuff.SetActive(true);
				MMCamera.SetActive(false);
				worldCamera.SetActive(false);
				world.GenerateData();
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				playO.SetActive(false);
				logo.SetActive(false);
				version.SetActive(false);
				mainMenu = false;
				gdwO.SetActive(false);
				worldStuff.SetActive(true);
				MMCamera.SetActive(false);
				worldCamera.SetActive(false);
				world.GenerateData();
			}
		}
		else
		{
			gdw.color = Color.white;
		}
	}
}
