using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour 
{
	public enum InputType {XboxPad, MouseKBoard}
	public InputType _input;

	public float maxSpeed, jumpForce;

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
			_input = InputType.MouseKBoard;
		}
		else{
			_input = InputType.XboxPad;
		}
	}

	void FixedUpdate ()
	{
		switch(_input)
		{
			case InputType.MouseKBoard:

				if(Input.GetAxis("Horizontal") != 0){isMoving = true;}else{isMoving = false;}
				
				if(Input.GetKey(KeyCode.Space))
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

			case InputType.XboxPad:

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
				
				if(Input.GetAxis("R_XAxis_1") != 0 && !gravityGun.isHolding)	
				{
					float move = Input.GetAxis("R_XAxis_1");
					
					if(move > 0 && facingLeft)
						Flip();
					else if (move < 0 && !facingLeft)
						Flip();
				}
			break;
		}
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

}
