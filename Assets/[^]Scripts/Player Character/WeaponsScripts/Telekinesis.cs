
using UnityEngine;
using System.Collections;

public class Telekinesis : MonoBehaviour 
{
	public float followSpeed = 1.0f, rotSpeed = 50, moveSpeed = 1.0f, MKmoveSpeed = 100, 
					throwForce = 1000, gravityGunRange = 1.0f, TKlimit = 7.5f, gravityScale;
	float maxRotSpeed, maxMoveSpeed;
	public LayerMask telekinesisIgnore;

	public static bool isHolding = false;

	public bool isThrowing = false;
	bool heldObjTooFar;

	public Transform heldObj, myTransform;
	
	public Vector3 offset, objRotation;
	Vector3 refV3 = Vector3.one;
	Vector2 refV2 = Vector2.one;

	ParticleSystem particle;
	public GameObject LineRendererObject;

	void Start()
	{
		myTransform = transform;														//cached transform
																						//cached transform.parent


		maxRotSpeed = rotSpeed;
		maxMoveSpeed = moveSpeed;

//		LineRendererObject = transform.GetChild(0).gameObject;
	}

	void LateUpdate()
	{
		if(!isHolding)
		{	
			if(Input.GetButtonDown("RB_1") || Input.GetMouseButtonDown(1) && !isThrowing)
			{	
				RaycastHit2D hit2D = Physics2D.Raycast(myTransform.position, 								//raycasting along the aim diretion
				                    	new Vector3 (myTransform.right.x * myTransform.parent.localScale.x, 
				            				 myTransform.right.y, myTransform.right.z), gravityGunRange, telekinesisIgnore);
				if(hit2D == true)																			//Raycasting for object pick-up
				{
					if(hit2D.collider.tag == "moveable")
					{
						isHolding = true;	
						heldObj = hit2D.collider.transform;

						gravityScale = heldObj.rigidbody2D.gravityScale;
						heldObj.rigidbody2D.gravityScale = 0.0f;
						heldObj.rigidbody2D.velocity = Vector2.zero;
//						heldObj.rigidbody2D.isKinematic = true;

						heldObj.gameObject.layer = 10;														//set layer to telekinesis layer
						particle = heldObj.transform.GetChild(0).GetComponent<ParticleSystem>();
						particle.enableEmission = true;

						if(heldObj.GetComponent<SmartPipes>() != null){
							heldObj.GetComponent<SmartPipes>().Drop(false);
						}


						LineRendererObject.GetComponent<TelekinesisLineRenderer>().SetTarget(heldObj.gameObject);
						LineRendererObject.SetActive(true);
//						LogUse();
					}
				}
			}
		}	
		else
		{
			if(isHolding && !isThrowing){	
				grabObject(heldObj);													//calling grab object function every frame the obj is held and RT is pressed
			} 
				else{	
					dropObject();															//calling drop object if object is held an RT is no longer being pressed
				}
					if(Input.GetButtonDown("RB_1") || Input.GetMouseButtonDown(1)){
						dropObject();															//calling drop object if object is held an RT is no longer being pressed
					}
						if(Input.GetAxisRaw("RTrigger_1") > 0 || Input.GetMouseButtonDown(0)){
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
			float newZ = 0;
			obj.position = new Vector3(obj.position.x, obj.position.y, newZ);

			if(Input.GetButton("LB_1"))
			{
				obj.RotateAround(obj.renderer.bounds.center, obj.transform.forward, rotSpeed);
			}

			offset.x += Input.GetAxis("R_XAxis_1")* Time.deltaTime * moveSpeed;			//While holding obj, V3 offset adjusted by R-Stick input
			offset.y += -Input.GetAxis("R_YAxis_1")* Time.deltaTime * moveSpeed;		

			offset = Vector3.ClampMagnitude(offset, TKlimit);
		}
		else if(UIManager._input == UIManager.InputType.MouseKBoard)		//TELEKINESIS CONTROLS FOR MOUSE+KEYBOARD____________________________________
		{	
			Vector2 mousePos = new Vector3(myTransform.position.x + (Mathf.Abs(obj.localScale.x)), myTransform.position.y, 0) + offset; 

			obj.position = Vector3.SmoothDamp(obj.position, mousePos, ref refV3, followSpeed); 

			float newZ = 0;
			obj.position = new Vector3(obj.position.x, obj.position.y, newZ);

			if(Input.GetAxis("QE") != 0)
			{
				obj.RotateAround(obj.renderer.bounds.center, obj.transform.forward, Input.GetAxis("QE"));
			}
			
			offset.x += Input.GetAxis("Mouse X")* Time.deltaTime * MKmoveSpeed;			//While holding obj, V3 offset adjusted by mouse X+Y input
			offset.y += Input.GetAxis("Mouse Y")* Time.deltaTime * MKmoveSpeed;	

			offset = Vector3.ClampMagnitude(offset, TKlimit);

		}
	}

	public void dropObject()														//called to drop current held object
	{
		heldObj.gameObject.layer = 11;												//reset object layer

		heldObj.collider2D.enabled = false;
		heldObj.collider2D.enabled = true;

		heldObj.rigidbody2D.gravityScale = gravityScale;
		heldObj.rigidbody2D.velocity = Vector2.zero;

		particle.enableEmission = false;
//		if(isHolding)StartCoroutine("DisableParticle");

		isHolding = false;						
		offset = Vector3.zero;								//reset offset
		rotSpeed = maxRotSpeed;								//reset speeds
		moveSpeed = maxMoveSpeed;
		LineRendererObject.SetActive(false);

		if(heldObj.GetComponent<SmartPipes>() != null)
			heldObj.SendMessage("SnapPipe");
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
		
		obj.rigidbody2D.AddForce(new Vector3 (transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z) * throwForce, ForceMode2D.Impulse);

		yield return new WaitForSeconds (1);
		
		isThrowing = false;
	}

//	IEnumerator DisableParticle()
//	{
//		yield return new WaitForSeconds(0.0f);
//		particle.enableEmission = false;
//	}

	public static int timesUsedTK;
	void LogUse()
	{
		timesUsedTK++;
	}

//	public Transform GetHeldObj()
//	{
//		return heldObj;
//	}
}