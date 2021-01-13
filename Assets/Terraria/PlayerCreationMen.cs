using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;
using System.IO;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.UI;

public class PlayerCreationMen : MonoBehaviour {

	public GameObject playerCreationMenu;

	public PlayerSelectionMenu menu;

	public AudioSource menu_tick;

	public int playerHealth = 100;
	public int playerMana = 0;

	public Image Info;
	public Image Gender;
	public Image HairStyle;
	public Image EyeColor;
	public Image SkinColor;
	public Image ShirtColor;
	public Image UndershirtColor;
	public Image PantsColor;
	public Image ShoeColor;

	public Image namePanel;

	public Text HT;
	public Text ST;
	public Text VT;

	public GameObject ColorPickerS;

	public Sprite pannelHighlighted;
	public Sprite pannelNormal;

	public GameObject softCore;
	public GameObject mediumCore;
	public GameObject hardCore;
	public GameObject namePanelObject;

	public Image softCoreI;
	public Image mediumCoreI;
	public Image hardCoreI;

	public Image EyeM;
	public Image SkinM;
	public Image ShirtM;

	public Slider HS;
	public Slider SS;
	public Slider VS;

	public Text nameT;

	public bool editEyeColor = false; 
	public bool editSkinColor = false;
	public bool editShirtColor = false;
	public bool editUndershirtColor = false;
	public bool editPantsColor = false;
	public bool editShoeColor = false;
	public bool editInfo = true;

	public Image create;

	public int maxSelection = 15;

	public static string nameS = "Empty name...";

	public int currentSelection = 0;

	void Update () {

		nameS = Keyboard.GetText();

		float h = ColorPicker._hue;
		float s = ColorPicker._saturation;
		float v = ColorPicker._brightness;

		if (editEyeColor)
		{
			float eyeH = h;
			float eyeS = s;
			float eyeV = v;
			EyeM.color = Color.HSVToRGB(eyeH, eyeS, eyeV);
		}

		if (editSkinColor)
		{
			float skinH = h;
			float skinS = s;
			float skinV = v;
			SkinM.color = Color.HSVToRGB(skinH, skinS, skinV);
		}

		if (editShirtColor)
		{
			float shirtH = h;
			float shirtS = s;
			float shirtV = v;
			ShirtM.color = Color.HSVToRGB(shirtH, shirtS, shirtV);
		}

		if (PlayerSelectionMenu.isCreatingPlayer)
        {

			if (editInfo == true)
            {
				maxSelection = 15;
            }
			else
            {
				maxSelection = 9;
            }

			if (GamePad.GetButtonTrigger(N3dsButton.Right))
			{
				if (currentSelection < maxSelection)
				{
					currentSelection += 1;
					menu_tick.Play();
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Left))
			{
				if (currentSelection <= maxSelection && currentSelection > 0)
				{
					currentSelection -= 1;
					menu_tick.Play();
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Right))
			{
				if (currentSelection == 10)
				{
					HS.value += 0.1f;
					return;
				}
				if (currentSelection == 11)
				{
					SS.value += 0.1f;
					return;
				}
				if (currentSelection == 12)
				{
					VS.value += 0.1f;
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Left))
			{
				if (currentSelection == 10)
				{
					HS.value -= 0.1f;
					return;
				}
				if (currentSelection == 11)
				{
					SS.value -= 0.1f;
					return;
				}
				if (currentSelection == 12)
				{
					VS.value -= 0.1f;
					return;
				}
			}

			if (currentSelection == 14 && GamePad.GetButtonTrigger(N3dsButton.A))
            {
				SavePlayer();
            }

			if (currentSelection == 14 && Input.GetKeyDown(KeyCode.A))
            {
				SavePlayer();
            }

			if (GamePad.GetButtonTrigger(N3dsButton.R))
            {
				currentSelection = 14;
            }

			if (currentSelection == 14 && GamePad.GetButtonTrigger(N3dsButton.L))
            {
				currentSelection = 1;
            }

			if (Input.GetKeyDown(KeyCode.R))
			{
				currentSelection = 14;
			}

			if (currentSelection == 14 && Input.GetKeyDown(KeyCode.L))
			{
				currentSelection = 1;
			}

			if (currentSelection == 14)
            {
				create.color = Color.yellow;
            }
			else
            {
				Color color;
				ColorUtility.TryParseHtmlString("#2B3E5DFF", out color);
				create.color = color;
			}

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (currentSelection == 10)
				{
					HS.value += 0.1f;
					return;
				}
				if (currentSelection == 11)
				{
					SS.value += 0.1f;
					return;
				}
				if (currentSelection == 12)
				{
					VS.value += 0.1f;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (currentSelection == 10)
				{
					HS.value -= 0.1f;
					return;
				}
				if (currentSelection == 11)
				{
					SS.value -= 0.1f;
					return;
				}
				if (currentSelection == 12)
				{
					VS.value -= 0.1f;
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.B))
			{
				playerCreationMenu.SetActive(false);
				MenuMainManager.played = true;
				PlayerSelectionMenu.isCreatingPlayer = false;
				return;
			}

			if (Input.GetKeyDown(KeyCode.B))
			{
				playerCreationMenu.SetActive(false);
				MenuMainManager.played = true;
				PlayerSelectionMenu.isCreatingPlayer = false;
				return;
			}

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (currentSelection < maxSelection)
				{
					currentSelection += 1;
					menu_tick.Play();
				}
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (currentSelection <= maxSelection && currentSelection > 0)
				{
					currentSelection -= 1;
					menu_tick.Play();
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Down))
            {
				if (currentSelection <= 9)
                {
					menu_tick.Play();
					currentSelection = 10;
                }
            }

			if (GamePad.GetButtonTrigger(N3dsButton.Down))
			{
				if (currentSelection == 10 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 11;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Down))
			{
				if (currentSelection <= 11 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 12;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Down))
			{
				if (currentSelection == 4 && editEyeColor)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}

				if (currentSelection == 5 && editSkinColor)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}

