using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour 
{
//	public enum InputType {XboxPad, MouseKBoard}
//	public InputType _input;

	public float maxSpeed, jumpForce;

	public float speedIncrease, jumpIncrease, gravityIncrease;

	bool isMoving, facingLeft, jumpPressed = false;

	public LayerMask ground;
	public Transform groundcheck, aimReticule;
	public float GroundCheckSize;

	public Transform reticule; 
	public float range;

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();

		if(Input.GetJoystickNames().Length <= 0)
		{
			UIManager._input = UIManager.InputType.MouseKBoard;
		}
		else{
			UIManager._input = UIManager.InputType.XboxPad;
		}
	}

	void FixedUpdate ()
	{
		switch(UIManager._input)
		{
			case UIManager.InputType.MouseKBoard:

				if(Input.GetAxis("Horizontal") != 0){isMoving = true;}else{isMoving = false;}
				
				if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
				{
					jump();
				} 
				else 
				{
					jumpPressed = false;
				}

				if(Input.GetAxis("Horizontal") != 0)													
				{																					
					float move = Input.GetAxis("Horizontal");										
					
					rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);	//	Keyboard + mouse controls
					
					if(move > 0 && facingLeft)														
						Flip();																		
					else if (move < 0 && !facingLeft)													
						Flip();	
				}

			break;

			case UIManager.InputType.XboxPad:

				if(Input.GetAxis("L_XAxis_1") != 0){isMoving = true;}else{isMoving = false;}

				if(Input.GetAxis("L_XAxis_1") != 0)														
				{												
					float move = Input.GetAxis("L_XAxis_1");
					
					rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);	//Xbox Pad controlls
					
					if(move > 0 && facingLeft)
						Flip();
					else if (move < 0 && !facingLeft)
						Flip();
				}
				
				if(Input.GetAxis("LTrigger_1") >= 0.1 || Input.GetButton("A_1"))
				{
					jump();
				}	
				else
				{
					jumpPressed = false;
				}
				
				if(Input.GetAxis("R_XAxis_1") != 0)	
				{
					float move = Input.GetAxis("R_XAxis_1");
					
					if(move > 0 && facingLeft)
						Flip();
					else if (move < 0 && !facingLeft)
						Flip();
				}

			break;
		}

//		float inputFloat = Mathf.Abs(Input.GetAxis("L_XAxis_1") + Input.GetAxis("Horizontal"));
//		bool isTrue = (Input.GetButton("A_1") && Input.GetButton(KeyCode.W)) ? true : false;
//		if(inputFloat <= 0 && groundCheck.isGrounded && !Input.GetButton("A_1") && !Input.GetKey(KeyCode.W))rigidbody2D.Sleep();
//		else{rigidbody2D.WakeUp();}
//		if(groundCheck.isGrounded)rigidbody2D.w();



	}

	void Update()
	{
		anim.SetBool("isGrounded", groundCheck.isGrounded);
		anim.SetBool("isMoving", isMoving);
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	void jump()
	{
		if(groundCheck.isGrounded && jumpPressed == false)
		{
			rigidbody2D.AddForce((Vector2.up * jumpForce), ForceMode2D.Force);
			jumpPressed = true;
		}
	}

	public void TimeAdjust(bool on_off)
	{
		if(on_off)
		{
			maxSpeed += speedIncrease;
			jumpForce += jumpIncrease;
			rigidbody2D.gravityScale += gravityIncrease;
		}
		else if (!on_off)
		{
			maxSpeed -= speedIncrease;
			jumpForce -= jumpIncrease;
			rigidbody2D.gravityScale -= gravityIncrease;
		}
	}

}
