using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour 
{
	public float maxSpeed, jumpForce;

	bool isMoving, facingLeft, jumpPressed = false;

	public LayerMask ground;
	public Transform groundcheck, aimReticule;
	public float GroundCheckSize;

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("L_XAxis_1") != 0){isMoving = true;}else{isMoving = false;}

		/*																	
			if(Input.GetAxis("Horizontal") != 0)													//
				{																					//
					float move = Input.GetAxis("Horizontal");										//
																									//	
					rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);	//	Keyboard + mouse controlls
																									//		
					if(move > 0 && facingLeft)														//
						Flip();																		//
					else if (move < 0 && !facingLeft)												//		
						Flip();	

				}
			if(Input.GetAxisRaw("Jump")>0 && isGrounded)
				{
					rigidbody2D.AddForce(Vector2.up * jumpForce);
				}						
		*/

		if(Input.GetAxis("L_XAxis_1") != 0)															//Xbox Pad controlls
			{
				float move = Input.GetAxis("L_XAxis_1");
				
				rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
				
				if(move > 0 && facingLeft)
					Flip();
				else if (move < 0 && !facingLeft)
					Flip();
			}

		if(Input.GetButton("LB_1"))
		{
			jump();
		}	else
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