				if (currentSelection == 6 && editShirtColor)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}

				if (currentSelection == 10)
				{
					menu_tick.Play();
					currentSelection = 11;
					return;
				}
				if (currentSelection == 11)
				{
					menu_tick.Play();
					currentSelection = 12;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (currentSelection == 4 && editEyeColor)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}

				if (currentSelection == 5 && editSkinColor)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}

				if (currentSelection == 6 && editShirtColor)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}

				if (currentSelection == 10)
				{
					menu_tick.Play();
					currentSelection = 11;
					return;
				}
				if (currentSelection == 11)
				{
					menu_tick.Play();
					currentSelection = 12;
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Up))
			{
				if (currentSelection == 12)
				{
					menu_tick.Play();
					currentSelection = 11;
					return;
				}
				if (currentSelection == 11)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}
				if (currentSelection == 10)
				{
					menu_tick.Play();
					currentSelection = 4;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (currentSelection == 12)
				{
					menu_tick.Play();
					currentSelection = 11;
					return;
				}
				if (currentSelection == 11)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}
				if (currentSelection == 10)
				{
					menu_tick.Play();
					currentSelection = 4;
					return;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Up))
			{
				if (currentSelection == 9)
				{
					menu_tick.Play();
					currentSelection = 1;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Up))
			{
				if (currentSelection == 11 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 10;
				}
			}

			if (GamePad.GetButtonTrigger(N3dsButton.Up))
			{
				if (currentSelection == 12 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 11;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (currentSelection <= 9)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (currentSelection == 10 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 11;
					return;

				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (currentSelection == 11 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 12;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (currentSelection == 12 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 13;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (currentSelection == 10)
				{
					menu_tick.Play();
					currentSelection = 1;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (currentSelection == 11 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 10;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{ 
				if (currentSelection == 12 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 11;
					return;
				}
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (currentSelection == 13 && editInfo)
				{
					menu_tick.Play();
					currentSelection = 12;
					return;
				}
			}

			if (currentSelection == 10)
			{
				HT.color = Color.yellow;
			}
			else
			{
				HT.color = Color.white;
			}

			if (currentSelection == 11)
			{
				ST.color = Color.yellow;
			}
			else
			{
				ST.color = Color.white;
			}

			if (currentSelection == 12)
			{
				VT.color = Color.yellow;
			}
			else
			{
				VT.color = Color.white;
			}

			if (currentSelection == 11 && editInfo)
			{
				softCoreI.color = Color.yellow;
            }
			else
            {
				Color color;
				ColorUtility.TryParseHtmlString("#00FF95FF", out color);
				softCoreI.color = color;
			}

			if (currentSelection == 12 && editInfo)
			{
				mediumCoreI.color = Color.yellow;
			}
			else
			{
				Color color;
				ColorUtility.TryParseHtmlString("#B89C00FF", out color);
				mediumCoreI.color = color;
			}

			if (currentSelection == 13 && editInfo)
			{
				hardCoreI.color = Color.yellow;
			}
			else
			{
				Color color;
				ColorUtility.TryParseHtmlString("#9C0000FF", out color);
				hardCoreI.color = color;
			}

			if (currentSelection == 1)
            {
				Info.sprite = pannelHighlighted;
            }
			else
            {
				Info.sprite = pannelNormal;
            }

			if (currentSelection == 2)
			{
				Gender.sprite = pannelHighlighted;
			}
			else
			{
				Gender.sprite = pannelNormal;
			}

			if (currentSelection == 3)
			{
				HairStyle.sprite = pannelHighlighted;
			}
			else
			{
				HairStyle.sprite = pannelNormal;
			}

			if (currentSelection == 4)
			{
				EyeColor.sprite = pannelHighlighted;
			}
			else
			{
				EyeColor.sprite = pannelNormal;
			}

			if (currentSelection == 5)
			{
				SkinColor.sprite = pannelHighlighted;
			}
			else
			{
				SkinColor.sprite = pannelNormal;
			}

			if (currentSelection == 6)
			{
				ShirtColor.sprite = pannelHighlighted;
			}
			else
			{
				ShirtColor.sprite = pannelNormal;
			}

			if (currentSelection == 7)
			{
				UndershirtColor.sprite = pannelHighlighted;
			}
			else
			{
				UndershirtColor.sprite = pannelNormal;
			}

			if (currentSelection == 8)
			{
				PantsColor.sprite = pannelHighlighted;
			}
			else
			{
				PantsColor.sprite = pannelNormal;
			}

			if (currentSelection == 9)
			{
				ShoeColor.sprite = pannelHighlighted;
			}
			else
			{
				ShoeColor.sprite = pannelNormal;
			}

			if (currentSelection == 10 && editInfo == true)
			{
				namePanel.color = Color.yellow;

				if (GamePad.GetButtonTrigger(N3dsButton.A))
                {
					nameT.text = nameS;
					Keyboard.SetText(nameS);
					Keyboard.Show();
                }
			}
			else
			{
				Color color;
				ColorUtility.TryParseHtmlString("#1804B264", out color);
				namePanel.color = color;
			}

			if (currentSelection == 4)
			{
				if (GamePad.GetButtonTrigger(N3dsButton.A))
				{
					editEyeColor = true;
					editInfo = false;
					editSkinColor = false;
					editShirtColor = false;
				}

				if (Input.GetKeyDown(KeyCode.A))
				{
					editInfo = false;
					editEyeColor = true;
					editSkinColor = false;
					editShirtColor = false;

				}
			}

			if (currentSelection == 5)
			{
				if (GamePad.GetButtonTrigger(N3dsButton.A))
				{
					editSkinColor = true;
					editInfo = false;
					editEyeColor = false;
					editShirtColor = false;
				}

				if (Input.GetKeyDown(KeyCode.A))
				{
					editSkinColor = true;
					editInfo = false;
					editEyeColor = false;
					editShirtColor = false;
				}
			}

			if (currentSelection == 6)
			{
				if (GamePad.GetButtonTrigger(N3dsButton.A))
				{
					editShirtColor = true;
					editInfo = false;
					editSkinColor = false;
					editEyeColor = false;
				}

				if (Input.GetKeyDown(KeyCode.A))
				{
					editShirtColor = true;
					editInfo = false;
					editSkinColor = false;
					editEyeColor = false;
				}
			}

			if (currentSelection == 1)
			{
				if (GamePad.GetButtonTrigger(N3dsButton.A))
				{
					editInfo = true;
					editEyeColor = false;
					editSkinColor = false;
					editEyeColor = false;
					editShirtColor = false;
				}

				if (Input.GetKeyDown(KeyCode.A))
				{
					editInfo = true;
					editEyeColor = false;
					editSkinColor = false;
					editEyeColor = false;
					editShirtColor = false;
				}
			}

			if (editEyeColor == true)
            {
				softCore.SetActive(false);
				mediumCore.SetActive(false);
				hardCore.SetActive(false);
				namePanelObject.SetActive(false);
				ColorPickerS.SetActive(true);
			}
			else
            {
				softCore.SetActive(true);
				mediumCore.SetActive(true);
				hardCore.SetActive(true);
				namePanelObject.SetActive(true);
				ColorPickerS.SetActive(false);
			}

			if (editInfo == true)
			{
				softCore.SetActive(true);
				mediumCore.SetActive(true);
				hardCore.SetActive(true);
				namePanelObject.SetActive(true);
				ColorPickerS.SetActive(false);
			}
			else
			{
				softCore.SetActive(false);
				mediumCore.SetActive(false);
				hardCore.SetActive(false);
				namePanelObject.SetActive(false);
				ColorPickerS.SetActive(true);
			}

			if (editSkinColor == true)
			{
				softCore.SetActive(false);
				mediumCore.SetActive(false);
				hardCore.SetActive(false);
				namePanelObject.SetActive(false);
				ColorPickerS.SetActive(true);
			}

			if (editShirtColor == true)
			{
				softCore.SetActive(false);
				mediumCore.SetActive(false);
				hardCore.SetActive(false);
				namePanelObject.SetActive(false);
				ColorPickerS.SetActive(true);
			}
		}
	}

    public void SavePlayer()
    {
		menu_tick.Play();
		UnityEngine.N3DS.FileSystemSave.Mount();
		StreamWriter sw = File.CreateText(UnityEngine.Application.persistentDataPath +  "/playersave");
		string health = playerHealth.ToString();
		string mana = playerMana.ToString();
		for (int i = 1; i < 4; i++)
		{
			if (i == 1)
			{
				sw.WriteLine("100");
			}
			if (i == 2)
			{
				sw.WriteLine("20");
			}
			if (i == 3)
			{
				sw.WriteLine("0:00");
			}
			if (i == 4)
			{
				sw.WriteLine(nameS);
			}
		}
		sw.Close();
		UnityEngine.N3DS.FileSystemSave.Unmount();
		PlayerSelectionMenu.player1Made = true;
		PlayerSelectionMenu.isCreatingPlayer = false;
		menu.ExitCharCreator();
		return;
	}
}
