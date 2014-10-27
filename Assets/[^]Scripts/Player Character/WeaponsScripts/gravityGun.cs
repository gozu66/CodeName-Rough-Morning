using UnityEngine;
using System.Collections;

public class gravityGun : MonoBehaviour 
{
	public float followSpeed = 1.0f, rotSpeed = 50, moveSpeed = 1.0f, throwForce = 1000, gravityGunRange = 1.0f;
	float maxRotSpeed, maxMoveSpeed;

	public static bool isHolding = false;
	public bool isThrowing = false;
	bool heldObjTooFar;

	Transform heldObj, myTransform, myTransformParent;
	
	public Vector3 offset, objRotation;
	Vector3 refV3 = Vector3.one;

	void Start()
	{
		myTransform = transform;								//cached transform
		myTransformParent = transform.parent;					//cached transform.parent

		maxRotSpeed = rotSpeed;
		maxMoveSpeed = moveSpeed;
	}

	void Update()
	{
		if(!isHolding)
		{	
			if(Input.GetAxis("RTrigger_1") >= 0.1 && !isThrowing)
			{																																		//raycasting along the aim diretion
				RaycastHit2D hit2D = Physics2D.Raycast(myTransform.position, new Vector3 (myTransform.right.x * myTransform.parent.localScale.x, myTransform.right.y, myTransform.right.z), gravityGunRange);

				if(hit2D == true)													//Raycasting for object pick-up
				{
					if(hit2D.collider.tag == "moveable")
					{
						isHolding = true;									

						hit2D.collider.rigidbody2D.isKinematic = true;
						heldObj = hit2D.collider.transform;							//cache selected object as heldobj
						heldObj.gameObject.layer = 10;								//set layer to telekinesis layer
					}
				}
			}
		}	
		else
		{
			offset.x += Input.GetAxis("R_XAxis_1")* Time.deltaTime * moveSpeed;		//While holding obj, V3 offset adjusted by D-Pad input
			offset.y += -Input.GetAxis("R_YAxis_1")* Time.deltaTime * moveSpeed;		

			if(Input.GetAxis("RTrigger_1") != 0 && !isThrowing)
			{	
				grabObject(heldObj);						//calling grab object function every frame the obj is held and RT is pressed
			} 
			else
			{	
				dropObject(heldObj);						//calling drop object if object is held an RT is no longer being pressed
			}
		}
		if(Input.GetButtonDown("LB_1") && isHolding)
		{
			StartCoroutine("throwObject", heldObj);			//Throwing coroutine
		}
	}

	void grabObject(Transform obj)
	{																								//creating desired position and adding offset
		Vector2 newPos = new Vector3(myTransform.position.x + (Mathf.Abs(obj.localScale.x) * myTransformParent.localScale.x), myTransform.position.y, 0) + offset;               				

		obj.position = Vector3.SmoothDamp(obj.position, newPos, ref refV3, followSpeed); 			//moving held object to desired postion + offset

		if(Input.GetButton("X_1"))
		{
			obj.Rotate(new Vector3(0,0,rotSpeed) * (Time.deltaTime), Space.Self);					//applying R-Dtick rot to heldobj
		}

		if(Input.GetButton("A_1"))
		{
			obj.Rotate(new Vector3(0,0,-rotSpeed) * (Time.deltaTime), Space.Self);					//applying R-Dtick rot to heldobj
		}

		offset.x = Mathf.Clamp(offset.x, -10, 10);
		offset.y = Mathf.Clamp(offset.y, -10, 10);
	}

	public void dropObject(Transform obj)					//called to drop current held object
	{
		heldObj.gameObject.layer = 11;						//reset object layer
		obj.rigidbody2D.isKinematic = false;	
		isHolding = false;						
		offset = new Vector3(0,0,0);						//reset offset
		rotSpeed = maxRotSpeed;								//reset speeds
		moveSpeed = maxMoveSpeed;
	}
	
	void OnDisable()
	{
		if(heldObj)
			dropObject(heldObj);							//if telekinesis is deselected during use, drop obejct
	}

	IEnumerator throwObject(Transform obj)					//throwing co-routine
	{
		isThrowing = true;			
		
		dropObject(heldObj);								//drop obj
		
		obj.rigidbody2D.AddForce((myTransform.right * myTransformParent.localScale.x) * throwForce, ForceMode2D.Impulse);	//throw obj
		
		yield return new WaitForSeconds (1);
		
		isThrowing = false;
	}
}
