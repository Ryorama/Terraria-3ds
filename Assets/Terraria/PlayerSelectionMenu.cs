using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.UI;
using System.IO;
using System.Runtime.CompilerServices;

public class PlayerSelectionMenu : MonoBehaviour {

	public static bool player1Made = false;
	public static bool player2Made = false;
	public static bool player3Made = false;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject char1Empty;
	public GameObject char1;

	public Text char1Health;
	public Text char1Mana;
	public Text char1PlayTime;

	public Text player1T;
	public Text player2T;
	public Text player3T;

	public Text playerName;

	public Image Play;
	public Image Favorite;
	public Image Delete;

	public Sprite PlayA;
	public Sprite FavoriteA;
	public Sprite DeleteA;

	public Sprite PlayNA;
	public Sprite FavoriteNA;
	public Sprite DeleteNA;

	public GameObject playerSelectionScreen;

	public GameObject playerCreationMenu;

	public int maxSelection = 3;

	public AudioSource menu_tick;

	public static bool isCreatingPlayer = false;

	public int currentSelection = 0;

	void Update () {

		if (File.Exists(UnityEngine.Application.persistentDataPath + "/playersave"))
		{
			player1Made = true;
			maxSelection = 6;
		}

		if (!player1Made)
        {
			char1Empty.SetActive(true);
			char1.SetActive(false);
        }
		else
        {
			char1Empty.SetActive(false);
			char1.SetActive(true);

			string health;
			string mana;
			string playTime;
			string name;

			int lineNumbers = 4;

			UnityEngine.N3DS.FileSystemSave.Mount();
			if (File.Exists(UnityEngine.Application.persistentDataPath +  "/playersave"))
			{
				StreamReader sr = File.OpenText(UnityEngine.Application.persistentDataPath +  "/playersave");
				for (int i = 1; i < lineNumbers; i++) {
					if (i == 1)
					{
						health = sr.ReadLine();
						char1Health.text = health;
					}
					if (i == 2)
					{
						mana = sr.ReadLine();
						char1Mana.text = mana;
					}
					if (i == 3)
					{
						playTime = sr.ReadLine();
						char1PlayTime.text = playTime;
					}
					if (i == 4)
					{
						name = sr.ReadLine();
						playerName.text = name;
					}
				}
				sr.Close();
				UnityEngine.N3DS.FileSystemSave.Unmount();
			}
		}

		if (MenuMainManager.played == true)
        {

			playerSelectionScreen.SetActive(true);

			if (GamePad.GetButtonTrigger(N3dsButton.Down))
			{
				if (currentSelection < 3)
				{
					currentSelection += 1;
					menu_tick.Play();
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.B))
			{
				MenuMainManager.mainMenu = true;
				playerSelectionScreen.SetActive(false);
				MenuMainManager.played = false;
				return;
			}

			if (Input.GetKeyDown(KeyCode.B))
			{
				MenuMainManager.mainMenu = true;
				MenuMainManager.played = false;
				playerSelectionScreen.SetActive(false);
				return;
			}

				if (GamePad.GetButtonTrigger(N3dsButton.Up))
			{
				if (currentSelection <= 3 && currentSelection > 0)
				{
					currentSelection -= 1;
					menu_tick.Play();
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (currentSelection < 3)
				{
					currentSelection += 1;
					menu_tick.Play();
				}
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (currentSelection <= 3 && currentSelection > 0)
				{
					currentSelection -= 1;
					menu_tick.Play();
				}
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (currentSelection >= 3)
				{
					currentSelection += 1;
					menu_tick.Play();
				}
			}

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (currentSelection <= 6 && currentSelection >= 3)
				{
					currentSelection -= 1;
					menu_tick.Play();
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Left))
			{
				if (currentSelection >= 3)
				{
					currentSelection += 1;
					menu_tick.Play();
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Right))
			{
				if (currentSelection <= 6 && currentSelection >= 3)
				{
					currentSelection -= 1;
					menu_tick.Play();
					return;
				}
			}

			if (currentSelection == 1 && !player1Made)
			{
				player1T.color = Color.yellow;
				if (GamePad.GetButtonRelease(N3dsButton.A))
				{
					playerCreationMenu.SetActive(true);
					MenuMainManager.played = false;
					isCreatingPlayer = true;
					playerSelectionScreen.SetActive(false);
					return;
				}

				if (Input.GetKeyDown(KeyCode.A))
				{
					playerCreationMenu.SetActive(true);
					MenuMainManager.played = false;
					isCreatingPlayer = true;
					playerSelectionScreen.SetActive(false);
					return;
				}
			}
			else
			{
				player1T.color = Color.white;
			}

			if (currentSelection == 2 && !player1Made)
			{
				player2T.color = Color.yellow;
				if (GamePad.GetButtonRelease(N3dsButton.A))
				{
					MenuMainManager.played = false;
					playerSelectionScreen.SetActive(false);
					isCreatingPlayer = true;
					playerCreationMenu.SetActive(true);
				}
			}
			else
			{
				player2T.color = Color.white;
			}

			if (currentSelection == 3 && !player1Made)
			{
				player3T.color = Color.yellow;
				if (GamePad.GetButtonRelease(N3dsButton.A))
				{
					MenuMainManager.played = false;
					isCreatingPlayer = true;
					playerSelectionScreen.SetActive(false);
					playerCreationMenu.SetActive(true);
				}
			}
			else
			{
				player3T.color = Color.white;
			}

			if (currentSelection == 1 && player1Made)
            {
				Play.sprite = PlayA;
            }
			else
            {
				Play.sprite = PlayNA;
            }

			if (currentSelection == 2 && player1Made)
			{
				Favorite.sprite = FavoriteA;
			}
			else
			{
				Favorite.sprite = FavoriteNA;
			}

			if (currentSelection == 3 && player1Made)
			{
				Delete.sprite = DeleteA;
			}
			else
			{
				Delete.sprite = DeleteNA;
			}
		}
	}
	public void ExitCharCreator()
    {
		MenuMainManager.played = true;
		playerCreationMenu.SetActive(false);
    }
}
