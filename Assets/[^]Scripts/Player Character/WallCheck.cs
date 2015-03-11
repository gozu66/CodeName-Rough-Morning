using UnityEngine;
using System.Collections;

public class WallCheck : MonoBehaviour 
{
	public static bool isPushing = false;

	void OnTriggerStay2D(Collider2D other)
	{
		if(!other.isTrigger)isPushing = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(!other.isTrigger)isPushing = false;
	}
}