using UnityEngine;
using System.Collections;

public class DadAI : MonoBehaviour
{
	public GameObject[] pathNodes;

	public float maxSpeed;
	public GameObject targetNode = null;
	public int targetNodeInt;

	Animator anim;

	public GUISkin mySkin;
	Vector2 aiPos;

	public float HP = 100;

	void Start()
	{
		//pathNodes = GameObject.FindGameObjectsWithTag("pathNode");
		targetNodeInt = 0;
		targetNode = pathNodes[targetNodeInt];

		anim = GetComponent<Animator>();
		anim.SetBool("isGrounded", true);
		anim.SetBool("isMoving", true);

	}

	void FixedUpdate ()
	{
		Vector3 movedistance = targetNode.transform.position - transform.position;		//CHANGE ALL WHY USE LERP AND THEN REMOVE SMOOTHING???
		Vector3 pos = new Vector3(Mathf.Lerp(transform.position.x, targetNode.transform.position.x, maxSpeed / Mathf.Abs(movedistance.x)*Time.deltaTime), transform.position.y, transform.position.z);
		transform.position = pos;

		aiPos = Camera.main.WorldToScreenPoint(transform.position);								//getting position fot GUI buttons
		aiPos.y = Screen.height - aiPos.y;

		if(HP <= 0)
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == targetNode)
		{
			setNode();
		}

		if(other.gameObject.tag == "projectile")
		{
			if(other.name == "plasma_ptl(Clone)")
			{
				HP -= 10;
			}

			else if (other.name == "plasmaGrenade_ptl(Clone)")
			{
			    HP -= 50;
				rigidbody2D.AddForce(transform.position + other.transform.position*2200);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "hazard")
		{
			//Debug.Log(col.relativeVelocity.magnitude);

			//Debug.Log(col.relativeVelocity.sqrMagnitude + "SQR");

			HP -= HP;
		}
	}

	void setNode()
	{
		int newNode = Random.Range(0, pathNodes.Length);

		if(newNode == targetNodeInt)
		{
			if(newNode < pathNodes.Length - 1)	
			{	newNode++;	targetNodeInt++;	}
			else
			{	newNode--; targetNodeInt--;		}
		}
			else
		{
			targetNodeInt = newNode;
		}

		targetNode = pathNodes[newNode];

		if(targetNode.transform.position.x - transform.position.x < 0 && transform.localScale.x > 0)			//right is +
		{
			Vector3 myScale = transform.localScale;																//left is -			
			myScale.x *= -1;
			transform.localScale = myScale;
		}
		else if (targetNode.transform.position.x - transform.position.x > 0 && transform.localScale.x < 0)
		{
			Vector3 myScale = transform.localScale;																		
			myScale.x *= -1;
			transform.localScale = myScale;
		}
	}

	void OnGUI()
	{
		GUI.skin = mySkin;

		GUI.Box(new Rect(aiPos.x - 50, aiPos.y - 100, HP, 10), "");
		//GUI.Label(new Rect(aiPos.x, aiPos.y - 100, 100, 10), "");
	}
}