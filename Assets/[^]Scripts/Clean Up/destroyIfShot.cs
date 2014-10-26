using UnityEngine;
using System.Collections;

public class destroyIfShot : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "projectile")
		{
			Destroy(gameObject);
		}
	}
}