using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public static float runSpeed = 20f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		if (GamePad.GetButtonTrigger(N3dsButton.Left)) {
			horizontalMove = -runSpeed;
		} else if (GamePad.GetButtonTrigger(N3dsButton.Right)) {
			horizontalMove = runSpeed;
		} else {
			horizontalMove = 0;
		}
		
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (GamePad.GetButtonTrigger(N3dsButton.Y))
		{
			jump = true;
		}
		
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
