using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour {

	public static bool isGrounded = false;

	void OnTriggerStay2D(Collider2D col)
	{
		isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		isGrounded = false;
	}
}
