using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class moveCamaera : MonoBehaviour {

	public Transform trans;

	void Update () {
		if (MenuMainManager.debugWorld == true) {
			if (GamePad.GetButtonTrigger(N3dsButton.Right)) {
				trans.Translate(new Vector3(0.3f, 0, 0));
				return;
			}
			if (GamePad.GetButtonTrigger(N3dsButton.Left))
			{
				trans.Translate(new Vector3(-0.3f, 0, 0));
				return;
			}
			if (GamePad.GetButtonTrigger(N3dsButton.Up))
			{
				trans.Translate(new Vector3(0, -0.3f, -0.3f));
				return;
			}
			if (GamePad.GetButtonTrigger(N3dsButton.Down))
			{
				trans.Translate(new Vector3(0, 0.3f, 0.3f));
				return;
			}
			
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				trans.Translate(new Vector3(0.3f, 0, 0));
				return;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				trans.Translate(new Vector3(-0.3f, 0, 0));
				return;
			}
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				trans.Translate(new Vector3(0, -0.3f, -0.3f));
				return;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				trans.Translate(new Vector3(0, 0.3f, 0.3f));
				return;
			}
		}
	}
}
