using UnityEngine;
using System.Collections;

public class Telekinesis : MonoBehaviour 
{
	public float followSpeed = 1.0f, rotSpeed = 50, moveSpeed = 1.0f, MKmoveSpeed = 100, throwForce = 1000, gravityGunRange = 1.0f, TKlimit = 7.5f;
	float maxRotSpeed, maxMoveSpeed;

	public static bool isHolding = false;
	public bool isThrowing = false;
	bool heldObjTooFar;

	Transform heldObj, myTransform, myTransformParent;
	
	public Vector3 offset, objRotation;
	Vector3 refV3 = Vector3.one;

	void Start()
	{

		myTransform = transform;														//cached transform
		myTransformParent = transform.parent;											//cached transform.parent

		maxRotSpeed = rotSpeed;
		maxMoveSpeed = moveSpeed;
	}

	void Update()
	{
		Debug.DrawRay(myTransform.position, new Vector3 (myTransform.right.x * myTransform.parent.localScale.x, myTransform.right.y, myTransform.right.z), Color.green);
		if(!isHolding)
		{	
			if(Input.GetButtonDown("RB_1") || Input.GetMouseButtonDown(1) && !isThrowing)
			{	
				RaycastHit2D hit2D = Physics2D.Raycast(myTransform.position, 								//raycasting along the aim diretion
				                    	new Vector3 (myTransform.right.x * myTransform.parent.localScale.x, 
				             				myTransform.right.y, myTransform.right.z), gravityGunRange);



				if(hit2D == true)																			//Raycasting for object pick-up
				{

					if(hit2D.collider.tag == "moveable")
					{

						isHolding = true;									
						hit2D.collider.rigidbody2D.isKinematic = true;
						heldObj = hit2D.collider.transform;													//cache selected object as heldobj
						heldObj.gameObject.layer = 10;														//set layer to telekinesis layer
						LogUse();
					}
				}
			}
		}	
		else
		{
			if(isHolding && !isThrowing)
			{	
				grabObject(heldObj);													//calling grab object function every frame the obj is held and RT is pressed
			} 

			else
			{	
				dropObject();															//calling drop object if object is held an RT is no longer being pressed
			}

			if(Input.GetButtonDown("RB_1") || Input.GetMouseButtonDown(1))
			{
				dropObject();															//calling drop object if object is held an RT is no longer being pressed
			}

			if(Input.GetAxisRaw("RTrigger_1") > 0 || Input.GetMouseButtonDown(0))
			{
				StartCoroutine("throwObject", heldObj);									//Throwing coroutine
			}
		}
	}

	void grabObject(Transform obj)
	{																					
		if(UIManager._input == UIManager.InputType.XboxPad)					//TELEKINESIS CONTROLS FOR GAMEPAD__________________________________
		{
			Vector2 newPos = new Vector3(myTransform.position.x + (Mathf.Abs(obj.localScale.x)), myTransform.position.y, 0) + offset;   //creating desired position and adding offset            				

			obj.position = Vector3.SmoothDamp(obj.position, newPos, ref refV3, followSpeed); 											//moving held object to desired postion + offset

			if(Input.GetButton("LB_1"))
			{
				obj.Rotate(new Vector3(0,0,rotSpeed) * (Time.deltaTime), Space.Self);					
			}

			offset.x += Input.GetAxis("R_XAxis_1")* Time.deltaTime * moveSpeed;			//While holding obj, V3 offset adjusted by R-Stick input
			offset.y += -Input.GetAxis("R_YAxis_1")* Time.deltaTime * moveSpeed;		

//			offset.x = Mathf.Clamp(offset.x, -TKlimit, TKlimit);
//			offset.y = Mathf.Clamp(offset.y, -TKlimit, TKlimit);

			offset = Vector3.ClampMagnitude(offset, TKlimit);
		}
		else if(UIManager._input == UIManager.InputType.MouseKBoard)		//TELEKINESIS CONTROLS FOR GAMEPAD____________________________________
		{	
			Vector2 mousePos = new Vector3(myTransform.position.x + (Mathf.Abs(obj.localScale.x)), myTransform.position.y, 0) + offset; 

			obj.position = Vector3.SmoothDamp(obj.position, mousePos, ref refV3, followSpeed); 		

			if(Input.GetAxis("QE") != 0)
			{
				obj.Rotate(new Vector3(0,0,rotSpeed * Input.GetAxis("QE")) * (Time.deltaTime), Space.Self);					
			}
			
			offset.x += Input.GetAxis("Mouse X")* Time.deltaTime * MKmoveSpeed;			//While holding obj, V3 offset adjusted by mouse X+Y input
			offset.y += Input.GetAxis("Mouse Y")* Time.deltaTime * MKmoveSpeed;	

//			offset.x = Mathf.Clamp(offset.x, -10, 10);
//			offset.y = Mathf.Clamp(offset.y, -10, 10);

			offset = Vector3.ClampMagnitude(offset, TKlimit);

		}
	}

	public void dropObject()								//called to drop current held object
	{
		heldObj.gameObject.layer = 11;						//reset object layer
		heldObj.rigidbody2D.isKinematic = false;	
		isHolding = false;						
		offset = Vector3.zero;								//reset offset
		rotSpeed = maxRotSpeed;								//reset speeds
		moveSpeed = maxMoveSpeed;
	}
	
	void OnDisable()
	{
		if(heldObj)
			dropObject();									//if telekinesis is deselected during use, drop obejct
	}

	IEnumerator throwObject(Transform obj)					//throwing co-routine
	{
		isThrowing = true;			
		
		dropObject();										//drop obj
		
//		obj.rigidbody2D.AddForce(new Vector2(obj.transform.position.x - myTransform.position.x, 
//		                                     obj.transform.position.y - myTransform.position.y) * throwForce, ForceMode2D.Impulse);
//		obj.rigidbody2D.AddForce(new Vector3 (myTransform.right.x * myTransform.parent.localScale.x, 
//		                                      myTransform.right.y, myTransform.right.z));
		obj.rigidbody2D.AddForce(new Vector3 (transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z) * throwForce, ForceMode2D.Impulse);

		yield return new WaitForSeconds (1);
		
		isThrowing = false;
	}

	public static int timesUsedTK;
	void LogUse()
	{
		timesUsedTK++;
	}

}