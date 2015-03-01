using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour {

	public static bool isGrounded = false;

//	void Start()
//	{
//		InvokeRepeating("checkGround", 0.0025f, 0.0025f);
//	}
//
//	void checkGround()
//	{
//		Collider2D[] _ground = new Collider2D[1];
//		Physics2D.OverlapAreaNonAlloc(collider2D.bounds.max, collider2D.bounds.min, _ground);
//
//		foreach(Collider2D col in _ground)
//		{
//			if(col != null && !col.isTrigger)
//			{
//				isGrounded = true;
//			}else{
//				isGrounded = false;
//			}
//		}
//	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(!other.isTrigger)isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(!other.isTrigger)isGrounded = false;
	}
}
